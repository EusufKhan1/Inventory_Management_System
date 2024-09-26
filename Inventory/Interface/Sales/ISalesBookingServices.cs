namespace Inventory.Interface.Sales
{
    public interface ISalesBookingServices
    {
        Task<string>GetEditDataByBookingId(string bookingId);
    }
}
