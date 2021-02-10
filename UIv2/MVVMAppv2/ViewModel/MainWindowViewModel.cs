using MVVMAppv2.DataAccess;
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
    public class MainWindowViewModel : ViewModelBase
    {

        #region Fields
        public Item _SelectedItem;
        protected ObservableCollection<Item> _Items;
        #endregion

        #region Properties
        public ObservableCollection<Item> Items
        {
            get
            {
                return _Items;
            }
            set
            {
                _Items = value;
                OnPropertyChanged("Items");
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
                OnPropertyChanged("SelectedItem");
            }
        }

        #endregion

        #region Constructor
        public MainWindowViewModel()
        {
            ObservableCollection<Item> _items = new ObservableCollection<Item>();
            ItemRepos itemRepos = new ItemRepos();
            List<Item> items = itemRepos.LoadContent();
            foreach (var item in items)
            {
                _items.Add(item);
            }
            _Items = _items;
        }
        #endregion

        #region Commands

        RelayCommand _AddCommand;
        public ICommand AddCommand
        {
            get
            {
                if (_AddCommand == null)
                {
                    _AddCommand = new RelayCommand(o=>Add(), o=>true);
                }
                return _AddCommand;
            }
        }

        RelayCommand _EditCommand;
        public ICommand EditCommand
        {
            get
            {
                if (_EditCommand == null)
                {
                    _EditCommand = new RelayCommand(o => EditDialog(), o => CanEdit);
                }
                return _EditCommand;
            }
        }

        RelayCommand _DeleteCommand;
        public ICommand DeleteCommand
        {
            get
            {
                if (_DeleteCommand == null)
                {
                    _DeleteCommand = new RelayCommand(o => Delete(), o => CanDelete);
                }
                return _DeleteCommand;
            }
        }
        #endregion

        #region Validation
        bool CanEdit
        {
            get
                {
                if (_SelectedItem!= null)
                {
                    return true;
                }
                return false;
            }
        }

        bool CanDelete
        {
            get
            {
                if (_SelectedItem != null)
                {
                    return true;
                }
                return false;
            }
        }

        #endregion

        #region Methods
        void Add()
        {
            AddItem addItem = new AddItem();
            addItem.DataContext = new AddItemViewModel(_Items, addItem);
            addItem.ShowDialog();
        }

        void EditDialog()
        {
            EditItem editItem = new EditItem();
            EditItemViewModel  editItemViewModel = new EditItemViewModel(_Items, _SelectedItem,editItem);
            editItem.DataContext = editItemViewModel;
            bool? result = editItem.ShowDialog();
            if (result.HasValue)
            {
                SelectedItem = editItemViewModel.Item;
            }
        }

        void Delete()
        {
            HttpClient client = new HttpClient();
            var requestString = JsonConvert.SerializeObject(_SelectedItem);
            var request = new HttpRequestMessage(HttpMethod.Delete, "http://localhost:5000/strgv1/delete");
            request.Content = new StringContent(requestString, Encoding.UTF8, "application/json");
            HttpResponseMessage responseMessage = client.SendAsync(request).Result;
            Console.WriteLine(requestString);
            if (responseMessage.IsSuccessStatusCode)
            {
                NotifyView notifyView = new NotifyView();
                notifyView.ShowDialog();
                _Items.Remove(SelectedItem);
            }
        }
        #endregion
    }
}
