using MVVMApp.DataAccess;
using MVVMApp.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Net.Http;
using System.Text;
using System.Windows.Input;

namespace MVVMApp.ViewModel
{
    public class ItemViewModel : ViewModelBase
    {
        #region Property

        private List<Item> _Items;
        public bool _IsSelected;
        protected Item _SelectedItem;

        public ItemViewModel()
        {
            //List<Item> items = new List<Item>();
            //items.Add(new Item(1, "Milk", 300, "liters"));
            //items.Add(new Item(2, "Carrot", 5, "kg"));
            //items.Add(new Item(3, "Potatoes", 3, "kg"));

            ItemsRepos items = new ItemsRepos();
            _Items = items.Items;
        }
        RelayCommand _UpdateCommand;
        public ICommand UpdateCommand
        {
            get
            {
                if (_UpdateCommand == null)
                {
                    _UpdateCommand = new RelayCommand(
                        o => Update(), 
                        o => CanUpdate);
                }
                return _UpdateCommand;
            }
        }

        public Item SelectedItem
        {
            get
            {
                return _SelectedItem;
            }
            set
            {
                _SelectedItem = value;
                base.OnPropertyChanged("SelectedItem");
            }
        }

        public List<Item> Items
        {
            get
            {
                return _Items;
            }
        }

        /// <summary>
        /// Check if item can be updated
        /// </summary>
        public bool CanUpdate {
            get
            {
                if (SelectedItem!=null)
                {
                    return true;
                }
                return false;
            }
        }
        #endregion

        #region Public Methods
        public void Update()
        {
            HttpClient client = new HttpClient();
            var requestString = JsonConvert.SerializeObject(_SelectedItem);
            var httpContent = new StringContent(requestString, Encoding.UTF8, "application/json");
            HttpResponseMessage responseMessage = client.PutAsync("http://localhost:5000/strgv1/update", httpContent).Result;
            Console.WriteLine(requestString);
            if (responseMessage.IsSuccessStatusCode)
            {
                Debug.Assert(false, String.Format("{0} was updated", _SelectedItem.ItemName));
                foreach (var item in _Items)
                {
                    if (item.ItemName == _SelectedItem.ItemName)
                    {
                        item.Quantity = _SelectedItem.Quantity;
                    }
                }
            }
            
        }

        #endregion

        
    }
}
