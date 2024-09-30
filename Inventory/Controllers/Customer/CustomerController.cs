using Inventory.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Inventory.Controllers.Customer
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly MyDbContex dbContex;
        public CustomerController(MyDbContex dbContex)
        {
            this.dbContex = dbContex;
        }
        /// <summary>
        /// Add New Customer
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("add_cusotmer")]
        public IActionResult CustomerSave(customer model)
        {
            try
            {
                model.customerCode = "CUS-" + model.customerPhone;
                if(string.IsNullOrEmpty(model.customerName)) return BadRequest("Please Enter Customer Name!!!");
                dbContex.customer.Add(new customer
                {
                    customerName = model.customerName,
                    customerCode = model.customerCode,
                    customerPhone = model.customerPhone,
                    customerEmail = model.customerEmail,
                    address = model.address,
                    cusEntryBy = model.cusEntryBy,
                    cusEntrydate = DateTime.Now
                });
                var output = dbContex.SaveChanges();

                return Ok("Customer Add Succefull!!");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }           

        }
        /// <summary>
        /// Update Customer
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("update_customer")]
        public IActionResult updateCustomer(customer model)
        {
            try
            {
                var cus = dbContex.customer.Find(model.cusId);

                if (cus == null) return NotFound();

                cus.customerName = model.customerName;
                cus.customerCode = model.customerCode;
                cus.customerPhone = model.customerPhone;
                cus.customerEmail = model.customerEmail;
                cus.address = model.address;

                var output = dbContex.SaveChanges();
                return Ok("Customer Update Succesfully!!!");
            }

            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        /// <summary>
        /// Delete Customer
        /// </summary>
        /// <param name="productIdl"></param>
        /// <returns></returns>
        [HttpDelete]
        [Route("delete_customer")]
        public IActionResult deleteCustomer(int cusId)
        {
            try
            {
                var Customer = dbContex.customer.Where(e => e.cusId == cusId).ToList();
                if (Customer.Count == 0 || Customer == null) return NotFound();

                dbContex.customer.RemoveRange(Customer);
                dbContex.SaveChanges();

                return Ok("Customer Delete Successfully!!");

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
