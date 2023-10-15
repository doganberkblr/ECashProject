using System;
using DataAccessLayer.Abstract;
using DataAccessLayer.Repositories;
using ECashProject.DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.EntityFramework
{
    public class EfCustomerAccountProcessDAL : GenericRepository<CustomerAccountProcess>, ICustomerAccountProcessDAL
    {
        public List<CustomerAccountProcess> MyLastProcess(int id)
        {
            using var context = new Context();
            var values = context.CustomerAccountProcesses.Include(y=>y.SenderCustomer).ThenInclude(z=>z.AppUser).Include(w=>w.ReceiverCustomer).Where(x => x.ReceiverID == id || x.SenderID == id).ToList();
            return values;
        }
    }
}

