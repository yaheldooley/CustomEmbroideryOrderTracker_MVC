using CustomEmbroideryOrderTracker_MVC.Models;
using Microsoft.AspNetCore.Mvc;

namespace CustomEmbroideryOrderTracker_MVC.Controllers
{
    public class PurchaseOrderController : Controller
    {
        private readonly IPurchaseOrderRepository repo;

        public PurchaseOrderController(IPurchaseOrderRepository repo)
        {
            this.repo = repo;
        }

        public IActionResult Index()
        {
            var purchaseOrders = repo.GetAllPurchaseOrders();
            return View(purchaseOrders);
        }

        public IActionResult ViewOrder(int id)
        {
            var purchaseOrder = repo.GetPurchaseOrder(id);
            return View(purchaseOrder);
        }

    }
}
