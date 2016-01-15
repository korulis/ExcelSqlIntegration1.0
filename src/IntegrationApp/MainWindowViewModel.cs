using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegrationApp
{
    public class MainWindowViewModel
    {
        public RelayCommand<string> WindowCommand { get; private set; }
        private AppExecutor _applicationExecutor;

        public MainWindowViewModel(AppExecutor applicationExecutor)
        {
            WindowCommand = new RelayCommand<string>(ExecuteCommand);
            _applicationExecutor = applicationExecutor;
        }

        public MainWindowViewModel():this(new AppExecutor())
        {
        }

        private void ExecuteCommand(string command)
        {
            _applicationExecutor.Execute();
            switch (command)
            {
//                case "orderPrep":
//                    CurrentViewModel = _orderPrepViewModel;
//                    break;
//                case "customers":
//                default:
//                    CurrentViewModel = _customerListViewModel;
//                    break;
            }
        }

    }
}
