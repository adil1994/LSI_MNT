using GeoAPI.Geometries;
using Npgsql;
using SharpMap.Data.Providers;
using SharpMap.Layers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MNT
{
    public partial class MNT : Form
    {
        NpgsqlConnection cnx;
        String tbHost = "localhost";
        String tbPort = "5432";
        String tbUser = "postgres";
        String tbPass = "root";
        String tbDataBaseName = "mntdb";
        VectorLayer mnts, points, lines;
        int drawnpoints = 0;
        double x1, x2, y1, y2,realDistance=0;
        List<PointF> pointslist;


        public MNT()
        {
            InitializeComponent();

            string connstring = String.Format("Server={0};Port={1};" +
                   "User Id={2};Password={3};Database={4};",
                   tbHost, tbPort, tbUser,
                   tbPass, tbDataBaseName);
            cnx = new NpgsqlConnection(connstring);
            cnx.Open();

            mnts = new VectorLayer("MNT");
            points = new VectorLayer("Points");
            lines = new VectorLayer("Lines");

            pointslist = new List<PointF>();

            mapBox1.Map.Layers.Add(mnts);
            mapBox1.Map.Layers.Add(points);
            mapBox1.Map.Layers.Add(lines);

            mnts.DataSource = new PostGIS(connstring, "mnt", "id");
            points.DataSource = new PostGIS(connstring, "points", "id");
            lines.DataSource = new PostGIS(connstring, "lines", "id");


            SharpMap.Styles.VectorStyle min = new SharpMap.Styles.VectorStyle();
            SharpMap.Styles.VectorStyle max = new SharpMap.Styles.VectorStyle();
            //Create a fill that starts from white to red
            //and an outline that starts from thin black to wide yellow
            min.Fill = new SolidBrush(Color.White);
            max.Fill = new SolidBrush(Color.Blue);
            min.Outline = new Pen(Color.Black, 1);
            max.Outline = new Pen(Color.Black, 1);
            min.EnableOutline = true;
            max.EnableOutline = true;

            //Create theme using a population density from 0 (min) to 400 (max)
            mnts.Theme = new SharpMap.Rendering.Thematics.GradientTheme("altitude", 0, 400, min, max);

            mapBox1.Map.ZoomToExtents();
            mapBox1.Refresh();
            mapZoomToolStrip1.MapControl = mapBox1;

            mapBox1.MouseDoubleClick += addPoint;
            
        }

        private void addPoint(object sender, MouseEventArgs e)
        {
            Coordinate coord = mapBox1.Map.ImageToWorld(new PointF(e.X, e.Y));

            if (drawnpoints == 0)
            {
               
                NpgsqlCommand cmd2 = new NpgsqlCommand("TRUNCATE points; TRUNCATE lines;", cnx);
                cmd2.ExecuteNonQuery();
                x1label.Text = "X1 : " + Math.Round(coord.X, 2);
                y1label.Text = "Y1 : " + Math.Round(coord.Y, 2);
                drawnpoints++;
                x1 = coord.X;
                y1 = coord.Y;
            }
            else if (drawnpoints == 1)
            {
                x2label.Text = "X2 : " + Math.Round(coord.X, 2);
                y2label.Text = "Y2 : " + Math.Round(coord.Y, 2);
                drawnpoints=0;
                x2 = coord.X;
                y2 = coord.Y;
                distancelabel.Text = "Distance : " + Math.Round(Math.Sqrt((x2 - x1) * (x2 - x1) + (y2 - y1) * (y2 - y1)),2);
                intersectionPoints();
                NpgsqlCommand cmdl = new NpgsqlCommand("insert into lines (line) values('LineString(" + x1 + " " + y1 + "," + x2 + " " + y2 + ")')", cnx);
                cmdl.ExecuteNonQuery();
               
            }
           

            NpgsqlCommand cmd = new NpgsqlCommand("insert into points (point) values('POINT("+coord.X+" "+ coord.Y+")')", cnx);
            cmd.ExecuteNonQuery();

            pointslist.Clear();

            prepareList();
            pointslist = SortByDistance(pointslist);
            calculateRealDistance();
            dataGridView1.DataSource = pointslist;

            mapBox1.Refresh();

            
        }

        private void calculateRealDistance()
        {
            for (int i=0; i<pointslist.Count-1;i++)
            {
                realDistance += Math.Sqrt( (pointslist[i+1].X- pointslist[i].X) * (pointslist[i + 1].X - pointslist[i].X) + (pointslist[i + 1].Y - pointslist[i].Y) * (pointslist[i + 1].Y - pointslist[i].Y) + (getPointAltitude(pointslist[i + 1])- getPointAltitude(pointslist[i])) * (getPointAltitude(pointslist[i + 1]) - getPointAltitude(pointslist[i])));
            }
            rdistancelabel.Text = "RDistance : " + Math.Round(realDistance,2);
            realDistance = 0;
        }

        private void MNT_FormClosing(object sender, FormClosingEventArgs e)
        {
            NpgsqlCommand cmd2 = new NpgsqlCommand("TRUNCATE points; TRUNCATE lines;", cnx);
            cmd2.ExecuteNonQuery();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Graph g = new Graph(pointslist);
            g.Show();
        }

        public int getPointAltitude(PointF p)
        {
            NpgsqlCommand cmd = new NpgsqlCommand("select altitude from mnt where st_area(zone) = (SELECT Min(st_area(zone)) from mnt where st_intersects(zone,'point("+p.X+" "+p.Y+")'));", cnx);
            return int.Parse(cmd.ExecuteScalar().ToString()); 
        }

        private void prepareList()
        {
            NpgsqlCommand cmd2 = new NpgsqlCommand("SELECT	st_astext(point) from points", cnx);
            DataTable dt = new DataTable();
            var data = cmd2.ExecuteReader();
            dt.Load(data);
            foreach (DataRow item in dt.Rows)
            {
                String point = item[0].ToString();
                int x0 = point.IndexOf("(") + "(".Length;
                int x1 = point.LastIndexOf(" ");
                String x = point.Substring(x0, x1 - x0);

                int y0 = point.IndexOf(" ") + " ".Length;
                int y1 = point.LastIndexOf(")");
                String y = point.Substring(y0, y1 - y0);

                PointF p = new PointF(float.Parse(x), float.Parse(y));
                pointslist.Add(p);

            }
        }

        private void intersectionPoints()
        {
            NpgsqlCommand cmd2 = new NpgsqlCommand("SELECT (st_dump(st_intersection(st_boundary(zone), 'LINESTRING(" + x1 + " " + y1 + "," + x2 + " " + y2 + ")'))) AS points FROM mnt WHERE st_intersects(zone, 'LINESTRING(" + x1 + " " + y1 + "," + x2 + " " + y2 + ")'); ", cnx);
            DataTable dt = new DataTable();
            var data = cmd2.ExecuteReader();
            dt.Load(data);
                foreach (DataRow item in dt.Rows)
                {
                    String point =  item[0].ToString();
                    int pFrom = point.IndexOf(",") + ",".Length;
                    int pTo = point.LastIndexOf(")");
                    String result = point.Substring(pFrom, pTo - pFrom);
                    NpgsqlCommand cmd = new NpgsqlCommand("insert into points (point) values('"+ result + "')", cnx);
                    cmd.ExecuteNonQuery();
                }
            dataGridView1.DataSource = dt;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        List<PointF> SortByDistance(List<PointF> lst)
        {
            List<PointF> output = new List<PointF>();
            output.Add(lst[NearestPoint(new PointF((float)x1, (float)y1), lst)]);
            lst.Remove(output[0]);
            int x = 0;
            for (int i = 0; i < lst.Count + x; i++)
            {
                output.Add(lst[NearestPoint(output[output.Count - 1], lst)]);
                lst.Remove(output[output.Count - 1]);
                x++;
            }
            return output;
        }

        int NearestPoint(PointF srcPt, List<PointF> lookIn)
        {
            KeyValuePair<double, int> smallestDistance = new KeyValuePair<double, int>();
            for (int i = 0; i < lookIn.Count; i++)
            {
                double distance = Math.Sqrt(Math.Pow(srcPt.X - lookIn[i].X, 2) + Math.Pow(srcPt.Y - lookIn[i].Y, 2));
                if (i == 0)
                {
                    smallestDistance = new KeyValuePair<double, int>(distance, i);
                }
                else
                {
                    if (distance < smallestDistance.Key)
                    {
                        smallestDistance = new KeyValuePair<double, int>(distance, i);
                    }
                }
            }
            return smallestDistance.Value;
        }
    }
}
