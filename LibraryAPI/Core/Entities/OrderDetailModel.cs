namespace LibraryManagementSystemBackend.Core.Entities
{
    public class OrderDetailModel
    {
        public int OrderDetailID { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public int BookID { get; set; }
        public int OrderID { get; set; }
    }
}
