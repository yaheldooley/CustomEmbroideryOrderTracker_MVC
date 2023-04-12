using CustomEmbroideryOrderTracker_MVC.Models;

namespace CustomEmbroideryOrderTracker_MVC
{
	public interface IProductRepository
	{
		public IEnumerable<Product> GetAllProducts();
		public Product GetProduct(int id);
		public void UpdateProduct(Product product);
		public void InsertProduct(Product productToInsert);
        public Product StartNewProduct();
        public IEnumerable<Article> GetAllArticles();
		public IEnumerable<Color> GetAllColors();
		public IEnumerable<Size> GetAllSizes();

		public String GetColorName(int colorId);
		public String GetSizeName(int sizeId);
		public string GetArticleName(int articleId);
		

	}
}
