using System;
using EntityLayer.Concrete;

namespace BusinessLayer.Abstract
{
	public interface ICustomerAccountProcessService:IGenericService<CustomerAccountProcess  >
	{
        List<CustomerAccountProcess> TMyLastProcess(int id);
    }
}

