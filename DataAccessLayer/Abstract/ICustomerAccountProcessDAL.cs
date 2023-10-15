using System;
using EntityLayer.Concrete;

namespace DataAccessLayer.Abstract
{
	public interface ICustomerAccountProcessDAL:IGenericDAL<CustomerAccountProcess>
	{
		List<CustomerAccountProcess> MyLastProcess(int id);
	}
}

