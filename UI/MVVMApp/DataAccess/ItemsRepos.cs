using MVVMApp.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace MVVMApp.DataAccess
{
    class ItemsRepos
    {
        #region Fields

        readonly List<Item> _Items;

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
            Task<HttpResponseMessage> task = LoadData();
            if (task.IsCompleted)
            {
                HttpResponseMessage response = task.Result;
                if (response.IsSuccessStatusCode)
                {
                    string responseString = response.Content.ReadAsStringAsync().Result;
                    _Items = JsonConvert.DeserializeObject<List<Item>>(responseString);
                }
            }
            
        }
        #endregion

        #region LoadContent

        public async Task<HttpResponseMessage>  LoadData()
        {
            HttpClient client = new HttpClient();
            return await client.GetAsync("http://localhost:5000/strgv1/get/all");           
        }
        #endregion


    }
}
