using MVVMApp.DataAccess;
using MVVMApp.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Net.Http;
using System.Windows.Input;

namespace MVVMApp.ViewModel
{
    public class ItemViewModel
    {
        #region Property

        private List<Item> _Items;
        private Item _Item;
        public bool _IsSelected;
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

        public Item Item
        {
            get
            {
                return _Item;
            }

        }
        
        public Item SelectedItem { get; set; }
        
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

        #region Public Methods Debug
        public void Update()
        {
            Debug.Assert(false, String.Format("{0} was updated", SelectedItem.ItemName));
        }

        #endregion

        
    }
}
