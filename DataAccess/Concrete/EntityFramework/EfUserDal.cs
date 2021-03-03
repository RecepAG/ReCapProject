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
    public class EfUserDal : EfEntityRepositoryBase<User, CarSqlQueryContext>, IUserDal
    {
        public List<RentDetailDto> GetRentDetails()
        {
            using (CarSqlQueryContext context =new CarSqlQueryContext())
            {
                var result = from c in context.Customers
                             join u in context.Users
                             on c.UserId equals u.UserId
                             select new RentDetailDto { UserId=u.UserId};
                return result.ToList();

            }
        }
    }
}
