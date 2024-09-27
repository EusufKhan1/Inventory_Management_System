using Inventory.Interface.ItemsManage;
using Inventory.Model;
using Inventory.Services.ItemsManage;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;


namespace Inventory.Controllers.ItemManage
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductEntryController : ControllerBase
    {
        //private  ProductEntryServices productRepo ;

        private readonly MyDbContex dbContex;
        public ProductEntryController(MyDbContex dbContex)
        {
            this.dbContex = dbContex;
        }

        [HttpPost]
        [Route("add_product")]
        public IActionResult SaveProduct(item_master model)
        {
            try
            {
                
                if (string.IsNullOrEmpty(model.itemCode)) return BadRequest("Please Enter Item Code!!");
                else if (string.IsNullOrEmpty(model.itemName)) return BadRequest("Please Enter Item Name!!");
                else if (model.price <= 0) return BadRequest("Please Enter Item Price!!");

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
                return Ok("Product Add Succesfully!!!");
            }

            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
    }
}
