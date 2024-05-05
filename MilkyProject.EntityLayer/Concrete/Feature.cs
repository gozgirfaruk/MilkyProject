using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MilkyProject.EntityLayer.Concrete
{
    public class Feature
    {
        public int FeatureID { get; set; }
        public string Header { get; set; }
        public string Description { get; set; }
        public string FirstCallOut { get; set; }
        public string SecondCallOut { get; set; }
        public string ThirdCallOut { get; set; }
    }
}
