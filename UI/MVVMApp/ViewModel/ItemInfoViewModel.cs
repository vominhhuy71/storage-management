using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMApp.ViewModel
{
    /// <summary>
    /// Get/set child view for validation
    /// </summary>
    class ItemInfoViewModel : ViewModelBase
    {
        private string _info;
        public string Info
        {
            get
            {
                return _info;
            }
            set
            {
                _info = value;
                OnPropertyChanged("Info");
            }
        }
    }
}
