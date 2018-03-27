using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Intro_To_Linq
{
    class Product
    {
        public string Name { get; set; }
        public int Price { get; set; }
        public string Manufacturer { get; set; }
        public int Count { get; set; }

        public override string ToString()
        {
            return $"{Name} {Price} {Manufacturer} {Count}";
        }
    }
 
    class Program
    {
        
        static void Main(string[] args)
        {
            //LinqMethodQueryStyle();
            //LinqMethodMethodStyle();
            //LinqMethodMethodStyleWithOrderBy();
            LinqMethodToObject();
        }

        private static void LinqMethodToObject()
        {
            Random random = new Random();
            string[] countries = { "Albania", "UK", "Lithuania", "Andorra", "Austria",
                "Latvia", "Liechtenstein", "Switzerland",
                "Ireland", "Sweden","Italy", "France",
                "Liechtenstein", "Spain", "Turkey", "Germany",
                "Switzerland", "Monaco", "Montenegro",
                "Norway", "Finland", "Turkey", "UK", "Poland",
                "Portugal", "Lithuania", "Luxembourg" };

            //источник данных - список
            List<Product> products = new List<Product>();
            for (int i = 0; i < 100; i++)
            {
                products.Add(
                   new Product {
                       Name = "Product" + (i),
                       Price = (random.Next(0, 1000)),
                       Manufacturer = countries[random.Next(0, countries.Length - 1)],
                       Count = (random.Next(0, 10))
                    });
            }

            // All product
            //Console.WriteLine("All Products");
            //foreach (var item in products)
            //{
            //    Console.WriteLine(item);
            //}

            var result = from product in products
                         where product.Price < 500
                         orderby product.Price
                         select product;
            
            foreach (var item in result)
            {
                Console.WriteLine(item);
            }

            var result2 = from product in products
                         where product.Price < 500
                         orderby product.Price
                         select new { product.Name, product.Price };
            foreach (var item in result2)
            {
                Console.WriteLine(item.GetType().Name);
                Console.WriteLine(item);
            }


            //Method Style
            var result3 = products.Where(product => product.Price < 500).Select(product => new { product.Name, product.Price });
            foreach (var item in result3)
            {
                Console.WriteLine(item);
            }

        }

        private static void LinqMethodMethodStyleWithOrderBy()
        {
            string[] countries = { "Albania", "UK", "Lithuania", "Andorra", "Austria",
                "Latvia", "Liechtenstein", "Switzerland",
                "Ireland", "Sweden","Italy", "France",
                "Liechtenstein", "Spain", "Turkey", "Germany",
                "Switzerland", "Monaco", "Montenegro",
                "Norway", "Finland", "Turkey", "UK", "Poland",
                "Portugal", "Lithuania", "Luxembourg" };
            //Query style
            //Сортировка от меньшего к большему
            var result = from c in countries where c.StartsWith("L") orderby c.Length select c;
            //Сортировка от большего к меньшему
            var result2 = from c in countries where c.StartsWith("L") orderby c.Length descending select c;
            foreach (var item in result)
            {
                Console.WriteLine(item);
            }
            foreach (var item in result2)
            {
                Console.WriteLine(item);
            }

            //Method style 
            var result3 = countries.Where(c=>c.StartsWith("L")).OrderBy(c => c.Length);
            foreach (var item in result3)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine();

            var result4 = countries.OrderBy((x) => x.Length).Where(c=>c.StartsWith("L")).Distinct();
            foreach (var item in result4)
            {
                Console.WriteLine(item);
            }
        }  
        private static void LinqMethodQueryStyle()
        {
            //Массив строк
            string[] countries = { "Albania", "UK", "Lithuania", "Andorra", "Austria",
                "Latvia", "Liechtenstein", "Switzerland",
                "Ireland", "Sweden","Italy", "France",
                "Liechtenstein", "Spain", "Turkey", "Germany",
                "Switzerland", "Monaco", "Montenegro",
                "Norway", "Finland", "Turkey", "UK", "Poland",
                "Portugal", "Lithuania", "Luxembourg" };

            //Linq запрос
            var result = (from c in countries where c.StartsWith("L") select c).Distinct();

            foreach (var item in result)
            {
                Console.WriteLine(item);
            }
        }
        private static void LinqMethodMethodStyle()
        {
            string[] countries = { "Albania", "UK", "Lithuania", "Andorra", "Austria",
                "Latvia", "Liechtenstein", "Switzerland",
                "Ireland", "Sweden","Italy", "France",
                "Liechtenstein", "Spain", "Turkey", "Germany",
                "Switzerland", "Monaco", "Montenegro",
                "Norway", "Finland", "Turkey", "UK", "Poland",
                "Portugal", "Lithuania", "Luxembourg" };

            //Linq Query
            var result = countries.Where((c) => c.StartsWith("L"));
            foreach (var item in result)
            {
                Console.WriteLine(item);
            }
        }
    }
}
