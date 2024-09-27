using Inventory.Model;
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

    }
}
