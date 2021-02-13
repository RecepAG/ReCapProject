using Business.Concrete;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using System;

namespace ConsoleUI
{
    public class Program
    {
        static void Main(string[] args)
        {
            CarManager carManager = new CarManager(new InMemoryCarDal());

            foreach (var car in carManager.GetAll())
            {
                Console.WriteLine("------Rental Cars------");
                Console.WriteLine("Car ID : "+car.CarId);
                Console.WriteLine("Brand : "+car.CarBrandId);
                Console.WriteLine("Color : "+car.ColorId);
                Console.WriteLine("Model Year : "+car.CarModelYear);
                Console.WriteLine("Daily Price : "+car.DailyPrice);
            }
        }
    }
}
