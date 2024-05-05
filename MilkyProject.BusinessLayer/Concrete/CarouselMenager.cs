using MilkyProject.BusinessLayer.Abstract;
using MilkyProject.DataAccessLayer.Abstract;
using MilkyProject.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace MilkyProject.BusinessLayer.Concrete
{
    public class CarouselMenager : ICarouselService
    {
        private readonly ICarouselDal _carouselDal;

        public CarouselMenager(ICarouselDal carouselDal)
        {
            _carouselDal = carouselDal;
        }

        public void TDelete(Carousel entity)
        {
           _carouselDal.Delete(entity);
        }

        public List<Carousel> TGetAll()
        {
            return _carouselDal.GetAll();
        }

        public Carousel TGetByID(int id)
        {
            return _carouselDal.GetByID(id);
        }

        public void TInsert(Carousel entity)
        {
            _carouselDal.Insert(entity);
        }

        public void TUpdate(Carousel entity)
        {
            _carouselDal.Update(entity);
        }
    }
}
