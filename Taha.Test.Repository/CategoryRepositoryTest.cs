using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using Taha.Domains;
using Taha.Repository;

namespace Taha.Test.Repository
{
    [TestFixture]
    public class CategoryRepositoryTest
    {
        [Test]
        public void GetAll()
        {
            var categoryRepository = new CategoryRepository();
            var res = categoryRepository.GetAll(orderBy: (t => t.OrderBy(u => u.Periority)));
            Assert.AreEqual(res.succeed ,true);
        }

        [Test]
        public void Insert()
        {
            var categoryRepository = new CategoryRepository();

            var categoryList = new List<Category>()
            {
                new Category() {Name = "product A", Periority = 1},
                new Category() {Name = "product B", Periority = 2},
                new Category() {Name = "product C", Periority = 3},
                new Category() {Name = "product D", Periority = 4}
            };

            var result = categoryRepository.Insert(categoryList);
            Assert.AreEqual(result.succeed, true);
        }


    }
}
