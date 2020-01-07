using System.Collections.Generic;
using System.Linq;
using Taha.DatabaseInitilization;
using Taha.DatabaseInitilization.Domains;
using Taha.Framework.Repository;
using Taha.Repository.Models;

namespace Taha.Repository.Repositorys
{
    public class UserRepository : BaseRepository<TahaDatabaseContext, tbl_User, User>
    {
        
        public override IQueryable<tbl_User> ToEntityQueryable(IQueryable<User> values)
        {
            var tblPerson = values.Select(t => new tbl_User()
            {
                fldID = t.ID,
                fldPersonID= t.PersonID,
                fldUserName= t.UserName,
                fldPassword= t.Password,
                fldActive= t.Active,
            });

            return tblPerson;
        }

        public override IQueryable<User> ToObjectQueryable(IQueryable<tbl_User> values)
        {
            var persons = values.Select(t => new User()
            {
                ID = t.fldID,
                PersonID = t.fldPersonID,
                UserName = t.fldUserName,
                Password = t.fldPassword,
                Active = t.fldActive,
            });

            return persons;
        }
    }
}
