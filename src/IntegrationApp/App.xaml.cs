using System;
using System.Configuration;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Windows;
using ExcelData;
using SqlData;

namespace IntegrationApp
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private readonly AppExecutor _app;

        public App()
        {
            _app = new AppExecutor();
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            //compose (and activate?) application ui
            var mainWindow = new MainWindow(new MainWindowViewModel(_app));
            //activate application ui
            mainWindow.Show();
        }

    }
}
