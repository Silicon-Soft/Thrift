using System.ComponentModel.DataAnnotations;

namespace Thrift_Us.Models
{
    public class OrderHeader
    {
        public int Id { get; set; }
        public string ApplicationUserId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
        public DateTime OrderDate { get; set; }
        [Required]
        public DateTime TimeofPick { get; set; }
        [Required]
        public DateTime DateofPick { get; set; }
        public double OrderTotal { get; set; }
        public string TransId { get; set; }
        public OrderStatus OrderStatus { get; set; }
        public PaymentStatus PaymentStatus { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Phone { get; set; }

        [Required]
        public string Address{get; set; }
        public string City { get; set; }  
        public string State { get; set; }
        public string PostalCode { get; set; }
        public virtual ICollection<OrderDetails> OrderDetails { get; set; }
      

    }
    public enum PaymentStatus
    {
        Pending ,
        Recieved
    }
    public enum OrderStatus
    {
        Inprocess,
        Shipped
        
    }

}
