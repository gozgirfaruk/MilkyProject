namespace MilkyProject.WebUI.DTOS.ProductDto
{
    public class UpdateProductDto
    {
        public int productID { get; set; }
        public string name { get; set; }
        public float oldPrice { get; set; }
        public float newPrice { get; set; }
        public string imageUrl { get; set; }
        public bool status { get; set; }
    }
}
