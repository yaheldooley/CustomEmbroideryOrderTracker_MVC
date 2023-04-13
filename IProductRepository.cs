using CustomEmbroideryOrderTracker_MVC.Models;

namespace CustomEmbroideryOrderTracker_MVC
{
	public interface IProductRepository
	{
        #region Create Methods
        public Product StartNewProduct();
        public void InsertProduct(Product productToInsert);

        #endregion

        #region Read Methods

        public IEnumerable<Product> GetAllProducts();
        public Product GetProduct(int id);
        public Product GetAllProductOptions(Product product);
        public IEnumerable<Article> GetAllArticles();
        public IEnumerable<Color> GetAllColors();
        public IEnumerable<Size> GetAllSizes();

        public String GetColorName(int colorId);
        public String GetSizeName(int sizeId);
        public string GetArticleName(int articleId);

        #endregion

        public void UpdateProduct(Product product);
        public void DeleteProduct(int productID);
       
    }
}
