using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MilkyProject.EntityLayer.Concrete
{
    public class Product
    {
        public int ProductID { get; set; }
        public string? Name { get; set; }
        public decimal OldPrice { get; set; }
        public decimal NewPrice { get; set; }
        public string? ImageUrl { get; set; }
        public bool Status { get; set; }
        public int? CategoryID { get; set; }
        public Category Category { get; set; }

    }
}
