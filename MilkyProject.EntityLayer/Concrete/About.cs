using Microsoft.Extensions.Primitives;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MilkyProject.EntityLayer.Concrete
{
    public class About
    {
        public int AboutID { get; set; }
        public string Header { get; set; }
        public string Title { get; set; }
        public int Since { get; set; }
        public string FirstIconUrl { get; set; }
        public string FirstTitle { get; set; }
        public string FirstDescription { get; set; }
        public string SecondIconUrl { get; set; }
        public string SecondTitle { get; set; }
        public string SecondDescription { get; set; }
    }
}
