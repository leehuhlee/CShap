using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorApp.Data
{
    public class Food
    {
        public string Name { get; set; }
        public int Price { get; set; }
    }

    public interface IFoodService
    {
        IEnumerable<Food> GetFoods();
    }

    public class FoodService : IFoodService
    {
        public IEnumerable<Food> GetFoods()
        {
            List<Food> foods = new List<Food>()
            {
                new Food(){Name = "Bibimbap", Price=7000},
                new Food(){Name = "Kimbap", Price=3000},
                new Food(){Name = "Bossam", Price=9000}
            };

            return foods;
        }
    }
    public class FastFoodService : IFoodService
    {
        public IEnumerable<Food> GetFoods()
        {
            List<Food> foods = new List<Food>()
            {
                new Food(){Name = "Hamburger", Price=5000},
                new Food(){Name = "Fries", Price=2000},
            };

            return foods;
        }
    }

    public class PaymentService
    {
        IFoodService _service;

        public PaymentService(IFoodService service)
        {
            _service = service;

        }
    }

    public class SingletonService : IDisposable
    {
        public Guid ID { get; set; }
        public SingletonService()
        {
            ID = Guid.NewGuid();
        }

        public void Dispose()
        {
            Console.WriteLine("SingletonService Disposed");
        }
    }
    public class TransientService : IDisposable
    {
        public Guid ID { get; set; }
        public TransientService()
        {
            ID = Guid.NewGuid();
        }

        public void Dispose()
        {
            Console.WriteLine("SingletonService Disposed");
        }
    }
    public class ScopeService : IDisposable
    {
        public Guid ID { get; set; }
        public ScopeService()
        {
            ID = Guid.NewGuid();
        }

        public void Dispose()
        {
            Console.WriteLine("SingletonService Disposed");
        }
    }
}
