using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using System;

namespace ConsoleUI
{
    public class Program
    {
        static void Main(string[] args)
        {
            CarManager carManager = new CarManager(new EfCarDal());
            foreach (var car in carManager.GetAll())
            {
                Console.WriteLine(car.Descriptions);
            }



            BrandManager brandManager = new BrandManager(new EfBrandDal());
            foreach (var brand in brandManager.GetAll())
            {
                Console.WriteLine(brand.BrandName);
            }

            ColorManager colorManager = new ColorManager(new EfColorDal());

            CarManager carManager1 = new CarManager(new EfCarDal());
            foreach (var car in carManager.GetCarsByBrandId(1))
            {
                Console.WriteLine(car.BrandId);

            }
        }
    }
}
