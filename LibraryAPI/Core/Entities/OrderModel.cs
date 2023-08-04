namespace LibraryManagementSystemBackend.Core.Entities
{
    public class OrderModel
    {
        public int OrderID { get; set; }
        public DateTime OrderDate { get; set; }
        public decimal TotalPrice { get; set; }
        public string? Status { get; set; }
        public int MemberID { get; set; }
    }
}
