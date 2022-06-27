namespace EcomInspection
{
    partial class FrmMain
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint1 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(1D, 10D);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint2 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(2D, 3D);
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMain));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.Display = new System.Windows.Forms.PictureBox();
            this.panel4 = new System.Windows.Forms.Panel();
            this.PieChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.lbTaktTime = new System.Windows.Forms.ToolStripStatusLabel();
            this.btnTurnOnline = new System.Windows.Forms.Button();
            this.panel7 = new System.Windows.Forms.Panel();
            this.lbNG = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.panel6 = new System.Windows.Forms.Panel();
            this.lbOK = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.panel5 = new System.Windows.Forms.Panel();
            this.btnClearCount = new System.Windows.Forms.Button();
            this.lbTotal = new System.Windows.Forms.Label();
            this.LBASDF = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.led_Connection = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.led_OnlineStatus = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnTryConnect = new System.Windows.Forms.Button();
            this.btnSetting = new System.Windows.Forms.Button();
            this.btnLoggin = new System.Windows.Forms.Button();
            this.btnQuit = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Display)).BeginInit();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PieChart)).BeginInit();
            this.statusStrip1.SuspendLayout();
            this.panel7.SuspendLayout();
            this.panel6.SuspendLayout();
            this.panel5.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 87.71097F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.28903F));
            this.tableLayoutPanel1.Controls.Add(this.Display, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel4, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 41.06351F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1896, 950);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // Display
            // 
            this.Display.BackColor = System.Drawing.Color.Gainsboro;
            this.Display.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.Display.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Display.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Display.Location = new System.Drawing.Point(3, 3);
            this.Display.Name = "Display";
            this.Display.Size = new System.Drawing.Size(1657, 944);
            this.Display.TabIndex = 1;
            this.Display.TabStop = false;
            // 
            // panel4
            // 
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel4.Controls.Add(this.PieChart);
            this.panel4.Controls.Add(this.statusStrip1);
            this.panel4.Controls.Add(this.btnTurnOnline);
            this.panel4.Controls.Add(this.panel7);
            this.panel4.Controls.Add(this.panel6);
            this.panel4.Controls.Add(this.panel5);
            this.panel4.Controls.Add(this.label4);
            this.panel4.Controls.Add(this.led_Connection);
            this.panel4.Controls.Add(this.label3);
            this.panel4.Controls.Add(this.led_OnlineStatus);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(1666, 3);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(227, 944);
            this.panel4.TabIndex = 2;
            // 
            // PieChart
            // 
            this.PieChart.BackColor = System.Drawing.Color.Transparent;
            chartArea1.Name = "ChartArea1";
            this.PieChart.ChartAreas.Add(chartArea1);
            legend1.Alignment = System.Drawing.StringAlignment.Far;
            legend1.AutoFitMinFontSize = 5;
            legend1.LegendStyle = System.Windows.Forms.DataVisualization.Charting.LegendStyle.Column;
            legend1.Name = "Legend1";
            legend1.Position.Auto = false;
            legend1.Position.Height = 15F;
            legend1.Position.Width = 20F;
            legend1.Position.X = 80F;
            legend1.Position.Y = 85F;
            legend1.TextWrapThreshold = 2;
            this.PieChart.Legends.Add(legend1);
            this.PieChart.Location = new System.Drawing.Point(3, 151);
            this.PieChart.Name = "PieChart";
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie;
            series1.Legend = "Legend1";
            series1.Name = "Series";
            dataPoint1.AxisLabel = "";
            dataPoint1.Color = System.Drawing.Color.Green;
            dataPoint1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataPoint1.Label = "0%";
            dataPoint1.LabelForeColor = System.Drawing.Color.White;
            dataPoint2.AxisLabel = "";
            dataPoint2.Color = System.Drawing.Color.DarkRed;
            dataPoint2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataPoint2.Label = "";
            dataPoint2.LabelBackColor = System.Drawing.Color.Transparent;
            dataPoint2.LabelForeColor = System.Drawing.Color.White;
            series1.Points.Add(dataPoint1);
            series1.Points.Add(dataPoint2);
            this.PieChart.Series.Add(series1);
            this.PieChart.Size = new System.Drawing.Size(217, 205);
            this.PieChart.TabIndex = 11;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lbTaktTime});
            this.statusStrip1.Location = new System.Drawing.Point(0, 918);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(223, 22);
            this.statusStrip1.TabIndex = 10;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // lbTaktTime
            // 
            this.lbTaktTime.Name = "lbTaktTime";
            this.lbTaktTime.Size = new System.Drawing.Size(107, 17);
            this.lbTaktTime.Text = "Process Time: 0 ms";
            // 
            // btnTurnOnline
            // 
            this.btnTurnOnline.BackColor = System.Drawing.Color.Transparent;
            this.btnTurnOnline.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnTurnOnline.BackgroundImage")));
            this.btnTurnOnline.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnTurnOnline.FlatAppearance.BorderSize = 0;
            this.btnTurnOnline.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gray;
            this.btnTurnOnline.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnTurnOnline.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTurnOnline.Location = new System.Drawing.Point(64, 825);
            this.btnTurnOnline.Name = "btnTurnOnline";
            this.btnTurnOnline.Size = new System.Drawing.Size(108, 92);
            this.btnTurnOnline.TabIndex = 9;
            this.btnTurnOnline.UseVisualStyleBackColor = false;
            this.btnTurnOnline.Click += new System.EventHandler(this.btnTurnOnline_Click);
            // 
            // panel7
            // 
            this.panel7.BackColor = System.Drawing.Color.Red;
            this.panel7.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel7.Controls.Add(this.lbNG);
            this.panel7.Controls.Add(this.label9);
            this.panel7.Location = new System.Drawing.Point(14, 671);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(200, 94);
            this.panel7.TabIndex = 8;
            // 
            // lbNG
            // 
            this.lbNG.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbNG.Font = new System.Drawing.Font("Microsoft YaHei UI", 20.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbNG.ForeColor = System.Drawing.Color.GhostWhite;
            this.lbNG.Location = new System.Drawing.Point(3, 50);
            this.lbNG.Name = "lbNG";
            this.lbNG.Size = new System.Drawing.Size(189, 39);
            this.lbNG.TabIndex = 1;
            this.lbNG.Text = "0";
            this.lbNG.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft YaHei UI", 20.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.SystemColors.Control;
            this.label9.Location = new System.Drawing.Point(70, 18);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(59, 36);
            this.label9.TabIndex = 0;
            this.label9.Text = "NG";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel6
            // 
            this.panel6.BackColor = System.Drawing.Color.Green;
            this.panel6.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel6.Controls.Add(this.lbOK);
            this.panel6.Controls.Add(this.label7);
            this.panel6.Location = new System.Drawing.Point(14, 542);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(200, 94);
            this.panel6.TabIndex = 7;
            // 
            // lbOK
            // 
            this.lbOK.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbOK.Font = new System.Drawing.Font("Microsoft YaHei UI", 20.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbOK.ForeColor = System.Drawing.Color.GhostWhite;
            this.lbOK.Location = new System.Drawing.Point(3, 49);
            this.lbOK.Name = "lbOK";
            this.lbOK.Size = new System.Drawing.Size(189, 39);
            this.lbOK.TabIndex = 1;
            this.lbOK.Text = "0";
            this.lbOK.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft YaHei UI", 20.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.SystemColors.Control;
            this.label7.Location = new System.Drawing.Point(72, 18);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(56, 36);
            this.label7.TabIndex = 0;
            this.label7.Text = "OK";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.CadetBlue;
            this.panel5.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel5.Controls.Add(this.btnClearCount);
            this.panel5.Controls.Add(this.lbTotal);
            this.panel5.Controls.Add(this.LBASDF);
            this.panel5.Location = new System.Drawing.Point(14, 428);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(200, 94);
            this.panel5.TabIndex = 6;
            // 
            // btnClearCount
            // 
            this.btnClearCount.BackColor = System.Drawing.Color.Transparent;
            this.btnClearCount.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnClearCount.BackgroundImage")));
            this.btnClearCount.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnClearCount.FlatAppearance.BorderSize = 0;
            this.btnClearCount.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gray;
            this.btnClearCount.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnClearCount.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClearCount.Location = new System.Drawing.Point(167, -2);
            this.btnClearCount.Name = "btnClearCount";
            this.btnClearCount.Size = new System.Drawing.Size(31, 28);
            this.btnClearCount.TabIndex = 6;
            this.btnClearCount.UseVisualStyleBackColor = false;
            this.btnClearCount.Click += new System.EventHandler(this.btnClearCount_Click);
            // 
            // lbTotal
            // 
            this.lbTotal.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbTotal.Font = new System.Drawing.Font("Microsoft YaHei UI", 20.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTotal.ForeColor = System.Drawing.Color.GhostWhite;
            this.lbTotal.Location = new System.Drawing.Point(4, 51);
            this.lbTotal.Name = "lbTotal";
            this.lbTotal.Size = new System.Drawing.Size(189, 39);
            this.lbTotal.TabIndex = 1;
            this.lbTotal.Text = "0";
            this.lbTotal.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // LBASDF
            // 
            this.LBASDF.AutoSize = true;
            this.LBASDF.Font = new System.Drawing.Font("Microsoft YaHei UI", 20.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LBASDF.ForeColor = System.Drawing.SystemColors.Control;
            this.LBASDF.Location = new System.Drawing.Point(50, 22);
            this.LBASDF.Name = "LBASDF";
            this.LBASDF.Size = new System.Drawing.Size(106, 36);
            this.LBASDF.TabIndex = 0;
            this.LBASDF.Text = "TOTAL";
            this.LBASDF.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.OliveDrab;
            this.label4.Location = new System.Drawing.Point(41, 5);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(123, 20);
            this.label4.TabIndex = 5;
            this.label4.Text = "CONNECTION";
            // 
            // led_Connection
            // 
            this.led_Connection.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("led_Connection.BackgroundImage")));
            this.led_Connection.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.led_Connection.Enabled = false;
            this.led_Connection.FlatAppearance.BorderSize = 0;
            this.led_Connection.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.led_Connection.Location = new System.Drawing.Point(8, 4);
            this.led_Connection.Name = "led_Connection";
            this.led_Connection.Size = new System.Drawing.Size(27, 24);
            this.led_Connection.TabIndex = 4;
            this.led_Connection.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.OliveDrab;
            this.label3.Location = new System.Drawing.Point(41, 36);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(148, 20);
            this.label3.TabIndex = 1;
            this.label3.Text = "ONLINE STATUS";
            // 
            // led_OnlineStatus
            // 
            this.led_OnlineStatus.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("led_OnlineStatus.BackgroundImage")));
            this.led_OnlineStatus.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.led_OnlineStatus.Enabled = false;
            this.led_OnlineStatus.FlatAppearance.BorderSize = 0;
            this.led_OnlineStatus.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.led_OnlineStatus.Location = new System.Drawing.Point(8, 35);
            this.led_OnlineStatus.Name = "led_OnlineStatus";
            this.led_OnlineStatus.Size = new System.Drawing.Size(27, 24);
            this.led_OnlineStatus.TabIndex = 0;
            this.led_OnlineStatus.UseVisualStyleBackColor = true;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1910, 982);
            this.tabControl1.TabIndex = 1;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.tableLayoutPanel1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1902, 956);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "AUTO";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Controls.Add(this.panel2, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.panel3, 0, 1);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8.148149F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 91.85185F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(1920, 1080);
            this.tableLayoutPanel2.TabIndex = 2;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnTryConnect);
            this.panel2.Controls.Add(this.btnSetting);
            this.panel2.Controls.Add(this.btnLoggin);
            this.panel2.Controls.Add(this.btnQuit);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.pictureBox1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(3, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1914, 82);
            this.panel2.TabIndex = 2;
            // 
            // btnTryConnect
            // 
            this.btnTryConnect.BackColor = System.Drawing.Color.Transparent;
            this.btnTryConnect.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnTryConnect.BackgroundImage")));
            this.btnTryConnect.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnTryConnect.FlatAppearance.BorderSize = 0;
            this.btnTryConnect.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gray;
            this.btnTryConnect.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnTryConnect.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTryConnect.Location = new System.Drawing.Point(350, 14);
            this.btnTryConnect.Name = "btnTryConnect";
            this.btnTryConnect.Size = new System.Drawing.Size(69, 54);
            this.btnTryConnect.TabIndex = 5;
            this.btnTryConnect.UseVisualStyleBackColor = false;
            this.btnTryConnect.Click += new System.EventHandler(this.btnTryConnect_Click);
            // 
            // btnSetting
            // 
            this.btnSetting.BackColor = System.Drawing.Color.Transparent;
            this.btnSetting.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSetting.BackgroundImage")));
            this.btnSetting.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnSetting.FlatAppearance.BorderSize = 0;
            this.btnSetting.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gray;
            this.btnSetting.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnSetting.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSetting.Location = new System.Drawing.Point(269, 9);
            this.btnSetting.Name = "btnSetting";
            this.btnSetting.Size = new System.Drawing.Size(75, 64);
            this.btnSetting.TabIndex = 4;
            this.btnSetting.UseVisualStyleBackColor = false;
            this.btnSetting.Click += new System.EventHandler(this.btnSetting_Click);
            // 
            // btnLoggin
            // 
            this.btnLoggin.BackColor = System.Drawing.Color.Transparent;
            this.btnLoggin.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnLoggin.BackgroundImage")));
            this.btnLoggin.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnLoggin.FlatAppearance.BorderSize = 0;
            this.btnLoggin.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gray;
            this.btnLoggin.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnLoggin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLoggin.Location = new System.Drawing.Point(184, 9);
            this.btnLoggin.Name = "btnLoggin";
            this.btnLoggin.Size = new System.Drawing.Size(75, 64);
            this.btnLoggin.TabIndex = 3;
            this.btnLoggin.UseVisualStyleBackColor = false;
            this.btnLoggin.Click += new System.EventHandler(this.btnLoggin_Click);
            // 
            // btnQuit
            // 
            this.btnQuit.BackColor = System.Drawing.Color.Transparent;
            this.btnQuit.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnQuit.BackgroundImage")));
            this.btnQuit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnQuit.FlatAppearance.BorderSize = 0;
            this.btnQuit.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gray;
            this.btnQuit.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnQuit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnQuit.Location = new System.Drawing.Point(1826, 9);
            this.btnQuit.Name = "btnQuit";
            this.btnQuit.Size = new System.Drawing.Size(75, 64);
            this.btnQuit.TabIndex = 2;
            this.btnQuit.UseVisualStyleBackColor = false;
            this.btnQuit.Click += new System.EventHandler(this.btnQuit_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft YaHei UI", 36F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.label2.Location = new System.Drawing.Point(720, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(728, 64);
            this.label2.TabIndex = 1;
            this.label2.Text = "VISION INSPECTION SYSTEM";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.BackgroundImage")));
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Left;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(160, 82);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel3.Controls.Add(this.tabControl1);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(3, 91);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1914, 986);
            this.panel3.TabIndex = 3;
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1920, 1080);
            this.Controls.Add(this.tableLayoutPanel2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Main";
            this.Load += new System.EventHandler(this.FrmMain_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Display)).EndInit();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PieChart)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.panel7.ResumeLayout(false);
            this.panel7.PerformLayout();
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.PictureBox Display;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnQuit;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button led_OnlineStatus;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button led_Connection;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Label lbNG;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Label lbOK;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Label lbTotal;
        private System.Windows.Forms.Label LBASDF;
        private System.Windows.Forms.Button btnTurnOnline;
        private System.Windows.Forms.Button btnSetting;
        private System.Windows.Forms.Button btnLoggin;
        private System.Windows.Forms.Button btnTryConnect;
        private System.Windows.Forms.Button btnClearCount;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel lbTaktTime;
        private System.Windows.Forms.DataVisualization.Charting.Chart PieChart;
    }
}

