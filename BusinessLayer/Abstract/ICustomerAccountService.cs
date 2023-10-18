using System;
using EntityLayer.Concrete;

namespace BusinessLayer.Abstract
{
	public interface ICustomerAccountService:IGenericService<CustomerAccount>
	{
        public List<CustomerAccount> TGetCustomerAccountsList(int id);

    }
}

