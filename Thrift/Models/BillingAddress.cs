namespace Thrift.Models
{
    public class BillingAddress
    {
        public int  BillingAddressId { get; set; }
        public int UserId { get; set;}
        public User? User { get; set;}
        public string Province { get; set;}
        public string City { get; set;}
        public string Street { get; set;}

    }
}
