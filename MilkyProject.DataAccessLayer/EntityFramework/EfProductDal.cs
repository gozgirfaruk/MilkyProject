using Microsoft.EntityFrameworkCore;
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
    public class EfProductDal : GenericRepository<Product>, IProductDal
    {
        public EfProductDal(MilkyContext context) : base(context)
        {
        }

        public List<Product> GetProductWithCategory()
        {
            var context = new MilkyContext();
            var values = context.Products.Include(x=>x.Category).Select(y=>new Product
            {
               NewPrice=y.NewPrice,
               Name=y.Name,
               CategoryID=y.CategoryID,
               ImageUrl=y.ImageUrl,
               OldPrice=y.OldPrice,
               ProductID=y.ProductID,
               Status=y.Status,
               Category= new Category { Name=y.Category.Name}
            }).ToList();
            return values;
        }
    }
}
