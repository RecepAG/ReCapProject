using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : EfEntityRepositoryBase<Car, CarSqlQueryContext>, ICarDal
    {
        public List<CarDetailDto> GetCarDetails()
        {
            using (CarSqlQueryContext context =new CarSqlQueryContext())
            {
                var result = from c in context.Cars
                             join b in context.Brands on c.BrandId equals b.BrandId
                             join x in context.Colors on c.ColorId equals x.ColorId
                             join r in context.Rentals on c.CarId equals r.CarId
                             
                            
                             select new CarDetailDto { CarId = c.CarId, BrandName = b.BrandName, ColorName = x.ColorName, ModelYear = c.ModelYear };
                return result.ToList();


            }
        }
    }
}
