﻿using MilkyProject.BusinessLayer.Abstract;
using MilkyProject.DataAccessLayer.Abstract;
using MilkyProject.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MilkyProject.BusinessLayer.Concrete
{
    public class ServiceMenager : IServiceService
    {
        private readonly IServiceDal _serviceDal;

        public ServiceMenager(IServiceDal serviceDal)
        {
            _serviceDal = serviceDal;
        }

        public void TDelete(Service entity)
        {
            _serviceDal.Delete(entity);
        }

        public List<Service> TGetAll()
        {
            return _serviceDal.GetAll();
        }

        public Service TGetByID(int id)
        {
            return _serviceDal.GetByID(id);
        }

        public void TInsert(Service entity)
        {
            _serviceDal.Insert(entity);
        }

        public void TUpdate(Service entity)
        {
           _serviceDal.Update(entity);
        }
    }
}
