using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Taha.DatabaseInitilization;
using Taha.Domains;
using Taha.Repository;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {

            //using (var context = new TahaDatabaseContext())
            //{
            //    var categoryList = new List<Category>() {
            //        new Category() { Name="عطر",Periority=1},
            //        new Category() { Name="ادکلن",Periority=2},
            //        new Category() { Name="کریستال",Periority=3 },
            //        new Category() { Name="اسپری",Periority=4  }
            //    };
            //    context.Categories.AddRange(categoryList);
            //    context.SaveChanges();
            //    Console.WriteLine("kir");
            //    Console.ReadLine();
            //}

            var rep = new CategoryRepository();
            var res = rep.GetAll( orderBy:(t=>t.OrderBy(u=>u.Periority)));
            foreach (var item in res.Result)
            {
                Console.WriteLine(item.Name + " > " + item.Periority + " > Insert Date" + item.InsertDate);
            }
            Console.ReadLine();


        }
    }
}
