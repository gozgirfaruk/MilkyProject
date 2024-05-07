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
    public class AddressMenager : IAddressService
    {
        private readonly IAddressDal _addressDal;

        public AddressMenager(IAddressDal addressDal)
        {
            _addressDal = addressDal;
        }

        public void TDelete(Address entity)
        {
            _addressDal.Delete(entity);
        }

        public List<Address> TGetAll()
        {
            return _addressDal.GetAll();
        }

        public Address TGetByID(int id)
        {
           return _addressDal.GetByID(id);
        }

        public void TInsert(Address entity)
        {
            _addressDal.Insert(entity);
        }

        public void TUpdate(Address entity)
        {
            _addressDal.Update(entity);
        }
    }
}
