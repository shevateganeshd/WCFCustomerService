using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WCFCustomerService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "CustomerService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select CustomerService.svc or CustomerService.svc.cs at the Solution Explorer and start debugging.
    public class CustomerService : ICustomerService
    {
        public void AddCustomer(CustomerContract customerContract)
        {
            CRMEntities1 crmEntities = new CRMEntities1();
            crmEntities.Customers.Add(new Customer
            {
                //Id = cRMEntities.Customers.Last().Id + 1,
                Id = crmEntities.Customers.Count() + 1,
                FirstName = customerContract.FirstName,
                MiddleName = customerContract.MiddleName,
                LastName = customerContract.LastName,
                Address = customerContract.Address,
                Email = customerContract.Email,
                Phone = customerContract.Phone
            });
            crmEntities.SaveChanges();
        }

        public List<CustomerContract> GetCustomers()
        {
            CRMEntities1 crmEntities = new CRMEntities1();
            return crmEntities.Customers.Select(c => new CustomerContract { Id = c.Id, FirstName = c.FirstName, MiddleName = c.MiddleName, LastName = c.LastName, Address = c.Address, Email = c.Email, Phone = c.Phone }).ToList();
        }

        public CustomerContract GetCustomer(int Id)
        {
            CRMEntities1 crmEntities = new CRMEntities1();
            var customer = crmEntities.Customers.FirstOrDefault(c => c.Id == Id);
            if (customer != null)
            {
                return new CustomerContract
                {
                    Id = customer.Id,
                    FirstName = customer.FirstName,
                    MiddleName = customer.MiddleName,
                    LastName = customer.LastName,
                    Address = customer.Address,
                    Email = customer.Email,
                    Phone = customer.Phone
                };
            }
            return null;
        }

        public void UpdateCustomer(CustomerContract customerContract)
        {
            CRMEntities1 crmEntities = new CRMEntities1();
            var customer = crmEntities.Customers.FirstOrDefault(c => c.Id == customerContract.Id);
            if (customer != null)
            {
                customer.FirstName = customerContract.FirstName;
                customer.MiddleName = customerContract.MiddleName;
                customer.LastName = customerContract.LastName;
                customer.Address = customerContract.Address;
                customer.Email = customerContract.Email;
                customer.Phone = customerContract.Phone;
                crmEntities.SaveChanges();
            }
        }

        public void DeleteCustomer(int Id)
        {
            CRMEntities1 crmEntities = new CRMEntities1();
            var customer = crmEntities.Customers.FirstOrDefault(c => c.Id == Id);
            if(customer!=null)
            {
                crmEntities.Customers.Remove(customer);
                crmEntities.SaveChanges();
            }
        }
    }
}
