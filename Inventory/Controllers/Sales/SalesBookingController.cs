﻿using Inventory.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Inventory.Controllers.Sales
{
    [Route("api/[controller]")]
    [ApiController]
    public class SalesBookingController : ControllerBase
    {
        private readonly MyDbContex dbContex;
        public SalesBookingController(MyDbContex dbContex)
        {
            this.dbContex = dbContex;
        }
        [HttpPost]
        [Route("add_booking")]
        public IActionResult SaveBooking(sales_booking model)
        {
            try
            {
                if (model.bookingDetails == null || model.bookingDetails.Count == 0) return BadRequest("Please Select Minimum One Details!!");
                else if (model.totalAmt <= 0) return BadRequest("Total Amount Must Be Greater Zero");
                model.trnno= DateTime.Now.ToString("yyyyMMddHHmmssfff") + new Random().Next(1000, 9999).ToString();
                dbContex.sales_booking.Add(new sales_booking
                {
                    bookingId= model.bookingId,
                    trnno = model.trnno,
                    totalAmt = model.totalAmt,
                    extraCarringCharge = model.extraCarringCharge,
                    quantity = model.quantity,
                    bookingDate = DateTime.Now,
                    specialDiscPer = model.specialDiscPer,
                    specialDisAmt = model.specialDisAmt,
                    bokingPrefix = model.bokingPrefix,
                    customerCode = model.customerCode,
                    status = "Submitted",
                    remarks = model.remarks,
                    payment=model.payment
                });
                foreach(sales_booking_details item in model.bookingDetails)
                {
                    if (item.quantity <= 0) return BadRequest($"Invalid Item Quantity For Item Code :{item.productCode}");
                    item.productDisAmt = item.rete * 0.001m * item.productDisPer;
                    item.lineAmt = (item.rete * item.quantity) - (item.productDisAmt * item.quantity);

                    dbContex.sales_booking_details.Add(new sales_booking_details
                    {
                        trnno = model.trnno,
                        bookingId = model.bookingId,
                        productId = item.productId,
                        quantity = item.quantity,
                        productCode = item.productCode,
                        productName = item.productName,
                        productUnit = item.productUnit,
                        rete = item.rete,
                        productDisPer = item.productDisPer,
                        productDisAmt = item.productDisAmt,
                        lineAmt = item.lineAmt,
                        createDate=DateTime.Now,
                    });

                }
                var output = dbContex.SaveChanges();
                return Ok("New Booking Added Successfully!!!");
            }

            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
    }
}
