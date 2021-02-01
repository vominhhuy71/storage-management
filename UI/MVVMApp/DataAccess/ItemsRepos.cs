using MVVMApp.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace MVVMApp.DataAccess
{
    class ItemsRepos
    {
        #region Fields

        protected List<Item> _Items;

        #endregion

        #region Property
        public List<Item> Items
        {
            get
            {
                return _Items;
            }
        }
        #endregion

        #region Contructor
        public ItemsRepos()
        {
            _Items = LoadContent();
            
        }
        #endregion

        #region LoadContent

        public List<Item> LoadContent()
        {
            var client = new WebClient();
            string response = client.DownloadString("http://localhost:5000/strgv1/get/all");
            List<Item> items = JsonConvert.DeserializeObject<List<Item>>(response);
            return items;
        }
        #endregion


    }
}
