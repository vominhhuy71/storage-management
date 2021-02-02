﻿using MVVMApp.DataAccess;
using MVVMApp.Model;
using MVVMApp.View;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Windows.Input;

namespace MVVMApp.ViewModel
{
    public class ItemViewModel : ViewModelBase
    {
        #region Fields

        protected ObservableCollection<Item> _Items;
        public bool _IsSelected;
        protected Item _SelectedItem;
        protected Item _Item;
        /// <summary>
        /// Display dialog
        /// </summary>
        private ItemInfoViewModel childModel;
        public ItemViewModel()
        {
            //ObservableCollection<Item> items = new ObservableCollection<Item>();
            //items.Add(new Item(1, "Milk", 300, "liters"));
            //items.Add(new Item(2, "Carrot", 5, "kg"));
            //items.Add(new Item(3, "Potatoes", 3, "kg"));
            childModel = new ItemInfoViewModel();
            ItemsRepos _items = new ItemsRepos();
            ObservableCollection<Item> ob_items = new ObservableCollection<Item>();
            var list = _items.Items;
            foreach (var item in list)
            {
                ob_items.Add(item);
            }
            _Items = ob_items;
            _Item = new Item();
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

        RelayCommand _AddCommand;
        public ICommand AddCommand
        {
            get
            {
                if (_AddCommand == null)
                {
                    _AddCommand = new RelayCommand(
                        o => Add(),
                        o => true);
                }
                return _AddCommand;
            }
        }



        RelayCommand _DeleteCommand;
        public ICommand DeleteCommand
        {
            get
            {
                if (_DeleteCommand == null)
                {
                    _DeleteCommand = new RelayCommand(
                        o => Delete(),
                        o => CanDelete);
                }
                return _DeleteCommand;
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

        public ObservableCollection<Item> Items
        {
            get
            {
                return _Items;
            }
            set
            {
                _Items = value;
                base.OnPropertyChanged("Items");
            }
        }

        public Item Item
        {
            get
            {
                return _Item;
            }
        }

        /// <summary>
        /// Check if item can be updated
        /// </summary>
        public bool CanUpdate {
            get
            {
                return SelectedItem != null ? true : false;
            }
        }

        /// <summary>
        /// Check if item can be deleted
        /// </summary>
        public bool CanDelete
        {
            get
            {
                if (SelectedItem != null)
                {
                    return true;
                }
                return false;
            }
        }

        /// <summary>
        /// Check if item can be Added
        /// </summary>
        public bool CanSave
        {
            get
            {
                foreach (var item in _Items)
                {
                    if (item.ItemName == _Item.ItemName)
                    {
                        return false;
                    }
                    else if (string.IsNullOrWhiteSpace(_Item.ItemName))
                    {
                        return false;
                    }
                }
                return true;
            }
        }
        #endregion

        #region Item Properties
        public string ItemName
        {
            get
            {
                return _Item.ItemName;
            }
            set
            {
                _Item.ItemName = value;
                base.OnPropertyChanged("ItemName");
            }
        }
        public int Quantity
        {
            get
            {
                return _Item.Quantity;
            }
            set
            {
                _Item.Quantity = value;
                OnPropertyChanged("Quantity");
            }
        }
        public int Id
        {
            get
            {
                return _Item.Id;
            }
            set
            {
                _Item.Id = value;
                OnPropertyChanged("Id");
            }
        }
        public string Unit
        {
            get
            {
                return _Item.Unit;
            }
            set
            {
                _Item.Unit = value;
                OnPropertyChanged("Unit");
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
                childDialog viewModel = new childDialog();
                viewModel.DataContext = childModel;
                childModel.Info = _SelectedItem.ItemName + " was updated!";
                viewModel.ShowDialog();
            }
            
        }
        public void Add()
        {
            HttpClient client = new HttpClient();
            var requestString = JsonConvert.SerializeObject(_Item);
            var httpContent = new StringContent(requestString, Encoding.UTF8, "application/json");
            HttpResponseMessage responseMessage = client.PostAsync("http://localhost:5000/strgv1/new", httpContent).Result;
            if (responseMessage.IsSuccessStatusCode)
            {
                //Debug.Assert(false, String.Format("{0} was Added", _Item.ItemName));
                Item lastItem = new Item();
                if (_Items.Count > 0)
                {
                   lastItem = _Items.Last();
                }
                else
                {
                    lastItem.Id = 0;
                }

                childDialog viewModel = new childDialog();
                viewModel.DataContext = childModel;
                childModel.Info = _Item.ItemName + " was added!";
                viewModel.ShowDialog();

                _Item.Id = lastItem.Id + 1;
                _Items.Add(new Item(_Item.Id,_Item.ItemName,_Item.Quantity,_Item.Unit));
                Quantity = 0;
                ItemName = "";
                Unit = "";              
                
            }

        }

        public void Delete()
        {
            HttpClient client = new HttpClient();
            var requestString = JsonConvert.SerializeObject(_SelectedItem);
            var request = new HttpRequestMessage(HttpMethod.Delete, "http://localhost:5000/strgv1/delete");
            request.Content= new StringContent(requestString, Encoding.UTF8, "application/json");
            HttpResponseMessage responseMessage = client.SendAsync(request).Result;
            Console.WriteLine(requestString);
            if (responseMessage.IsSuccessStatusCode)
            {
                childDialog viewModel = new childDialog();
                viewModel.DataContext = childModel;
                childModel.Info = _SelectedItem.ItemName + " was deleted!";
                viewModel.ShowDialog();
                _Items.Remove(SelectedItem);               
            }
            
        }

    }
    #endregion


}

