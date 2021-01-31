using MVVMApp.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;

namespace MVVMApp.ViewModel
{
    public class ItemViewModel
    {
        #region Property

        private List<Item> _Items;

        private Item _Item;

        public ItemViewModel()
        {
           LoadContentsAsync();
           
        }
        public async void LoadContentsAsync()
        {
            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync("http://localhost:5000/strgv1/get/all");
            if (response.IsSuccessStatusCode)
            {
                string responseString = await response.Content.ReadAsStringAsync();
                List<Item> items = JsonConvert.DeserializeObject<List<Item>>(responseString);
                _Items = items;                
            }
        }

        public Item Item
        {
            get
            {
                return _Item;
            }
        }

        public List<Item> Items
        {
            get
            {
                return _Items;
            }
        }
        #endregion

        #region Public Methods
        public void Update()
        {
            Debug.Assert(false, String.Format("{0} was updated", Item.ItemName));
        }

        #endregion
    }
}
