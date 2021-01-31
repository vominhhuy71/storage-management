using MVVMApp.Commands;
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
            //var task = LoadContentsAsync();
            //task.Wait();
            //_Items = task.Result;
            List<Item> items = new List<Item>();
            items.Add(new Item(1, "Milk", 300, "liters"));
            items.Add(new Item(2, "Carrot", 5, "kg"));
            items.Add(new Item(3, "Potatoes", 3, "kg"));
            _Items = items;
            UpdateCommand = new ItemUpdateCommand(this);
        }

        //DEADLOCK here when running async function sync

        //public async Task<List<Item>> LoadContentsAsync()
        //{
        //    List<Item>items = new List<Item>();
        //    HttpClient client = new HttpClient();
        //    HttpResponseMessage response = await client.GetAsync("http://localhost:5000/strgv1/get/all");
        //    if (response.IsSuccessStatusCode)
        //    {
        //        string responseString = await response.Content.ReadAsStringAsync();
        //        items = JsonConvert.DeserializeObject<List<Item>>(responseString);
        //    }
        //    return items;
        //}

        /// <summary>
        /// UpdateCommand for Item
        /// </summary>
        public ICommand UpdateCommand { get; private set; }

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
