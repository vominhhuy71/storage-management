using MVVMApp.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MVVMApp.Commands
{
    public class ItemUpdateCommand:ICommand
    {
        public ItemUpdateCommand(ItemViewModel viewModel)
        {
            _ViewModel = viewModel;
        }

        private ItemViewModel _ViewModel;

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public bool CanExecute(object parameter)
        {
            return _ViewModel.CanUpdate;
        }

        public void Execute(object parameter)
        {
            _ViewModel.Update();
        }
    }
}
