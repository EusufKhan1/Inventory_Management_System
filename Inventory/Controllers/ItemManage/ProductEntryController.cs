using Inventory.Interface.ItemsManage;
using Inventory.Model;
using Inventory.Services.ItemsManage;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata;


namespace Inventory.Controllers.ItemManage
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductEntryController : ControllerBase
    {


        private readonly MyDbContex dbContex;
        public ProductEntryController(MyDbContex dbContex)
        {
            this.dbContex = dbContex;
        }

        /// <summary>
        /// New Product Add
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("add_product")]
        public IActionResult SaveProduct(item_master model)
        {
            try
            {

                if (string.IsNullOrEmpty(model.itemCode)) return BadRequest("Please Enter Item Code!!");
                else if (string.IsNullOrEmpty(model.itemName)) return BadRequest("Please Enter Item Name!!");
                else if (model.price <= 0) return BadRequest("Please Enter Item Price!!");

                int id = dbContex.item_master.Max(x => x.productId);
                if (id == null) id = 0;

                model.productId = id + 1;

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
        /// <summary>
        /// Products Update
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("update_product")]
        public IActionResult updateProducts(item_master model)
        {
            try
            {
                var product = dbContex.item_master.Find(model.productId);

                if (product == null) return NotFound();

                product.price = model.price;
                product.category = model.category;
                product.color = model.color;
                product.size = model.size;
                product.disPer = model.disPer;
                product.unit = model.unit;
                product.itemName = model.itemName;
                product.itemCode = model.itemCode;

                var output = dbContex.SaveChanges();
                return Ok("Product Update Succesfully!!!");
            }

            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
        /// <summary>
        /// Delete a Single Product
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpDelete]
        [Route("delete_product")]
        public IActionResult deleteProducts(int productIdl)
        {
            try
            {
                var prodcut = dbContex.item_master.Where(e => e.productId == productIdl).ToList();
                if (prodcut.Count == 0 || prodcut == null) return NotFound();

                dbContex.item_master.RemoveRange(prodcut);
                dbContex.SaveChanges();

                return Ok("Product Delete Successfully!!");

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        /// <summary>
        /// Get a Single Product
        /// </summary>
        /// <param name="productId"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("get_product")]
        public IActionResult getProduct(int productId)
        {
            try
            {
                var product = dbContex.item_master.FirstOrDefault(x => x.productId == productId);
                if (product != null)
                {
                    return Ok(product);
                }
                else return NotFound("Any Product Not Found");
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }
        /// <summary>
        /// Get ALl Product List Data Using searching 
        /// </summary>
        /// <param name="searchVal"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("product_list")]
        public IActionResult getProductList(string searchVal)
        {
            try
            {
                if (searchVal == null) searchVal = "";
                var product = dbContex.item_master.Where(e => e.itemCode.ToLower().Contains(searchVal.ToLower()) ||  e.itemName.ToLower().Contains(searchVal.ToLower())).OrderByDescending(e=>e.productId).ToList();
                if (product != null)
                {
                    return Ok(product);
                }
                else return NotFound("Any Product Not Found");

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
