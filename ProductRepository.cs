using CustomEmbroideryOrderTracker_MVC.Models;
using Dapper;
using System.Data;

namespace CustomEmbroideryOrderTracker_MVC
{

    public class ProductRepository : IProductRepository
	{
		private readonly IDbConnection _conn;

		public ProductRepository(IDbConnection conn)
		{
			_conn = conn;
		}

        #region Products

        #region Create

        public Product StartNewProduct()
		{
            var product = new Product();
			return GetAllProductOptions(product);
		}

        public void InsertProduct(Product productToInsert)
        {
            _conn.Execute("INSERT INTO products (NAME, PRICE, STOCKLEVEL, ARTICLEID, SIZEID, COLORID) VALUES (@name, @price, @stockLevel, @articleID, @sizeID, @colorID);",
                new
                {
                    name = productToInsert.Name,
                    price = productToInsert.Price,
                    stockLevel = productToInsert.StockLevel,
                    articleID = productToInsert.ArticleID,
                    sizeID = productToInsert.SizeID,
                    colorID = productToInsert.ColorID
                });
        }

        #endregion

        #region Read

        public Product GetAllProductOptions(Product product)
		{
            var articleList = GetAllArticles();
            product.Articles = articleList;

            var colorsList = GetAllColors();
            product.Colors = colorsList;

            var sizesList = GetAllSizes();
            product.Sizes = sizesList;
			return product;
        }
        public IEnumerable<Product> GetAllProducts()
		{
			var allProducts = _conn.Query<Product>("Select * From products;");
			foreach(var product in allProducts)
			{
				product.ColorName = GetColorName(product.ColorID);
				product.ArticleName = GetArticleName(product.ArticleID);
				product.SizeName = GetSizeName(product.SizeID);
			}
            return allProducts;
		}
		public IEnumerable<Article> GetAllArticles()
		{
			return _conn.Query<Article>("SELECT * FROM articles;");
		}
        public IEnumerable<Models.Color> GetAllColors()
		{
			return _conn.Query<Models.Color>("SELECT * FROM colors");
		}
        public IEnumerable<Models.Size> GetAllSizes()
        {
            return _conn.Query<Models.Size>("SELECT * FROM sizes");
        }

        public String GetColorName(int colorId)
        {
            return _conn.QuerySingle<Models.Color>("SELECT * FROM COLORS WHERE ID = @id",
                    new { id = colorId }).ColorName;
        }
        public String GetSizeName(int sizeId)
        {
            return _conn.QuerySingle<Models.Size>("SELECT * FROM SIZES WHERE ID = @id",
                        new { id = sizeId }).SizeName;
        }
        public string GetArticleName(int articleId)
        {
            return _conn.QuerySingle<Models.Article>("SELECT * FROM ARTICLES WHERE ID = @id",
                        new { id = articleId }).ArticleName;
        }

        public Product GetProduct(int id)
        {
            var product = _conn.QuerySingle<Product>("SELECT * FROM PRODUCTS WHERE PRODUCTID = @id",
                new { id = id });
            product.ColorName = GetColorName(product.ColorID);
            product.ArticleName = GetArticleName(product.ArticleID);
            product.SizeName = GetSizeName(product.SizeID);
            return product;
        }

        #endregion

        #region Update
        public void UpdateProduct(Product product)
		{
			_conn.Execute("UPDATE products SET Name = @name, Price = @price, ColorID = @colorID, SizeID = @sizeID, ArticleID = @articleID WHERE ProductID = @id",
			new { name = product.Name, price = product.Price, colorID = product.ColorID, sizeID =  product.SizeID, articleID = product.ArticleID, id = product.ProductID});
		}

        #endregion

        #region Delete

        public void DeleteProduct(int productID)
		{
			_conn.Execute("DELETE FROM products WHERE productID = @id;",
			new { id = productID});
		}

        #endregion

        #endregion



    }
}
