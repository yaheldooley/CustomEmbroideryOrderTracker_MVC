using System.Collections;

namespace CustomEmbroideryOrderTracker_MVC.Models
{
	public class Product
	{
		public int ProductID { get; set; }
		public string Name { get; set; }
		public double Price { get; set; }
        public int ColorID { get; set; }
        public int SizeID { get; set; }
        public int ArticleID { get; set; }
        public int StockLevel { get; set; }

		public IEnumerable<Article> Articles { get; set; }
		public IEnumerable<Color> Colors { get; set; }
        public IEnumerable<Size> Sizes { get; set; }

        public string ColorName { get; set; }
        public string SizeName { get; set; }
        public string ArticleName { get; set; }
    }
}
