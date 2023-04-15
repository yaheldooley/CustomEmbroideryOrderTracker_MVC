namespace CustomEmbroideryOrderTracker_MVC.Models
{
    public class WorkOrder
    {
        public int ID { get; set; }
        public int PurchaseOrderID { get; set; }
        public int ProductID { get; set; }
        public int DesignID { get; set; }

        public Product Product { get; set; }
        public IEnumerable<Design> Designs { get; set; }
    }
}
