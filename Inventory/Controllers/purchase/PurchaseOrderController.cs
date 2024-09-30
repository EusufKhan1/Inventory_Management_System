using Inventory.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Inventory.Controllers.purchase
{
    [Route("api/[controller]")]
    [ApiController]
    public class PurchaseOrderController : ControllerBase
    {
        private readonly MyDbContex dbContex;
        public PurchaseOrderController(MyDbContex dbContex)
        {
            this.dbContex = dbContex;
        }

        [HttpPost]
        [Route("add_purchase")]
        public IActionResult SaveBooking(purchase_order model)
        {
            try
            {
                if (model.Details == null || model.Details.Count == 0) return BadRequest("Please Select Minimum One Details!!");
                else if (model.totalAmt <= 0) return BadRequest("Total Amount Must Be Greater Zero");
                model.trnno = DateTime.Now.ToString("yyyyMMddHHmmssfff") + new Random().Next(1000, 9999).ToString();
                model.trnno = "PUR-" + model.trnno;


                dbContex.purchase_order.Add(new purchase_order
                {
                    //bookingId= model.bookingId,
                    trnno = model.trnno,
                    totalAmt = model.totalAmt,
                    extraCarringCharge = model.extraCarringCharge,
                    quantity = model.quantity,
                    bookingDate = DateTime.Now,
                    specialDiscPer = model.specialDiscPer,
                    specialDisAmt = model.specialDisAmt,
                    purchsePrefix = model.purchsePrefix,
                    status = "Submitted",
                    remarks = model.remarks,
                    payment = model.payment
                });
                var output = dbContex.SaveChanges();

                int id = dbContex.purchase_order.Max(x => x.purId);
                //if (id == null) id = 0;
                model.purId = id;

                if (output == 1)
                {
                    foreach (purchase_order_details item in model.Details)
                    {
                        if (item.quantity <= 0) return BadRequest($"Invalid Item Quantity For Item Code :{item.productCode}");
                        item.productDisAmt = item.rate * 0.001m * item.productDisPer;
                        item.lineAmt = (item.rate * item.quantity) - (item.productDisAmt * item.quantity);

                        dbContex.purchase_order_details.Add(new purchase_order_details
                        {
                            trnno = model.trnno,
                            purId = model.purId,
                            productId = item.productId,
                            quantity = item.quantity,
                            productCode = item.productCode,
                            productName = item.productName,
                            productUnit = item.productUnit,
                            rate = item.rate,
                            productDisPer = item.productDisPer,
                            productDisAmt = item.productDisAmt,
                            lineAmt = item.lineAmt,
                            createDate = DateTime.Now,
                        });
                        var output1 = dbContex.SaveChanges();
                        if (output1 != 1) return BadRequest($"Save Not Successfull For Item Code :{item.productCode}");
                    }

                }
                else
                {
                    return BadRequest("Save Not Successfull!!");
                }


                return Ok("New Purchase Added Successfully!!!");
            }

            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

    }
}
