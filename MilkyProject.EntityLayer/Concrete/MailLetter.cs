using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MilkyProject.EntityLayer.Concrete
{
    public class MailLetter
    {
        [Key]
        public int LetterID { get; set; }
        public string Mail { get; set; }

    }
}
