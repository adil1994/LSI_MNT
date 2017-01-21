namespace MNT
{
    partial class MNT
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.mapBox1 = new SharpMap.Forms.MapBox();
            this.mapZoomToolStrip1 = new SharpMap.Forms.ToolBar.MapZoomToolStrip(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.y2label = new System.Windows.Forms.Label();
            this.x2label = new System.Windows.Forms.Label();
            this.rdistancelabel = new System.Windows.Forms.Label();
            this.distancelabel = new System.Windows.Forms.Label();
            this.y1label = new System.Windows.Forms.Label();
            this.x1label = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.button1 = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // mapBox1
            // 
            this.mapBox1.ActiveTool = SharpMap.Forms.MapBox.Tools.None;
            this.mapBox1.BackColor = System.Drawing.Color.DarkGray;
            this.mapBox1.Cursor = System.Windows.Forms.Cursors.Default;
            this.mapBox1.FineZoomFactor = 10D;
            this.mapBox1.Location = new System.Drawing.Point(0, 12);
            this.mapBox1.MapQueryMode = SharpMap.Forms.MapBox.MapQueryType.LayerByIndex;
            this.mapBox1.Name = "mapBox1";
            this.mapBox1.QueryGrowFactor = 5F;
            this.mapBox1.QueryLayerIndex = 0;
            this.mapBox1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(244)))), ((int)(((byte)(244)))), ((int)(((byte)(244)))));
            this.mapBox1.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(244)))), ((int)(((byte)(244)))));
            this.mapBox1.ShowProgressUpdate = false;
            this.mapBox1.Size = new System.Drawing.Size(594, 488);
            this.mapBox1.TabIndex = 0;
            this.mapBox1.Text = "mapBox1";
            this.mapBox1.WheelZoomMagnitude = -2D;
            // 
            // mapZoomToolStrip1
            // 
            this.mapZoomToolStrip1.Enabled = false;
            this.mapZoomToolStrip1.Location = new System.Drawing.Point(0, 0);
            this.mapZoomToolStrip1.MapControl = null;
            this.mapZoomToolStrip1.Name = "mapZoomToolStrip1";
            this.mapZoomToolStrip1.Size = new System.Drawing.Size(960, 25);
            this.mapZoomToolStrip1.TabIndex = 1;
            this.mapZoomToolStrip1.Text = "mapZoomToolStrip1";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.y2label);
            this.panel1.Controls.Add(this.x2label);
            this.panel1.Controls.Add(this.rdistancelabel);
            this.panel1.Controls.Add(this.distancelabel);
            this.panel1.Controls.Add(this.y1label);
            this.panel1.Controls.Add(this.x1label);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(608, 28);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(340, 290);
            this.panel1.TabIndex = 2;
            // 
            // y2label
            // 
            this.y2label.AutoSize = true;
            this.y2label.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.y2label.Location = new System.Drawing.Point(41, 137);
            this.y2label.Name = "y2label";
            this.y2label.Size = new System.Drawing.Size(37, 17);
            this.y2label.TabIndex = 6;
            this.y2label.Text = "Y2 :";
            // 
            // x2label
            // 
            this.x2label.AutoSize = true;
            this.x2label.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.x2label.Location = new System.Drawing.Point(41, 104);
            this.x2label.Name = "x2label";
            this.x2label.Size = new System.Drawing.Size(42, 17);
            this.x2label.TabIndex = 5;
            this.x2label.Text = "X2 : ";
            // 
            // rdistancelabel
            // 
            this.rdistancelabel.AutoSize = true;
            this.rdistancelabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdistancelabel.Location = new System.Drawing.Point(41, 203);
            this.rdistancelabel.Name = "rdistancelabel";
            this.rdistancelabel.Size = new System.Drawing.Size(92, 17);
            this.rdistancelabel.TabIndex = 4;
            this.rdistancelabel.Text = "RDistance :";
            // 
            // distancelabel
            // 
            this.distancelabel.AutoSize = true;
            this.distancelabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.distancelabel.Location = new System.Drawing.Point(41, 171);
            this.distancelabel.Name = "distancelabel";
            this.distancelabel.Size = new System.Drawing.Size(81, 17);
            this.distancelabel.TabIndex = 3;
            this.distancelabel.Text = "Distance :";
            // 
            // y1label
            // 
            this.y1label.AutoSize = true;
            this.y1label.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.y1label.Location = new System.Drawing.Point(41, 74);
            this.y1label.Name = "y1label";
            this.y1label.Size = new System.Drawing.Size(37, 17);
            this.y1label.TabIndex = 2;
            this.y1label.Text = "Y1 :";
            // 
            // x1label
            // 
            this.x1label.AutoSize = true;
            this.x1label.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.x1label.Location = new System.Drawing.Point(41, 43);
            this.x1label.Name = "x1label";
            this.x1label.Size = new System.Drawing.Size(42, 17);
            this.x1label.TabIndex = 1;
            this.x1label.Text = "X1 : ";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(109, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(116, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Coordonnées";
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(608, 324);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(340, 165);
            this.dataGridView1.TabIndex = 3;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.SystemColors.Highlight;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.button1.Location = new System.Drawing.Point(83, 237);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(161, 45);
            this.button1.TabIndex = 7;
            this.button1.Text = "Plot 2D Graph";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // MNT
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(960, 501);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.mapZoomToolStrip1);
            this.Controls.Add(this.mapBox1);
            this.Name = "MNT";
            this.Text = "MNT";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MNT_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private SharpMap.Forms.MapBox mapBox1;
        private SharpMap.Forms.ToolBar.MapZoomToolStrip mapZoomToolStrip1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label y1label;
        private System.Windows.Forms.Label x1label;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label rdistancelabel;
        private System.Windows.Forms.Label distancelabel;
        private System.Windows.Forms.Label y2label;
        private System.Windows.Forms.Label x2label;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button button1;
    }
}

