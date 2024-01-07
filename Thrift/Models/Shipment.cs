namespace Thrift.Models
{
    public class Shipment
    {
        public int ShipmentId { get; set; }
        public int OrderId { get; set; }
        public DateTime ShippingDate { get; set; }
        public DateTime EstimatedDeliveryDate{ get; set;}
        public int Status { get; set; }
        
    }
}
