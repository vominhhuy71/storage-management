using MVVMAppv2.Model;
using MVVMAppv2.View;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MVVMAppv2.ViewModel
{
    class AddItemViewModel : ViewModelBase
    {
        #region Fields

        protected Item item;

        protected ObservableCollection<Item> items;

        protected AddItem addItem;
        #endregion

        #region Constructor

        public AddItemViewModel()
        {
            item = new Item();
        }

        public AddItemViewModel(ObservableCollection<Item> _items, AddItem _addItem)
        {
            items = _items;
            item = new Item();
            addItem = _addItem;
        }
        #endregion

        #region Item's properties

        public string ItemName
        {
            get { return item.ItemName; }
            set
            {
                item.ItemName = value;
                OnPropertyChanged("ItemName");
            }
        }

        public int Quantity
        {
            get { return item.Quantity; }

            set
            {
                item.Quantity = value;
                OnPropertyChanged("Quantity");
            }
        }

        public int Min
        {
            get { return item.Min; }

            set
            {
                item.Min = value;
                OnPropertyChanged("Min");
            }
        }

        public string Unit
        {
            get { return item.Unit; }

            set
            {
                item.Unit = value;
                OnPropertyChanged("Unit");
            }
        }

        #endregion

        #region AddItem

        RelayCommand _AddItem;
        public ICommand AddItem
        {
            get
            {
                if (_AddItem == null)
                {
                    _AddItem = new RelayCommand(o => Save(), o => CanSave);
                }
                return _AddItem;
            }
        }
        #endregion

        #region Validate
        bool CanSave
        {
            get
            {
                return item.isValid();
            }
        }

        #endregion

        #region Method
        public Item Item
        {
            get
            {
                return item;
            }
        }

        void Save()

        {
            HttpClient client = new HttpClient();
            var requestString = JsonConvert.SerializeObject(item);
            var httpContent = new StringContent(requestString, Encoding.UTF8, "application/json");
            HttpResponseMessage responseMessage = client.PostAsync("http://localhost:5000/strgv1/new", httpContent).Result;
            if (responseMessage.IsSuccessStatusCode)
            {
                Item lastItem = new Item();
                if (items.Count > 0)
                {
                    lastItem = items.Last();
                }
                else
                {
                    lastItem.Id = 0;
                }
                NotifyView notifyView = new NotifyView();
                notifyView.ShowDialog();
                item.Id = lastItem.Id + 1;
                items.Add(new Item(item.Id, item.ItemName, item.Quantity, item.Unit, item.Min));
                addItem.Close();
            }
        }

        #endregion
    }
}
