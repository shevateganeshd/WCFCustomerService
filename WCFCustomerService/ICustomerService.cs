using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WCFCustomerService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "ICustomerService" in both code and config file together.
    [ServiceContract]
    public interface ICustomerService
    {
        [OperationContract]
        void AddCustomer(CustomerContract customerContract);

        [OperationContract]
        List<CustomerContract> GetCustomers();

        [OperationContract]
        CustomerContract GetCustomer(int Id);

        [OperationContract]
        void UpdateCustomer(CustomerContract customerContract);
        [OperationContract]
        void DeleteCustomer(int Id);
    }

    [DataContract]
    public class CustomerContract
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string FirstName { get; set; }
        [DataMember]
        public string MiddleName { get; set; }
        [DataMember]
        public string LastName { get; set; }
        [DataMember]
        public string Address { get; set; }
        [DataMember]
        public string Email { get; set; }
        [DataMember]
        public string Phone { get; set; }
    }
}
