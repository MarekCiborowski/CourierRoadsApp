namespace CourierRoadsApp
{
    partial class CourierRoadsAppForm
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
            this.gmap = new GMap.NET.WindowsForms.GMapControl();
            this.CreateRouteButton = new System.Windows.Forms.Button();
            this.ClearRouteButton = new System.Windows.Forms.Button();
            this.LoadFileButton = new System.Windows.Forms.Button();
            this.FileTypeComboBox = new System.Windows.Forms.ComboBox();
            this.HeuristicTypeComboBox = new System.Windows.Forms.ComboBox();
            this.HeuristicTypeLabel = new System.Windows.Forms.Label();
            this.CalculateRouteButton = new System.Windows.Forms.Button();
            this.FileTypeLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // gmap
            // 
            this.gmap.Bearing = 0F;
            this.gmap.CanDragMap = true;
            this.gmap.EmptyTileColor = System.Drawing.Color.Navy;
            this.gmap.GrayScaleMode = false;
            this.gmap.HelperLineOption = GMap.NET.WindowsForms.HelperLineOptions.DontShow;
            this.gmap.LevelsKeepInMemory = 5;
            this.gmap.Location = new System.Drawing.Point(12, 12);
            this.gmap.MarkersEnabled = true;
            this.gmap.MaxZoom = 2;
            this.gmap.MinZoom = 2;
            this.gmap.MouseWheelZoomEnabled = true;
            this.gmap.MouseWheelZoomType = GMap.NET.MouseWheelZoomType.MousePositionAndCenter;
            this.gmap.Name = "gmap";
            this.gmap.NegativeMode = false;
            this.gmap.PolygonsEnabled = true;
            this.gmap.RetryLoadTile = 0;
            this.gmap.RoutesEnabled = true;
            this.gmap.ScaleMode = GMap.NET.WindowsForms.ScaleModes.Integer;
            this.gmap.SelectedAreaFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(65)))), ((int)(((byte)(105)))), ((int)(((byte)(225)))));
            this.gmap.ShowTileGridLines = false;
            this.gmap.Size = new System.Drawing.Size(554, 426);
            this.gmap.TabIndex = 0;
            this.gmap.Zoom = 0D;
            // 
            // CreateRouteButton
            // 
            this.CreateRouteButton.Location = new System.Drawing.Point(572, 393);
            this.CreateRouteButton.Name = "CreateRouteButton";
            this.CreateRouteButton.Size = new System.Drawing.Size(94, 23);
            this.CreateRouteButton.TabIndex = 1;
            this.CreateRouteButton.Text = "Create Route";
            this.CreateRouteButton.UseVisualStyleBackColor = true;
            this.CreateRouteButton.Click += new System.EventHandler(this.CreateRouteButton_Click);
            // 
            // ClearRouteButton
            // 
            this.ClearRouteButton.Location = new System.Drawing.Point(572, 423);
            this.ClearRouteButton.Name = "ClearRouteButton";
            this.ClearRouteButton.Size = new System.Drawing.Size(94, 25);
            this.ClearRouteButton.TabIndex = 2;
            this.ClearRouteButton.Text = "Clear Route";
            this.ClearRouteButton.UseVisualStyleBackColor = true;
            this.ClearRouteButton.Click += new System.EventHandler(this.ClearRouteButton_Click);
            // 
            // LoadFileButton
            // 
            this.LoadFileButton.Location = new System.Drawing.Point(713, 65);
            this.LoadFileButton.Name = "LoadFileButton";
            this.LoadFileButton.Size = new System.Drawing.Size(75, 23);
            this.LoadFileButton.TabIndex = 3;
            this.LoadFileButton.Text = "Load File";
            this.LoadFileButton.UseVisualStyleBackColor = true;
            this.LoadFileButton.Click += new System.EventHandler(this.LoadFileButton_Click);
            // 
            // FileTypeComboBox
            // 
            this.FileTypeComboBox.FormattingEnabled = true;
            this.FileTypeComboBox.Location = new System.Drawing.Point(586, 65);
            this.FileTypeComboBox.Name = "FileTypeComboBox";
            this.FileTypeComboBox.Size = new System.Drawing.Size(121, 21);
            this.FileTypeComboBox.TabIndex = 4;
            this.FileTypeComboBox.SelectedIndexChanged += new System.EventHandler(this.FileTypeComboBox_SelectedIndexChanged);
            // 
            // HeuristicTypeComboBox
            // 
            this.HeuristicTypeComboBox.FormattingEnabled = true;
            this.HeuristicTypeComboBox.Location = new System.Drawing.Point(632, 135);
            this.HeuristicTypeComboBox.Name = "HeuristicTypeComboBox";
            this.HeuristicTypeComboBox.Size = new System.Drawing.Size(121, 21);
            this.HeuristicTypeComboBox.TabIndex = 5;
            this.HeuristicTypeComboBox.SelectedIndexChanged += new System.EventHandler(this.HeuristicTypeComboBox_SelectedIndexChanged);
            // 
            // HeuristicTypeLabel
            // 
            this.HeuristicTypeLabel.AutoSize = true;
            this.HeuristicTypeLabel.Location = new System.Drawing.Point(654, 119);
            this.HeuristicTypeLabel.Name = "HeuristicTypeLabel";
            this.HeuristicTypeLabel.Size = new System.Drawing.Size(75, 13);
            this.HeuristicTypeLabel.TabIndex = 6;
            this.HeuristicTypeLabel.Text = "Heuristic Type";
            // 
            // CalculateRouteButton
            // 
            this.CalculateRouteButton.Enabled = false;
            this.CalculateRouteButton.Location = new System.Drawing.Point(645, 186);
            this.CalculateRouteButton.Name = "CalculateRouteButton";
            this.CalculateRouteButton.Size = new System.Drawing.Size(99, 23);
            this.CalculateRouteButton.TabIndex = 7;
            this.CalculateRouteButton.Text = "CalculateRoute";
            this.CalculateRouteButton.UseVisualStyleBackColor = true;
            this.CalculateRouteButton.Click += new System.EventHandler(this.CalculateRouteButton_Click);
            // 
            // FileTypeLabel
            // 
            this.FileTypeLabel.AutoSize = true;
            this.FileTypeLabel.Location = new System.Drawing.Point(583, 49);
            this.FileTypeLabel.Name = "FileTypeLabel";
            this.FileTypeLabel.Size = new System.Drawing.Size(50, 13);
            this.FileTypeLabel.TabIndex = 8;
            this.FileTypeLabel.Text = "File Type";
            // 
            // CourierRoadsAppForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.FileTypeLabel);
            this.Controls.Add(this.CalculateRouteButton);
            this.Controls.Add(this.HeuristicTypeLabel);
            this.Controls.Add(this.HeuristicTypeComboBox);
            this.Controls.Add(this.FileTypeComboBox);
            this.Controls.Add(this.LoadFileButton);
            this.Controls.Add(this.ClearRouteButton);
            this.Controls.Add(this.CreateRouteButton);
            this.Controls.Add(this.gmap);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "CourierRoadsAppForm";
            this.Text = "CourierRoadsApp";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GMap.NET.WindowsForms.GMapControl gmap;
        private System.Windows.Forms.Button CreateRouteButton;
        private System.Windows.Forms.Button ClearRouteButton;
        private System.Windows.Forms.Button LoadFileButton;
        private System.Windows.Forms.ComboBox FileTypeComboBox;
        private System.Windows.Forms.ComboBox HeuristicTypeComboBox;
        private System.Windows.Forms.Label HeuristicTypeLabel;
        private System.Windows.Forms.Button CalculateRouteButton;
        private System.Windows.Forms.Label FileTypeLabel;
    }
}

