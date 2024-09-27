using System.ComponentModel.DataAnnotations;
using System.Diagnostics.Contracts;
using System.Reflection.Metadata;

namespace Inventory.Model
{
    public class sales_booking
    {
        [Key]
        public int bookingId {  get; set; }
        public string trnno {  get; set; }
        public decimal totalAmt { get; set; }
        public decimal extraCarringCharge {  get; set; }
        public DateTime bookingDate {  get; set; }
        public decimal quantity { get; set; }
        public decimal specialDiscPer { get; set; }
        public decimal specialDisAmt { get; set; }
        public string bokingPrefix {  get; set; }
        public string customerCode { get; set; }
        public string status {  get; set; }
        public string remarks {  get; set; }
        public decimal payment {  get; set; }
        public List<sales_booking_details> bookingDetails { get; set; }
    }
  

}
