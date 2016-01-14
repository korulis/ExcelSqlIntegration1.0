﻿using System;
using System.Collections.Generic;
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
using ExcelData;

namespace IntegrationApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            var doer = new ExcelFileParser(@"C:\Users\k.blazevicius\Desktop\test.xlsx");
            doer.GetDataFromSheet<MyDto>("SpecialSheetName");
            


            InitializeComponent();
            Close();

        }
    }

    public struct MyDto
    {
        public string Id;
        public string Comment;
        public decimal Amount;
        public DateTime Timestamp;
    }
}
