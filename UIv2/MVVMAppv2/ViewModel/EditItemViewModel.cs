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
    class EditItemViewModel : ViewModelBase
    {
        #region Fields

        protected Item item;

        protected ObservableCollection<Item> items;

        protected EditItem editItemDialog { get; set; }

        #endregion

        #region Constructor

        public EditItemViewModel()
        {
            item = new Item();
        }

        public EditItemViewModel(ObservableCollection<Item> _items, Item _item, EditItem editItem)
        {
            items = _items;
            item = _item;
            editItemDialog = editItem;
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


        public Item Item
        {
            get
            {
                return item;
            }
        }

        public ObservableCollection<Item> Items
        {
            get
            {
                return items;
            }
            set
            {
                items = value;
                OnPropertyChanged("Items");
            }
        }
        #endregion

        #region Command

        RelayCommand _EditCommand;
        public ICommand EditCommand
        {
            get
            {
                if (_EditCommand == null)
                {
                    _EditCommand = new RelayCommand(o => Edit(), o => CanEdit);
                }
                return _EditCommand;
            }
        }
        #endregion

        #region Validate

        bool CanEdit
        {
            get
            {
                return item.isValid();
            }
        }

        #endregion

        #region Methods

        void Edit()
        {
            HttpClient client = new HttpClient();
            var requestString = JsonConvert.SerializeObject(item);
            var httpContent = new StringContent(requestString, Encoding.UTF8, "application/json");
            HttpResponseMessage responseMessage = client.PutAsync("http://localhost:5000/strgv1/update", httpContent).Result;
            if (responseMessage.IsSuccessStatusCode)
            {

                NotifyView notifyView = new NotifyView();
                notifyView.ShowDialog();
                editItemDialog.Close();
            }
        }

        #endregion

    }
}
