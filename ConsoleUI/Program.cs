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
            

            //BrandTest();

            //ColorTest();

            CarManager carManager = new CarManager(new EfCarDal());

            var result = carManager.GetCarDetails();

            if (result.Success==true)
            {
                foreach (var car in carManager.GetCarDetails().Data)
                {
                    Console.WriteLine(car.CarId + " / " + car.BrandName + " / " + car.ColorName + " / " + car.ModelYear);

                }
            }
            else
            {
                Console.WriteLine(result.Message);
            }







        }

        private static void ColorTest()
        {
            ColorManager colorManager = new ColorManager(new EfColorDal());
            foreach (var color in colorManager.GetAll().Data)
            {
                Console.WriteLine(color.ColorName);
            }
        }

        private static void BrandTest()
        {
            BrandManager brandManager = new BrandManager(new EfBrandDal());
            foreach (var brand in brandManager.GetAll().Data)
            {
                Console.WriteLine(brand.BrandName);
            }
        }
    }
}
