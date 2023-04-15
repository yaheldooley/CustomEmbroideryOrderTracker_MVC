using CustomEmbroideryOrderTracker_MVC.Models;
using Dapper;
using System.Data;
using System.Collections;
using static Google.Protobuf.Reflection.SourceCodeInfo.Types;
using Mysqlx.Crud;

namespace CustomEmbroideryOrderTracker_MVC
{
    public class PurchaseOrderRepository : IPurchaseOrderRepository
    {
        private readonly IDbConnection _conn;
        public PurchaseOrderRepository(IDbConnection conn)
        {
            _conn = conn;
        }

        public IEnumerable<PurchaseOrder> GetAllPurchaseOrders()
        {
            var allPurchaseOrders = _conn.Query<PurchaseOrder>("SELECT * FROM purchaseorders;");
            foreach (var order in allPurchaseOrders)
            {
                order.ShippingInfo = GetShippingInfo(order.ShippingInfoID);
                order.CarrierInfo = GetCarrierInfo(order.CarrierInfoID);
                order.WorkOrders = GetWorkOrders(order.ID);
            }
            return allPurchaseOrders;
        }

        public PurchaseOrder GetPurchaseOrder(int orderID)
        {
            var order = _conn.QuerySingle<PurchaseOrder>("SELECT * FROM purchaseorders WHERE id = @id;", 
                            new { id = orderID});
            order.ShippingInfo = GetShippingInfo(orderID);
            order.CarrierInfo = GetCarrierInfo(orderID);
            order.WorkOrders = GetWorkOrders(orderID);
            return order;
        }

        public ShippingInfo GetShippingInfo(int shippingInfoID)
        {
            var shippingInfo = _conn.QuerySingle<ShippingInfo>("SELECT * FROM shippinginfo WHERE id = @id",
                                new { id = shippingInfoID });
            return shippingInfo;
        }

        public CarrierInfo GetCarrierInfo(int carrierInfoID)
        {
            var carrierInfo = _conn.QuerySingle<CarrierInfo>("SELECT * FROM carrierInfo WHERE id = @id",
                                new { id = carrierInfoID });
            return carrierInfo;
        }
        public IEnumerable<WorkOrder> GetWorkOrders(int orderID)
        {
            var workOrders = _conn.Query<WorkOrder>("SELECT * FROM workorders WHERE purchaseOrderID = @id",
                                new { id = orderID });
            foreach (var order in workOrders)
            {
                //order.Product = _prodRepo.GetProduct(order.ProductID);
                order.Designs = GetDesigns(order.DesignID);
            }

            return workOrders;
        }
        public IEnumerable<Design> GetDesigns(int designID)
        {
            var designs = _conn.Query<Design>("SELECT * FROM designs WHERE id = @id",
                                new { id = designID });
            foreach (var design in designs)
            {
                design.LocationName = GetLocationName(design.LocationID);
            }
            return designs;
        }

        public string GetLocationName(int locationID)
        {
            var location = _conn.QuerySingle<ApparelLocation>($"SELECT * FROM apparellocations WHERE id = @id;", new { id = locationID});
            if (location != null) return location.ApparelLocationName;
            return "NULL";
        }
    }
}



