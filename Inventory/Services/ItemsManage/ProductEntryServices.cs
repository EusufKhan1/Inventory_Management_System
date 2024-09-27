using Inventory.Interface.ItemsManage;
using Inventory.Model;
using Microsoft.EntityFrameworkCore;

namespace Inventory.Services.ItemsManage
{
    public class ProductEntryServices 
    {
        private readonly MyDbContex dbContex;    
        //public ProductEntryServices(MyDbContex dbContex)
        //{
        //    this.dbContex = dbContex;
        //}
        public string SaveProduct(item_master model)
        {
            try
            {
                if (string.IsNullOrEmpty(model.itemCode)) return "Please Enter Item Code";
                else if (string.IsNullOrEmpty(model.itemName)) return "Please Enter Item Name";
                else if (model.price <= 0) return "Please Enter Item Price";

                dbContex.item_master.Add(new item_master
                {
                    itemCode = model.itemCode,
                    itemName = model.itemName,
                    unit = model.unit,
                    price = model.price,
                    entryDate = DateTime.Now,
                    category = model.category,
                    color = model.color,
                    size = model.size,
                    disPer = model.disPer,
                    status = "Active",
                    entryBy = model.entryBy
                });
                var output = dbContex.SaveChanges();
                return output.ToString();
            }
            catch(Exception ex)
            {
                return ex.Message;
            }
        }
    }
}
