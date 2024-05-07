using MilkyProject.BusinessLayer.Abstract;
using MilkyProject.DataAccessLayer.Abstract;
using MilkyProject.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MilkyProject.BusinessLayer.Concrete
{
    public class LetterMenager : ILetterService
    {
        private readonly ILetterDal _letterDal;

        public LetterMenager(ILetterDal letterDal)
        {
            _letterDal = letterDal;
        }

        public void TDelete(MailLetter entity)
        {
           _letterDal.Delete(entity);   
        }

        public List<MailLetter> TGetAll()
        {
           return _letterDal.GetAll();
        }

        public MailLetter TGetByID(int id)
        {
            return _letterDal.GetByID(id);
        }

        public void TInsert(MailLetter entity)
        {
            _letterDal.Insert(entity);
        }

        public void TUpdate(MailLetter entity)
        {
           _letterDal.Update(entity);
        }
    }
}
