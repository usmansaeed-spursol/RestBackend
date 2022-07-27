using PersonalCompany.PersonalProduct.DAL;
using PersonalCompany.PersonalProduct.Models;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PersonalCompany.PersonalProduct.BL
{
    public class CustomerTypeService 
    {
        public List<CustomerType> GetAll()
        {
            CustomerTypeRepository CustomerTypeRepo = new CustomerTypeRepository();
            return CustomerTypeRepo.GetList().Result.ToList();
        }

        public CustomerType GetById(int id)
        {
            CustomerTypeRepository customerTypeRepo = new CustomerTypeRepository();
            return customerTypeRepo.Get<CustomerType>(id).Result;
        }

        public int Add(CustomerType customerType)
        { 
            CustomerTypeRepository customerTypeRepo = new CustomerTypeRepository();
            customerType.CreatedBy = "Api user";
            customerType.CreatedOn = DateTime.UtcNow;
            customerType.Active = true;
            Task<int> n = customerTypeRepo.Insert(customerType);
            return n.Result;
        }
        public int Update(CustomerType customerType)
        {
            CustomerTypeRepository customerTypeRepo = new CustomerTypeRepository();
            customerType.LastModifiedBy = "Api user";
            customerType.LastModifiedOn = DateTime.UtcNow;
            Task<int> n = customerTypeRepo.Update(customerType);
            return n.Result;
        }

        public int Delete(int id)
        {
            CustomerTypeRepository customerTypeRepository = new CustomerTypeRepository();
            Task<int> n = customerTypeRepository.Delete(id);
            return n.Result;
        }
    }
}
