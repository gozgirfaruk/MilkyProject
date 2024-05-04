namespace MilkyProject.WebUI.DTOS.ProductDto
{
    public class CreateProduct
    {
        public string name { get; set; }
        public float oldPrice { get; set; }
        public float newPrice { get; set; }
        public string imageUrl { get; set; }
        public bool status { get; set; }
    }
}
