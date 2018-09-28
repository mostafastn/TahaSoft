using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Taha.Repository;

namespace Taha.Test.Repository
{
    [TestFixture]
    public class impBaseRepositoryTest
    {
        [Test]
        public void GetAll()
        {
            var rep = new impBaseRepository();
            var res = rep.GetAll(orderBy: (t => t.OrderBy(u => u.Periority)));
            Assert.AreEqual(res.succeed, true);
        }
    }
}
