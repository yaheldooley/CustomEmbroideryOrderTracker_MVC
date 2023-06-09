﻿using CustomEmbroideryOrderTracker_MVC.Models;
using Microsoft.AspNetCore.Mvc;

namespace CustomEmbroideryOrderTracker_MVC.Controllers
{
	public class ProductController : Controller
	{
		private readonly IProductRepository repo;

		public ProductController(IProductRepository repo)
		{
			this.repo = repo;
		}

		public IActionResult Index()
		{
			var products = repo.GetAllProducts();
			return View(products);
		}

		public IActionResult ViewProduct(int id)
		{
			var product = repo.GetProduct(id);
			return View(product);
		}

		public IActionResult UpdateProduct(int id)
		{
			Product prod = repo.GetProduct(id);

			if (prod == null)
			{
				return View("Product not found");
			}
			else repo.GetAllProductOptions(prod);

			return View(prod);
		}

        public IActionResult UpdateProductToDatabase(Product product)
		{
			repo.UpdateProduct(product);

			return RedirectToAction("ViewProduct", new { id = product.ProductID });
		}

		public IActionResult InsertProduct()
		{
			var prod = repo.StartNewProduct();

			return View(prod);
		}

		public IActionResult InsertProductToDatabase(Product productToInsert)
		{
			repo.InsertProduct(productToInsert);

			return RedirectToAction("Index");
		}

        public IActionResult RemoveProductFromDatabase(int id)
        {
            repo.DeleteProduct(id);

            return RedirectToAction("Index");
        }
    }
}
