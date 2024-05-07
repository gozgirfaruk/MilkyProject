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
    public class TestimonialMenager : ITestimonialService
    {
        private readonly ITestimonialDal _testimonialDal;

        public TestimonialMenager(ITestimonialDal testimonialDal)
        {
            _testimonialDal = testimonialDal;
        }

        public void TDelete(Testimonial entity)
        {
            _testimonialDal.Delete(entity);
        }

        public List<Testimonial> TGetAll()
        {
            return _testimonialDal.GetAll();
        }

        public Testimonial TGetByID(int id)
        {
            return _testimonialDal.GetByID(id);
        }

        public void TInsert(Testimonial entity)
        {
            _testimonialDal.Insert(entity);
        }

        public void TUpdate(Testimonial entity)
        {
           _testimonialDal.Update(entity);
        }
    }
}
