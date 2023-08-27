using System;
using DataAccessLayer.Abstract;
using DataAccessLayer.Repositories;
using EntityLayer.Concrete;

namespace DataAccessLayer.EntityFramework
{
	public class EfCustomerAccountProcessDAL:GenericRepository<CustomerAccountProcess>,ICustomerAccountProcessDAL
	{
		
	}
}

