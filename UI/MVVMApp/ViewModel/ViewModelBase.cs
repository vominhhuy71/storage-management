using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMApp.ViewModel
{
    public abstract class ViewModelBase : INotifyPropertyChanged
    {
        #region Constructor
        protected ViewModelBase()
        {

        }

        #endregion

        #region DisplayItem
        public virtual string DisplayItem { get; set; }
        #endregion

        #region INotifyPropertyChanged

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;

            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        #endregion
    }
}
