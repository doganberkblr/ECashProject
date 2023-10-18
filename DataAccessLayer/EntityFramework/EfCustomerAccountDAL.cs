using System;
using DataAccessLayer.Abstract;
using DataAccessLayer.Repositories;
using ECashProject.DataAccessLayer.Concrete;
using EntityLayer.Concrete;

namespace DataAccessLayer.EntityFramework
{
    public class EfCustomerAccountDAL : GenericRepository<CustomerAccount>, ICustomerAccountDAL
    {
        public List<CustomerAccount> GetCustomerAccountsList(int id)
        {
            using var context = new Context();
            var values = context.CustomerAccounts.Where(x=>x.AppUserID==id).ToList();
            return values;
        }
    }
}

