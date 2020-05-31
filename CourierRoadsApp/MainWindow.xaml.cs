﻿using Helpers;
using Helpers.Structures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CourierRoadsApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Dictionary<int, City> citiesDictionary;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var fileName = FileName.Text;
            citiesDictionary = FileLoader.LoadCitiesFromTestFile(fileName);
            citiesDictionary = ShortestPathHelper.FillEuclideanDistances(citiesDictionary);
            var x = 0;
        }

    }
}