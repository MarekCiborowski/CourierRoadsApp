using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GMap.NET;
using GMap.NET.WindowsForms;
using GMap.NET.WindowsForms.Markers;
using GMap.NET.MapProviders;
using CourierRoadsApp.Enums;
using Helpers;
using CourierPath = Helpers.Structures.Path;

namespace CourierRoadsApp
{
    public partial class CourierRoadsAppForm : Form
    {
        FileTypeEnum currentFileType = FileTypeEnum.CityList;
        HeuristicTypeEnum currentHeuristic = HeuristicTypeEnum.ILS;
        CourierPath currentPath = null;

        public CourierRoadsAppForm()
        {
            InitializeComponent();
            FileTypeComboBox.DataSource = Enum.GetValues(typeof(FileTypeEnum));
            FileTypeComboBox.SelectedIndex = 0;
            HeuristicTypeComboBox.DataSource = Enum.GetValues(typeof(HeuristicTypeEnum));
            HeuristicTypeComboBox.SelectedIndex = 0;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            gmap.MapProvider = GoogleMapProvider.Instance;
            GMaps.Instance.Mode = AccessMode.ServerOnly;
            gmap.Position = new PointLatLng(52.069325, 19.480309);
            gmap.ShowCenter = false;

            gmap.MinZoom = 6;
            gmap.MaxZoom = 17;
            gmap.Zoom = 4;
            gmap.MouseWheelZoomType = MouseWheelZoomType.MousePositionAndCenter;
            gmap.CanDragMap = true;
            gmap.DragButton = MouseButtons.Left;
        }

        private void LoadFileButton_Click(object sender, EventArgs e)
        {
            var openFileDialog = new OpenFileDialog();

            openFileDialog.DefaultExt = ".txt";
            openFileDialog.Filter = "Text Files (*.txt)|*.txt";

            var result = openFileDialog.ShowDialog();

            if (result == DialogResult.OK)
            {
                var filePath = openFileDialog.FileName;

                var isCalculateRouteEnabled = false;
                try
                {
                    // HERE OPTIONS DEPENDING ON FILE TYPE
                    var loadedData = FileLoader.LoadCitiesFromTestFile(filePath);

                    isCalculateRouteEnabled = loadedData.Any();
                }
                catch (Exception exception)
                {
                    MessageBox.Show($"Error loading file:\n{exception.Message}", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    CalculateRouteButton.Enabled = false;
                    return;
                }

                CalculateRouteButton.Enabled = isCalculateRouteEnabled;
            }
        }

        private void CalculateRouteButton_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void FileTypeComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            Enum.TryParse(FileTypeComboBox.SelectedValue.ToString(), out currentFileType);
        }

        private void HeuristicTypeComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            Enum.TryParse(HeuristicTypeComboBox.SelectedValue.ToString(), out currentHeuristic);
        }

        private void DrawRoute()
        {
            var pathToDraw = currentPath.GetPathInReadableForm();

            var routeOverlay = new GMapOverlay("route");
            var routePoints = new List<PointLatLng>();

            foreach (var city in pathToDraw)
            {
                var latitude = city.CoordinateY;
                var longtitude = city.CoordinateX;

                var currentCityLatLng = new PointLatLng(latitude, longtitude);
                var currentCityMarker = new GMarkerGoogle(currentCityLatLng, GMarkerGoogleType.blue_pushpin);
                currentCityMarker.ToolTipText = $"{city.Name}\n{city.PackageWeigth}"; 

                routePoints.Add(currentCityLatLng);
                routeOverlay.Markers.Add(currentCityMarker);
            }

            var mapRoute = new GMapRoute(routePoints, "Calculated Path");
            mapRoute.Stroke = new Pen(Color.Red, 2);
            routeOverlay.Routes.Add(mapRoute);

            gmap.Overlays.Add(routeOverlay);
            gmap.Refresh();
        }

        private void CreateRouteButton_Click(object sender, EventArgs e)
        {
            var routeOverlay = new GMapOverlay("route");

            var routePoints = new List<PointLatLng>();
            routePoints.Add(new PointLatLng(52.429855, 16.877080));
            routePoints.Add(new PointLatLng(50.052931, 19.968094));
            routePoints.Add(new PointLatLng(54.358358, 18.650220));
            routePoints.Add(new PointLatLng(52.232178, 20.998432));

            GMapRoute gMapRoute = new GMapRoute(routePoints, "Fajna trasa");
            gMapRoute.Stroke = new Pen(Color.Red, 3);
            routeOverlay.Routes.Add(gMapRoute);

            var marker = new GMarkerGoogle(
                new PointLatLng(52.429855, 16.877080),
                GMarkerGoogleType.blue_pushpin);

            marker.ToolTipText = "Dupa";

            routeOverlay.Markers.Add(marker);

            gmap.Overlays.Add(routeOverlay);
            gmap.Refresh();
        }

        private void ClearRouteButton_Click(object sender, EventArgs e)
        {
            gmap.Overlays.Clear();
            gmap.Refresh();
        }
    }
}
