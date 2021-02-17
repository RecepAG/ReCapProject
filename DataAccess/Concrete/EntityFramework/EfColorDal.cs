using DataAccess.Abstract;
using System;
using System.Collections.Generic;
using Entities.Concrete;
using System.Linq.Expressions;
using System.Text;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfColorDal : IColorDal

    {
        public void Add(Color entity)
        {
            using (CarSqlQueryContext context = new CarSqlQueryContext())
            {
                var addedEntity = context.Entry(entity);
                addedEntity.State = EntityState.Added;
                context.SaveChanges();
            }
        }

        public void Delete(Color entity)
        {
            using (CarSqlQueryContext context = new CarSqlQueryContext())
            {
                var deletedEntity = context.Entry(entity);
                deletedEntity.State = EntityState.Deleted;
                context.SaveChanges();
            }
        }

        public Color Get(Expression<Func<Color, bool>> filter)
        {
            using (CarSqlQueryContext context = new CarSqlQueryContext())
            {
                return context.Set<Color>().SingleOrDefault(filter);

            }
        }

        public List<Color> GetAll(Expression<Func<Color, bool>> filter = null)
        {
            using (CarSqlQueryContext context = new CarSqlQueryContext())
            {
                return filter == null
                    ? context.Set<Color>().ToList()
                    : context.Set<Color>().Where(filter).ToList();

            }
        }

        public void Update(Color entity)
        {
            using (CarSqlQueryContext context = new CarSqlQueryContext())
            {
                var updatedEntity = context.Entry(entity);
                updatedEntity.State = EntityState.Modified;
                context.SaveChanges();
            }
        }

    }
}
