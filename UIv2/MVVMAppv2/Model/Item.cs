using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMAppv2.Model
{
    public class Item : IDataErrorInfo
    {
        
        #region Properties
        public int Id { get; set; }
        public string ItemName { get; set; }
        public int Quantity { get; set; }
        public string Unit { get; set; }
        public int Min { get; set; }
        #endregion

        #region Constructor

        public Item()
        {

        }

        public Item (int _Id, string _ItemName, int _Quantity, string _Unit, int _Min)
        {
            Id = _Id;
            ItemName = _ItemName;
            Quantity = _Quantity;
            Unit = _Unit;
            Min = _Min;
        }

        #endregion

        #region IDataErrorInfo members 
        public string this[string columnName]
        {
            get
            {
                return this.GetValidation(columnName);
            }
        }

        public string Error { get; private set; }
        #endregion

        #region Validation

        public bool isValid()
        {
            string[] columnName = { "ItemName", "Quantity", "Min" };
            foreach (var item in columnName)
            {
                if (GetValidation(item)!=null)
                {
                    return false;
                }
            }
            return true;
        }

        private string GetValidation(string columnName)
        {
            string error = null;
            switch (columnName)
            {
                case "ItemName":
                    error = this.ValidItemName();
                    break;
                case "Quantity":
                    error = this.ValidQuantity();
                    break;
                case "Min":
                    error = this.ValidMin();
                    break;
            }

            return error;
        }

        private string ValidMin()
        {
            string error;
            if (String.IsNullOrWhiteSpace(this.Min.ToString()))
            {
                error = "String is empty or null";
                return error;
            }
            return null;
        }

        private string ValidQuantity()
        {
            if (String.IsNullOrWhiteSpace(this.Quantity.ToString()))
            {
                string error = "String is empty or null";
                return error;
            }
            return null;
        }

        private string ValidItemName()
        {
            if (String.IsNullOrWhiteSpace(this.ItemName))
            {
                string error = "String is empty or null";
                return error;
            }
            return null;
        }
        #endregion
    }
}
