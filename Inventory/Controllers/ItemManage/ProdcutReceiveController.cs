using Inventory.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Inventory.Controllers.ItemManage
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdcutReceiveController : ControllerBase
    {
        private readonly MyDbContex dbContex;
        public ProdcutReceiveController(MyDbContex dbContex)
        {
            this.dbContex = dbContex;
        }
        /// <summary>
        /// Stock Manage
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("stock_receive")]
        public IActionResult StockReceive(product_stock model)
        {
            try
            {
                if (model == null) return BadRequest("Item Not Selected");
                else if (string.IsNullOrEmpty(model.productCode)) return BadRequest("Prouct Code Must Be Selected!!");
                var check = dbContex.product_stock.FirstOrDefault(x => x.productId == model.productId);
                if (check == null)
                {
                    if (model.stockQty < 0) return BadRequest("Please Enter Valid Stock Quantity");
                    dbContex.product_stock.Add(new product_stock
                    {
                        productId = model.productId,
                        productCode = model.productCode,
                        productName = model.productName,
                        stockQty = model.stockQty,
                        lastUpdateBy = model.lastUpdateBy,
                        lastUpdateDate = DateTime.Now
                    });
                    var output = dbContex.SaveChanges();

                    return Ok("New Item Stock Add Successfull!!");

                }
                else
                {
                    var product = dbContex.product_stock.Find(check.stock_id);

                    decimal previous_stock = product.stockQty;
                    decimal new_stock = previous_stock + model.stockQty;
                    product.stockQty = new_stock;

                    var output = dbContex.SaveChanges();
                    return Ok("Product Stock Updated Succesfully!!!");

                }


            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        /// <summary>
        /// Get Single Item Stock
        /// </summary>
        /// <param name="productId"></param>
        /// <returns></returns>

        [HttpGet]
        [Route("item_stock")]
        public IActionResult GetItemStock(int productId)
        {
            try
            {
                var stock=dbContex.product_stock.Where(x=>x.productId == productId).FirstOrDefault();
                if (stock == null) return BadRequest("This Product Not Availabe For Stock Table");
                return Ok(stock);
            }
            catch (Exception ex)
            {
                return BadRequest("Falied!!");
            }
        }
    }
}
