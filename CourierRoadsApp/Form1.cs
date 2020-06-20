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
using Helpers.Structures;

namespace CourierRoadsApp
{
    public partial class CourierRoadsAppForm : Form
    {
        private const string MARKERS_OVERLAY_NAME = "markers";
        private const string ROUTE_OVERLAY_NAME = "route";

        private FileTypeEnum currentFileType = FileTypeEnum.CityList;
        private HeuristicTypeEnum currentHeuristic = HeuristicTypeEnum.ILS;
        private CourierPath currentPath = null;
        private Dictionary<int, City> loadedDataWithoutFill = null;
        private Dictionary<int, City> loadedData = null;
        private int startingCityId = 1;

        private Dictionary<int, City> dataForMaxPossiblePaths = null;

        private int maximumPathsCityFromId = 1;
        private int maximumPathsCiyToId = 2;

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

            gmap.MinZoom = 2;
            gmap.MaxZoom = 17;
            gmap.Zoom = 6;
            gmap.MouseWheelZoomType = MouseWheelZoomType.MousePositionAndCenter;
            gmap.CanDragMap = true;
            gmap.DragButton = MouseButtons.Left;
        }

        private void LoadFileButton_Click(object sender, EventArgs e)
        {
            var openFileDialog = new OpenFileDialog();

            openFileDialog.DefaultExt = ".txt";
            openFileDialog.Filter = "Text Files (*.txt)|*.txt";
            openFileDialog.Multiselect = true;

            var result = openFileDialog.ShowDialog();

            if (result == DialogResult.OK)
            {
                var filePaths = openFileDialog.FileNames;

                var isAnyDataLoaded = false;
                try
                {
                    switch (currentFileType)
                    {
                        case FileTypeEnum.CityList:
                            {
                                if (filePaths.Length != 2)
                                {
                                    ShowErrorForFileLoading("Please supply: \n1. City List, \n2. City Connections List");
                                    return;
                                }
                                loadedData = FileLoader.LoadCitiesFromCityFiles(filePaths[0], filePaths[1]);
                                loadedDataWithoutFill = FileLoader.CreateCopy(loadedData);
                                
                                ShortestPathHelper.FillRealDistances(loadedData);
                            }
                            break;
                        case FileTypeEnum.GeneratedPoints:
                            {
                                var filePathToLoad = filePaths[0];
                                loadedData = FileLoader.LoadCitiesFromTestFile(filePathToLoad);
                                ShortestPathHelper.FillEuclideanDistances(loadedData);
                            }
                            break;
                        default:
                            break;
                    }

                    isAnyDataLoaded = loadedData.Any();
                }
                catch (Exception exception)
                {
                    ShowErrorForFileLoading(exception.Message);
                    return;
                }

                CalculateRouteButton.Enabled = isAnyDataLoaded;
                MaxPossiblePathsButton.Enabled = isAnyDataLoaded || currentFileType == FileTypeEnum.CityList;
            }
        }

        private void ShowErrorForFileLoading(string message)
        {
            MessageBox.Show($"Error loading file:\n{message}", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            CalculateRouteButton.Enabled = false;
        }

        private void CalculateRouteButton_Click(object sender, EventArgs e)
        {
            MainHelper mainHelper = new MainHelper(loadedData);

            if (!int.TryParse(StartingCityTextBox.Text, out startingCityId) || startingCityId > loadedData.Count)
            {
                startingCityId = 1;
            }

            switch (currentHeuristic)
            {
                case HeuristicTypeEnum.ILS:
                    currentPath = mainHelper.ILS(startingCityId);
                    RedrawMap();
                    break;
                case HeuristicTypeEnum.VNS:
                    currentPath = mainHelper.Basic_VNS(startingCityId);
                    RedrawMap();
                    break;
                default:
                    break;
            }

            StatisticsButton.Visible = true;
            HideMarkersButton.Visible = true;
        }

        private void FileTypeComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            Enum.TryParse(FileTypeComboBox.SelectedValue.ToString(), out currentFileType);
        }

        private void HeuristicTypeComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            Enum.TryParse(HeuristicTypeComboBox.SelectedValue.ToString(), out currentHeuristic);
        }

        private void RedrawMap()
        {
            ClearMap();
            DrawRoute();
        }

        private void DrawRoute()
        {
            var pathToDraw = currentPath.GetPathInReadableForm();

            if (!pathToDraw.Any())
            {
                return;
            }

            var routeOverlay = new GMapOverlay(ROUTE_OVERLAY_NAME);
            var markersOverlay = new GMapOverlay(MARKERS_OVERLAY_NAME);
            var routePoints = new List<PointLatLng>();

            foreach (var city in pathToDraw)
            {
                var currentCityLatLng = GetLocationDependingOnFileType(city);
                var currentCityMarker = new GMarkerGoogle(currentCityLatLng, GMarkerGoogleType.white_small);
                currentCityMarker.ToolTipText = $"ID: {city.CityId}\n" +
                    (string.IsNullOrEmpty(city.Name) ? "" : $"Name: {city.Name }\n") +
                    $"Package Weight: {city.PackageWeigth}"; 

                routePoints.Add(currentCityLatLng);
                markersOverlay.Markers.Add(currentCityMarker);
                //routeOverlay.Markers.Add(currentCityMarker);
            }

            var mapRoute = new GMapRoute(routePoints, "Calculated Path");
            mapRoute.Stroke = new Pen(Color.Red, 2);
            routeOverlay.Routes.Add(mapRoute);

            gmap.Overlays.Add(routeOverlay);
            gmap.Overlays.Add(markersOverlay);
            gmap.Refresh();
        }

        private void ClearMap()
        {
            gmap.Overlays.Clear();
            gmap.Refresh();
        }

        private PointLatLng GetLocationDependingOnFileType(City city)
        {
            float latitude = 0;
            float longtitude = 0;

            switch (currentFileType)
            {
                case FileTypeEnum.CityList:
                    latitude = city.CoordinateY;
                    longtitude = city.CoordinateX;
                    break;
                case FileTypeEnum.GeneratedPoints:
                    latitude = city.CoordinateY / 100;
                    longtitude = city.CoordinateX / 100;
                    break;
                default:
                    break;
            }
            return new PointLatLng(latitude, longtitude);
        }

        private void StatisticsButton_Click(object sender, EventArgs e)
        {
            MessageBox.Show($"Statistics:\nPath length: {currentPath.GetTotalLengthOfPath().ToString()}" +
                $"\nTime taken: {Statistics.LastExecutionTimeMiliSeconds}ms", "Statistics", MessageBoxButtons.OK);
        }

        private void HideMarkersButton_Click(object sender, EventArgs e)
        {
            var routesOverlay = gmap.Overlays.First(o => o.Id == MARKERS_OVERLAY_NAME);

            routesOverlay.IsVisibile = !routesOverlay.IsVisibile;
        }

        private void MaxPossiblePathsButton_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(MPPCityFromTextBox.Text, out maximumPathsCityFromId) || maximumPathsCityFromId > loadedData.Count)
            {
                maximumPathsCityFromId = 1;
            }
            if (!int.TryParse(MPPCityToTextBox.Text, out maximumPathsCiyToId) || maximumPathsCiyToId > loadedData.Count)
            {
                maximumPathsCiyToId = 2;
            }

            var maxPaths = MaxPossiblePathsHelper.GetMaxPossiblePathsAmount(maximumPathsCityFromId, maximumPathsCiyToId, loadedDataWithoutFill);
            
            MessageBox.Show($"Maximum Paths: {maxPaths}", "Maximum Paths", MessageBoxButtons.OK);
        }
    }
}
