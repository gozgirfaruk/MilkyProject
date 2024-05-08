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
    public class AdminMenager : IAdminService
    {
        private readonly IAdminDal _adminDal;

        public AdminMenager(IAdminDal adminDal)
        {
            _adminDal = adminDal;
        }

        public void TDelete(Admin entity)
        {
            _adminDal.Delete(entity);
        }

        public List<Admin> TGetAll()
        {
            return _adminDal.GetAll();
        }

        public Admin TGetByID(int id)
        {
            return _adminDal.GetByID(id);
        }

        public void TInsert(Admin entity)
        {
            _adminDal.Insert(entity);
        }

        public void TUpdate(Admin entity)
        {
            _adminDal.Update(entity);
        }
    }
}
