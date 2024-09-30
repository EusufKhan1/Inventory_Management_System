using System.ComponentModel.DataAnnotations;

namespace Inventory.Model
{
    public class customer
    {

        [Key]
        public int cusId {  get; set; }
        public string customerName { get; set; }
        public string customerEmail { get; set; }
        public string customerPhone { get; set; }
        public string address {  get; set; }
        public string customerCode {  get; set; }
        public DateTime cusEntrydate { get; set; }
        public string cusEntryBy {  get; set; }

    }
}
