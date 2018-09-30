using System;
using System.Collections.Generic;
using System.Linq;
using Taha.Domains;
using Taha.Repository;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            var repository = new CategoryRepository();

            var categoryList = new List<Category>()
            {
                new Category() {Name = "product A", Periority = 1},
                new Category() {Name = "product B", Periority = 2},
                new Category() {Name = "product C", Periority = 3},
                new Category() {Name = "product D", Periority = 4}
            };

            var result = repository.Insert(categoryList);
            if (result.succeed)
            {
                Console.WriteLine(" Insert Date " + result.Result.Count());
            }

            var res = repository.GetAll(orderBy: (t => t.OrderBy(u => u.Periority)));
            if (res.succeed)
            {
                foreach (var item in res.Result)
                {
                    Console.WriteLine(item.Name + " > " + item.Periority + " > Insert Date" + item.InsertDate);
                }
            }

            Console.ReadLine();


        }
    }
}
