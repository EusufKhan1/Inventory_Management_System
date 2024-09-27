using System.ComponentModel.DataAnnotations;

namespace Inventory.Model
{
    public class sales_booking_details
    {
        [Key]
        public int bookinDetailsId { get; set; }
        public int bookingId { get; set; }
        public string trnno { get; set; }
        public int productId { get; set; }
        public string productCode { get; set; }
        public string productName { get; set; }
        public string productUnit { get; set; }
        public decimal quantity { get; set; }
        public decimal rete { get; set; }
        public decimal productDisPer { get; set; }
        public decimal productDisAmt { get; set; }
        public decimal lineAmt { get; set; }
        public DateTime createDate { get; set; }


    }
}
