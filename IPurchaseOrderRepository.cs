using CustomEmbroideryOrderTracker_MVC.Models;

namespace CustomEmbroideryOrderTracker_MVC
{
    public interface IPurchaseOrderRepository
    {
        public IEnumerable<PurchaseOrder> GetAllPurchaseOrders();
        public PurchaseOrder GetPurchaseOrder(int orderID);
        public ShippingInfo GetShippingInfo(int shippingInfoID);
        public CarrierInfo GetCarrierInfo(int carrierInfoID);
        public IEnumerable<WorkOrder> GetWorkOrders(int orderID);
        public IEnumerable<Design> GetDesigns(int designID);
        public string GetLocationName(int locationID);
    }
}

