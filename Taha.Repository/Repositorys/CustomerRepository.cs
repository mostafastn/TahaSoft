using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using Taha.DatabaseInitilization;
using Taha.DatabaseInitilization.Domains;
using Taha.Framework.Infrastructure;
using Taha.Framework.Repository;
using Taha.Repository.Models;

namespace Taha.Repository.Repositorys
{
    public class CustomerRepository : BaseRepository<TahaDatabaseContext, tbl_Customer, Customer>
    {
        #region Imprlementation BaseRepository

        public override IQueryable<tbl_Customer> ToEntityQueryable(IQueryable<Customer> values)
        {
            var tblMenus = values.Select(t => new tbl_Customer()
            {
                fldID = t.ID
            });

            return tblMenus;
        }

        public override IQueryable<Customer> ToObjectQueryable(IQueryable<tbl_Customer> values)
        {
            var menus = values.Select(t => new Customer()
            {
                ID = t.fldID
            });

            return menus;
        }

        #endregion

        #region Overide Methods

        public override RepositoryResult<IEnumerable<Customer>> Insert(List<Customer> value)
        {
            var result = new RepositoryResult<IEnumerable<Customer>>()
            {
                Result = null,
                Message = "",
                succeed = false
            };

            try
            {
                //برای ذخیره مشتری
                //1- لزوما باید مشتری با کلید متناظر در جدول اشخاص و جود داشته باشد
                //2- نباید مشتری با کلید ارسالی در جدول مشتری وجود داشته باشد 

                var customerIDs = value.Select(t => t.ID).ToList();
                var personsQuery = from person in curentContext.Tbl_Persons
                                   join customer in curentContext.tbl_Customer
                                       on person.fldID equals customer.fldID into customers
                                   from customer in customers.DefaultIfEmpty()
                                   where customerIDs.Contains(person.fldID)
                                   select new { person, customer };
                
                var personsList = personsQuery
                    .Where(t => t.customer == null)
                    .ToList();
                var customerList = personsList.Select(t => new Customer()
                {
                    ID = t.person.fldID
                });

                if (customerList != null && !customerList.Any(t => t == null))
                {
                    var queryable = ToEntityQueryable(customerList.AsQueryable());
                    curentContext.tbl_Customer.AddRange(queryable);
                    curentContext.SaveChanges();
                    result.Result = value;
                    result.succeed = true;
                }
                else
                {
                    result.succeed = false;
                    result.Message = "value or one of the items is null";
                }
            }
            catch (Exception ex)
            {
                result.Message = ex.Message;
            }

            return result;
        }
        #endregion
    }
}
