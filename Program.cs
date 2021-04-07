using System;
using System.Collections;
using System.Collections.Generic;

namespace SharpWasher
{
    class Washer
    {
        delegate void Wash(Car car);
        static void Main(string[] args)
        {
            Console.WriteLine("Cars before washing:");
            Garage garage = new Garage();
            Car carA = new Car("carA clean:");
            Car carB = new Car("carB clean:");
            Car carC = new Car("carC clean:");
            Car carD = new Car("carD clean:");
            garage.Add(carA);
            garage.Add(carB);
            garage.Add(carC);
            garage.Add(carD);
            foreach (var car in garage)
            {
                Console.WriteLine(car.name + " " + car.clear);

            }
            Console.WriteLine("Cars after washing:");
            foreach (var car in garage)
            {
                Wash w = WashCar;
                w(car);
                Console.WriteLine(car.name + " " + car.clear);

            }
           
           
        }
        public static void WashCar(Car car) { car.clear = true; }
    }

    
    class Garage : ICollection<Car>
    {
        ICollection<Car> items;
        public Garage()
        {
            
            items = new List<Car>();
        }
        public int Count => items.Count;

        public bool IsReadOnly => items.IsReadOnly;

        public void Add(Car item)
        {
            items.Add(item);
        }

        public void Clear()
        {
            items.Clear();
        }

        public bool Contains(Car item)
        {
           return items.Contains(item);
        }

        public void CopyTo(Car[] array, int arrayIndex)
        {
            items.CopyTo(array, arrayIndex);
        }

        public IEnumerator<Car> GetEnumerator()
        {
           return items.GetEnumerator();
        }

        public bool Remove(Car item)
        {
           return items.Remove(item);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
           return items.GetEnumerator();
        }
    }
    public class Car
    {
        public Car() { }
        public Car(string name)
        {
            this.name = name;
            this.clear = false;
        }
        public string name{ get; set; }

        public bool clear { get; set; }
    }
  
}
