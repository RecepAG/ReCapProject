using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryCarDal : ICarDal
    {
        List<Car> _cars;
        public InMemoryCarDal()
        {
            _cars = new List<Car> {
                new Car{CarId=1, CarBrandId=1,ColorId=1,CarModelYear="2020",DailyPrice=250,Description="Uygun Fiyatlara Kiralık Araba"},
                new Car{CarId=2, CarBrandId=1,ColorId=3,CarModelYear="2019",DailyPrice=200,Description="Uygun Fiyatlara Kiralık Araba"},
                new Car{CarId=3, CarBrandId=2,ColorId=3,CarModelYear="2020",DailyPrice=300,Description="Uygun Fiyatlara Kiralık Araba"},
                new Car{CarId=4, CarBrandId=2,ColorId=2,CarModelYear="2019",DailyPrice=270,Description="Uygun Fiyatlara Kiralık Araba"},
                new Car{CarId=5 ,CarBrandId=2,ColorId=2,CarModelYear="2019",DailyPrice=270,Description="Uygun Fiyatlara Kiralık Araba"}
            };
        }



        public void Add(Car car)
        {
            _cars.Add(car);

        }

        public void Delete(Car car)
        {
            Car carToDelete = null;
            carToDelete = _cars.SingleOrDefault(c=>c.CarId==car.CarId);
            _cars.Remove(carToDelete);
        }

        public List<Car> GetAll()
        {
            return _cars;
        }

        

        public void Update(Car car)
        {
            Car carToUpdate = null;
            carToUpdate = _cars.SingleOrDefault(c => c.CarId == car.CarId);
            carToUpdate.CarId = car.CarId;
            carToUpdate.CarBrandId = car.CarBrandId;
            carToUpdate.ColorId = car.ColorId;
            carToUpdate.DailyPrice = car.DailyPrice;
            carToUpdate.Description = car.Description;
            carToUpdate.CarModelYear = car.CarModelYear;


        }

        List<Car> ICarDal.GetById(int brandId)
        {
            return _cars.Where(c => c.CarBrandId == brandId).ToList();
        }
    }
}
