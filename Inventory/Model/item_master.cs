namespace Inventory.Model
{
    public class item_master
    {
        public int productId { get; set; } 
        public string itemCode {  get; set; }
        public string itemName { get; set; }
        public string unit {  get; set; }
        public decimal price { get; set; }
        public DateTime entryDate { get; set; }
        public string category {  get; set; }
        public string color {  get; set; }
        public string size {  get; set; }
        public decimal disPer { get; set; } = 0;
        public string status {  get; set; }
        public string entryBy {  get; set; }


    }
}
