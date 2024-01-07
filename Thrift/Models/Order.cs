namespace Thrift.Models
{
    public class Order
    {
        public int OrderId { get; set; }
        public decimal TotalAmount { get; set; }
        public DateTime OrderDate{ get; set; }
        public int OrderStatus { get; set; }
        public string UserId { get; set; }
        public User? User { get; set; }


    }
}
