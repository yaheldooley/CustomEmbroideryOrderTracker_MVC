using CustomEmbroideryOrderTracker_MVC.Models;
using Microsoft.AspNetCore.Mvc;

namespace CustomEmbroideryOrderTracker_MVC.Controllers
{
    public class PurchaseOrderController : Controller
    {
        private readonly IPurchaseOrderRepository repo;
        private readonly IProductRepository productRepo;
        public PurchaseOrderController(IPurchaseOrderRepository repo, IProductRepository productRepo)
        {
            this.repo = repo;
            this.productRepo = productRepo;
        }

        public IActionResult Index()
        {
            var purchaseOrders = repo.GetAllPurchaseOrders();
            return View(purchaseOrders);
        }

        public IActionResult ViewOrder(int id)
        {
            var purchaseOrder = repo.GetPurchaseOrder(id);
            foreach(var order in purchaseOrder.WorkOrders)
            {
                order.Product = productRepo.GetProduct(order.ProductID);
            }
            return View(purchaseOrder);
        }

    }
}
