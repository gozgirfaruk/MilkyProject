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
    public class FeatureMenager : IFeatureService
    {
        private readonly IFeatureDal _featureDal;

        public FeatureMenager(IFeatureDal featureDal)
        {
            _featureDal = featureDal;
        }

        public void TDelete(Feature entity)
        {
            _featureDal.Delete(entity); 
        }

        public List<Feature> TGetAll()
        {
            return _featureDal.GetAll();
        }

        public Feature TGetByID(int id)
        {
           return _featureDal.GetByID(id);
        }

        public void TInsert(Feature entity)
        {
           _featureDal.Insert(entity);
        }

        public void TUpdate(Feature entity)
        {
            _featureDal.Update(entity);
        }
    }
}
