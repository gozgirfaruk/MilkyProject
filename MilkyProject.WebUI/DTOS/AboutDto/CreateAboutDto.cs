namespace MilkyProject.WebUI.DTOS.AboutDto
{
    public class CreateAboutDto
    {
        public string header { get; set; }
        public string title { get; set; }
        public int since { get; set; }
        public string firstIconUrl { get; set; }
        public string firstTitle { get; set; }
        public string firstDescription { get; set; }
        public string secondIconUrl { get; set; }
        public string secondTitle { get; set; }
        public string secondDescription { get; set; }
    }
}
