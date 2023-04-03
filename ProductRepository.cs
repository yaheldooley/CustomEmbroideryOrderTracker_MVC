﻿using CustomEmbroideryOrderTracker_MVC.Models;
using Dapper;
using System.Data;
using System.Runtime.InteropServices;

namespace CustomEmbroideryOrderTracker_MVC
{
	public class ProductRepository : IProductRepository
	{
		private readonly IDbConnection _conn;

		public ProductRepository(IDbConnection conn)
		{
			_conn = conn;
		}


		public Product AssignCategory()
		{
			var categoryList = GetCategories();
			var product = new Product();
			product.Categories = categoryList;

			return product;
		}

		public IEnumerable<Product> GetAllProducts()
		{
			return _conn.Query<Product>("Select * From products;");
		}

		public IEnumerable<Category> GetCategories()
		{
			return _conn.Query<Category>("SELECT * FROM categories;");
		}

		public Product GetProduct(int id)
		{
			return _conn.QuerySingle<Product>("SELECT * FROM PRODUCTS WHERE PRODUCTID = @id", 
				new { id = id});
		}

		public void InsertProduct(Product productToInsert)
		{
			_conn.Execute("INSERT INTO products (NAME, PRICE, CATEGORYID) VALUES (@name, @price, @categoryID);",
				new { name = productToInsert.Name, price = productToInsert.Price, categoryID = productToInsert.CategoryID });
		}

		public void UpdateProduct(Product product)
		{
			_conn.Execute("UPDATE products SET Name = @name, Price = @price WHERE ProductID = @id",
				new { name = product.Name, price = product.Price, id = product.ProductID});
		}
	}
}
