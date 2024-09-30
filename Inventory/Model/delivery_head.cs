using System.ComponentModel.DataAnnotations;

namespace Inventory.Model
{
    public class delivery_head
    {
        [Key]
        public int deliveryId {  get; set; }
        public string deliveryNo { get; set; }
        public string bookingNo {  get; set; }
        public decimal totalDeliveryQty { get; set; }
        public string deliveredBy {  get; set; }
        public DateTime deliveryTime { get; set; }
        public string customerCode {  get; set; }

    }
}
