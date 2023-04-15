namespace CustomEmbroideryOrderTracker_MVC.Models
{
    public class CarrierInfo
    {
        public int ID { get; set; }
        public string Carrier { get; set; }
        public string TrackingNumber { get; set; }
        public bool Shipped { get; set; }
    }
}
