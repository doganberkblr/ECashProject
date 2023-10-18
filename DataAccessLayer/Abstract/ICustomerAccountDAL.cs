using System;
using EntityLayer.Concrete;

namespace DataAccessLayer.Abstract
{
	public interface ICustomerAccountDAL:IGenericDAL<CustomerAccount>
	{
		List<CustomerAccount> GetCustomerAccountsList(int id);
	}
}

