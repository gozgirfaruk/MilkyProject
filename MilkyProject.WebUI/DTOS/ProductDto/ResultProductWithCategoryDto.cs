namespace MilkyProject.WebUI.DTOS.ProductDto
{
    public class ResultProductWithCategoryDto
    {
        public int ProductID { get; set; }
        public string Name { get; set; }
        public decimal OldPrice { get; set; }
        public decimal NewPrice { get; set; }
        public string ImageUrl { get; set; }
        public bool Status { get; set; }
        public int CategoryID { get; set; }
        public Category category { get; set; }
        public class Category
        {
            public string Name { get; set; }
        }
    }
}
