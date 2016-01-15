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
        private AppExecutor _app;

        public App()
        {
            _app = new AppExecutor();
        }

        protected override void OnStartup(StartupEventArgs e)
        {

            base.OnStartup(e);
            _app.Execute();
        }

    }
}
