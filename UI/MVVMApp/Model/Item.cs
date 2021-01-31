using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMApp.Model
{
    public class Item : INotifyPropertyChanged
    {
        #region Item Property
        /// <summary>
        /// Initialize an instance of class Item
        /// </summary>
        public Item(int id, string itemName, int quantity, string unit)
        {
            Id = id;
            ItemName = itemName;
            Quantity = quantity;
            Unit = unit;
        }

        private int _Id;
        private string _ItemName;
        private int _Quantity;
        private string _Unit;

        /// <summary>
        /// Get/set Item's Id
        /// </summary>
        public int Id
        {
            get
            {
                return _Id;
            }
            set
            {
                _Id = value;
                OnPropertyChanged("Id");
            }
        }

        /// <summary>
        /// Get/set Item's Quantity
        /// </summary>
        public int Quantity
        {
            get
            {
                return _Quantity;
            }
            set
            {
                _Quantity = value;
                OnPropertyChanged("Quantity");
            }
        }

        /// <summary>
        /// Get/set Item's Name
        /// </summary>
        public string ItemName
        {
            get
            {
                return _ItemName;
            }
            set
            {
                _ItemName = value;
                OnPropertyChanged("ItemName");
            }
        }

        /// <summary>
        /// Get/set Item's Unit
        /// </summary>
        public string Unit
        {
            get
            {
                return _Unit;
            }
            set
            {
                _Unit = value;
                OnPropertyChanged("Unit");
            }
        }

        #endregion

        #region INotifyPropertyChanged Members

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName)
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

