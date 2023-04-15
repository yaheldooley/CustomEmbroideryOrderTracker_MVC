namespace CustomEmbroideryOrderTracker_MVC.Models
{
    public class PurchaseOrder
    {
        public int ID { get; set; }
        public int ShippingInfoID { get; set; }
        public int CarrierInfoID { get; set; }
        public DateTime DateEntered { get; set; }
        public DateTime DateDue { get; set; }

        public ShippingInfo ShippingInfo { get; set; }
        public CarrierInfo CarrierInfo { get; set; }
        public IEnumerable<WorkOrder> WorkOrders { get; set; }
        
    }
}
