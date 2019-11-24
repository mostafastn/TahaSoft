using System.Collections.Generic;
using System.Linq;
using Taha.DatabaseInitilization;
using Taha.DatabaseInitilization.Domains;
using Taha.Framework.Repository;
using Taha.Repository.Models;

namespace Taha.Repository.Repositorys
{
    public class PersonRepository : BaseRepository<TahaDatabaseContext, tbl_Person, Person>
    {
        
        public override IQueryable<tbl_Person> ToEntityQueryable(IQueryable<Person> values)
        {
            var tblPerson = values.Select(t => new tbl_Person()
            {
                fldID = t.ID,
                fldFirstName= t.FirstName,
                fldLastName= t.LastName,
                fldSSN= t.SSN,
                fldPhone = t.Phone,
                fldEmail= t.Email,
                fldAddress = t.Address,
            });

            return tblPerson;
        }

        public override IQueryable<Person> ToObjectQueryable(IQueryable<tbl_Person> values)
        {
            var persons = values.Select(t => new Person()
            {
                ID = t.fldID,
                FirstName = t.fldFirstName,
                LastName = t.fldLastName,
                SSN = t.fldSSN,
                Phone = t.fldPhone,
                Email = t.fldEmail,
                Address = t.fldAddress,
            });

            return persons;
        }
    }
}
