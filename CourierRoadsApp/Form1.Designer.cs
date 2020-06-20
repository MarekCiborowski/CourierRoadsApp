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
            this.LoadFileButton = new System.Windows.Forms.Button();
            this.FileTypeComboBox = new System.Windows.Forms.ComboBox();
            this.HeuristicTypeComboBox = new System.Windows.Forms.ComboBox();
            this.HeuristicTypeLabel = new System.Windows.Forms.Label();
            this.CalculateRouteButton = new System.Windows.Forms.Button();
            this.FileTypeLabel = new System.Windows.Forms.Label();
            this.StatisticsButton = new System.Windows.Forms.Button();
            this.StartingCityTextBox = new System.Windows.Forms.TextBox();
            this.StartingCityLabel = new System.Windows.Forms.Label();
            this.HideMarkersButton = new System.Windows.Forms.Button();
            this.MPPCityFromTextBox = new System.Windows.Forms.TextBox();
            this.MPPCityToTextBox = new System.Windows.Forms.TextBox();
            this.MPPCityFromLabel = new System.Windows.Forms.Label();
            this.MPPCityToLabel = new System.Windows.Forms.Label();
            this.MaxPossiblePathsButton = new System.Windows.Forms.Button();
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
            this.CalculateRouteButton.Location = new System.Drawing.Point(696, 184);
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
            // StatisticsButton
            // 
            this.StatisticsButton.Location = new System.Drawing.Point(667, 215);
            this.StatisticsButton.Name = "StatisticsButton";
            this.StatisticsButton.Size = new System.Drawing.Size(75, 23);
            this.StatisticsButton.TabIndex = 9;
            this.StatisticsButton.Text = "Statistics";
            this.StatisticsButton.UseVisualStyleBackColor = true;
            this.StatisticsButton.Visible = false;
            this.StatisticsButton.Click += new System.EventHandler(this.StatisticsButton_Click);
            // 
            // StartingCityTextBox
            // 
            this.StartingCityTextBox.Location = new System.Drawing.Point(640, 186);
            this.StartingCityTextBox.Name = "StartingCityTextBox";
            this.StartingCityTextBox.Size = new System.Drawing.Size(50, 20);
            this.StartingCityTextBox.TabIndex = 10;
            this.StartingCityTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // StartingCityLabel
            // 
            this.StartingCityLabel.AutoSize = true;
            this.StartingCityLabel.Location = new System.Drawing.Point(571, 189);
            this.StartingCityLabel.Name = "StartingCityLabel";
            this.StartingCityLabel.Size = new System.Drawing.Size(63, 13);
            this.StartingCityLabel.TabIndex = 11;
            this.StartingCityLabel.Text = "Starting City";
            // 
            // HideMarkersButton
            // 
            this.HideMarkersButton.Location = new System.Drawing.Point(572, 215);
            this.HideMarkersButton.Name = "HideMarkersButton";
            this.HideMarkersButton.Size = new System.Drawing.Size(89, 23);
            this.HideMarkersButton.TabIndex = 12;
            this.HideMarkersButton.Text = "Switch Markers";
            this.HideMarkersButton.UseVisualStyleBackColor = true;
            this.HideMarkersButton.Visible = false;
            this.HideMarkersButton.Click += new System.EventHandler(this.HideMarkersButton_Click);
            // 
            // MPPCityFromTextBox
            // 
            this.MPPCityFromTextBox.Location = new System.Drawing.Point(632, 304);
            this.MPPCityFromTextBox.Name = "MPPCityFromTextBox";
            this.MPPCityFromTextBox.Size = new System.Drawing.Size(40, 20);
            this.MPPCityFromTextBox.TabIndex = 13;
            this.MPPCityFromTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // MPPCityToTextBox
            // 
            this.MPPCityToTextBox.Location = new System.Drawing.Point(632, 343);
            this.MPPCityToTextBox.Name = "MPPCityToTextBox";
            this.MPPCityToTextBox.Size = new System.Drawing.Size(40, 20);
            this.MPPCityToTextBox.TabIndex = 14;
            this.MPPCityToTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // MPPCityFromLabel
            // 
            this.MPPCityFromLabel.AutoSize = true;
            this.MPPCityFromLabel.Location = new System.Drawing.Point(576, 307);
            this.MPPCityFromLabel.Name = "MPPCityFromLabel";
            this.MPPCityFromLabel.Size = new System.Drawing.Size(50, 13);
            this.MPPCityFromLabel.TabIndex = 15;
            this.MPPCityFromLabel.Text = "City From";
            // 
            // MPPCityToLabel
            // 
            this.MPPCityToLabel.AutoSize = true;
            this.MPPCityToLabel.Location = new System.Drawing.Point(583, 346);
            this.MPPCityToLabel.Name = "MPPCityToLabel";
            this.MPPCityToLabel.Size = new System.Drawing.Size(40, 13);
            this.MPPCityToLabel.TabIndex = 16;
            this.MPPCityToLabel.Text = "City To";
            // 
            // MaxPossiblePathsButton
            // 
            this.MaxPossiblePathsButton.Enabled = false;
            this.MaxPossiblePathsButton.Location = new System.Drawing.Point(678, 304);
            this.MaxPossiblePathsButton.Name = "MaxPossiblePathsButton";
            this.MaxPossiblePathsButton.Size = new System.Drawing.Size(75, 59);
            this.MaxPossiblePathsButton.TabIndex = 17;
            this.MaxPossiblePathsButton.Text = "Max Possible Paths";
            this.MaxPossiblePathsButton.UseVisualStyleBackColor = true;
            this.MaxPossiblePathsButton.Click += new System.EventHandler(this.MaxPossiblePathsButton_Click);
            // 
            // CourierRoadsAppForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.MaxPossiblePathsButton);
            this.Controls.Add(this.MPPCityToLabel);
            this.Controls.Add(this.MPPCityFromLabel);
            this.Controls.Add(this.MPPCityToTextBox);
            this.Controls.Add(this.MPPCityFromTextBox);
            this.Controls.Add(this.HideMarkersButton);
            this.Controls.Add(this.StartingCityLabel);
            this.Controls.Add(this.StartingCityTextBox);
            this.Controls.Add(this.StatisticsButton);
            this.Controls.Add(this.FileTypeLabel);
            this.Controls.Add(this.CalculateRouteButton);
            this.Controls.Add(this.HeuristicTypeLabel);
            this.Controls.Add(this.HeuristicTypeComboBox);
            this.Controls.Add(this.FileTypeComboBox);
            this.Controls.Add(this.LoadFileButton);
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
        private System.Windows.Forms.Button LoadFileButton;
        private System.Windows.Forms.ComboBox FileTypeComboBox;
        private System.Windows.Forms.ComboBox HeuristicTypeComboBox;
        private System.Windows.Forms.Label HeuristicTypeLabel;
        private System.Windows.Forms.Button CalculateRouteButton;
        private System.Windows.Forms.Label FileTypeLabel;
        private System.Windows.Forms.Button StatisticsButton;
        private System.Windows.Forms.TextBox StartingCityTextBox;
        private System.Windows.Forms.Label StartingCityLabel;
        private System.Windows.Forms.Button HideMarkersButton;
        private System.Windows.Forms.TextBox MPPCityFromTextBox;
        private System.Windows.Forms.TextBox MPPCityToTextBox;
        private System.Windows.Forms.Label MPPCityFromLabel;
        private System.Windows.Forms.Label MPPCityToLabel;
        private System.Windows.Forms.Button MaxPossiblePathsButton;
    }
}

