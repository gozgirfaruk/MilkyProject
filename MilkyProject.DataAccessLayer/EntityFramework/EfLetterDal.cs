using MilkyProject.DataAccessLayer.Abstract;
using MilkyProject.DataAccessLayer.Context;
using MilkyProject.DataAccessLayer.Repositories;
using MilkyProject.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MilkyProject.DataAccessLayer.EntityFramework
{
    public class EfLetterDal : GenericRepository<MailLetter>, ILetterDal
    {
        public EfLetterDal(MilkyContext context) : base(context)
        {
        }
    }
}
