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
    public class GalleryMenager : IGalleryService
    {
        private readonly IGalleryDal _galleryDal;

        public GalleryMenager(IGalleryDal galleryDal)
        {
            _galleryDal = galleryDal;
        }

        public void TDelete(Gallery entity)
        {
            _galleryDal.Delete(entity);
        }

        public List<Gallery> TGetAll()
        {
            return _galleryDal.GetAll();
        }

        public Gallery TGetByID(int id)
        {
            return _galleryDal.GetByID(id);
        }

        public void TInsert(Gallery entity)
        {
            _galleryDal.Insert(entity);
        }

        public void TUpdate(Gallery entity)
        {
            _galleryDal.Update(entity); 
        }
    }
}
