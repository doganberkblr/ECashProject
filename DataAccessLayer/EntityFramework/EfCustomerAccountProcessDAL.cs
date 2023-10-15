using System;
using DataAccessLayer.Abstract;
using DataAccessLayer.Repositories;
using ECashProject.DataAccessLayer.Concrete;
using EntityLayer.Concrete;

namespace DataAccessLayer.EntityFramework
{
    public class EfCustomerAccountProcessDAL : GenericRepository<CustomerAccountProcess>, ICustomerAccountProcessDAL
    {
        public List<CustomerAccountProcess> MyLastProcess(int id)
        {
            using var context = new Context();
            var values = context.CustomerAccountProcesses.Where(x => x.ReceiverID == id || x.SenderID == id).ToList();
            return values;
        }
    }
}

