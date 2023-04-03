using Microsoft.AspNetCore.Mvc;

namespace CustomEmbroideryOrderTracker_MVC.Controllers
{
	public class OrderController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}
