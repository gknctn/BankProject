using BankProject.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankProject.EntityLayer.Abstract
{
    public interface ICustomerAccountDal : IGenericDal<CustomerAccount>
    {
    }
}
