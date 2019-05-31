using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace Taha.Framework.WebAPI
{

    public interface IController<T>
        where T : class
    {

        IHttpActionResult GetAll();
        IHttpActionResult GetByID(Guid ID);
        IHttpActionResult Insert(List<T> value);
        //IHttpActionResult Update(List<T> value);
        //IHttpActionResult Delete(List<Guid> ID);
        //IHttpActionResult Save();

    }
}
