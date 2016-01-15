using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegrationApp
{
    internal class MainWindowViewModel
    {
        public RelayCommand<string> WindowCommand { get; private set; }

        public MainWindowViewModel()
        {
            WindowCommand = new RelayCommand<string>(ExecuteCommand);
        }

        private void ExecuteCommand(string command)
        {
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
