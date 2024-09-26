using Inventory.Interface.Sales;
using Inventory.Model;

namespace Inventory.Services.Sales
{
    public class SalesBookingServices: ISalesBookingServices
    {
        private readonly MyDbContex dbContex;
        public SalesBookingServices(MyDbContex dbContex)
        {
            this.dbContex = dbContex;
        }

        public async Task<string> GetEditDataByBookingId(string bookingId)
        {
            throw new NotImplementedException();
        }
    }
}
