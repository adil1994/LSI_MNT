using Npgsql;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace MNT
{
    public partial class Graph : Form
    {
        NpgsqlConnection cnx;
        String tbHost = "localhost";
        String tbPort = "5432";
        String tbUser = "postgres";
        String tbPass = "root";
        String tbDataBaseName = "mntdb";


        public Graph(List<PointF> points)
        {
            InitializeComponent();

            string connstring = String.Format("Server={0};Port={1};" +
                   "User Id={2};Password={3};Database={4};",
                   tbHost, tbPort, tbUser,
                   tbPass, tbDataBaseName);
            cnx = new NpgsqlConnection(connstring);
            cnx.Open();

            chart1.Series.Clear();
            var series1 = new Series
            {
                Name = "line",
                Color = System.Drawing.Color.Green,
                IsVisibleInLegend = false,
                IsXValueIndexed = true,
                ChartType = SeriesChartType.Line
            };

            this.chart1.Series.Add(series1);

            for (int i = 0; i < points.Count; i++)
            {
                chart1.Series["line"].Points.AddXY(points[i].X,getPointAltitude(points[i]));
            }

            chart1.Series["line"].ChartType = SeriesChartType.FastLine;
            chart1.Series["line"].Color = Color.Red;

            chart1.Invalidate();
        }

        private void Graph_Load(object sender, EventArgs e)
        {
        }

        public int getPointAltitude(PointF p)
        {
            NpgsqlCommand cmd = new NpgsqlCommand("select altitude from mnt where st_area(zone) = (SELECT Min(st_area(zone)) from mnt where st_intersects(zone,'point(" + p.X + " " + p.Y + ")'));", cnx);
            return int.Parse(cmd.ExecuteScalar().ToString());
        }

    }
}
