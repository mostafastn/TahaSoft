using System;
using System.Collections.Generic;
using System.Web.Http;

namespace Taha.Framework.WebAPI
{

    public interface IController<T>
        where T : class
    {
        IHttpActionResult GetAll();
        IHttpActionResult GetByID(Guid ID);
        IHttpActionResult Insert(List<T> value);
        IHttpActionResult Update(List<T> value);
        IHttpActionResult Delete(List<Guid> IDs);
        //IHttpActionResult Save();

    }
}
