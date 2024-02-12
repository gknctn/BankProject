using BankProject.BusinessLayer.Abstract;
using BankProject.EntityLayer.Abstract;
using BankProject.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankProject.BusinessLayer.Concrete
{
    public class CustomerAccountManager : ICustomerAccountService
    {
        private readonly ICustomerAccountDal _customerAccountDal;

        public CustomerAccountManager(ICustomerAccountDal customerAccountDal)
        {
            _customerAccountDal = customerAccountDal;
        }

        public void TDelete(CustomerAccount t)
        {
            _customerAccountDal.Delete(t);
        }

        public List<CustomerAccount> TGetAll()
        {
            return _customerAccountDal.GetAll();
        }

        public CustomerAccount TGetById(int id)
        {
            return _customerAccountDal.GetById(id);
        }

        public void TInsert(CustomerAccount t)
        {
            _customerAccountDal.Insert(t);
        }

        public void TUpdate(CustomerAccount t)
        {
            _customerAccountDal.Update(t);
        }
    }
}
