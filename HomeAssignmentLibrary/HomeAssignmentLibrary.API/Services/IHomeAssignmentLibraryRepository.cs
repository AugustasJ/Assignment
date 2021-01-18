using System;
using System.Collections.Generic;
using HomeAssignmentLibrary.API.Entities;

namespace HomeAssignmentLibrary.API.Services
{
    public interface IHomeAssignmentLibraryRepository
    {
        IEnumerable<Agreement> GetAgreements(Guid customerId);
        Agreement GetAgreement(Guid customerId, Guid agreementId);
        void AddAgreement(Guid customerId, Agreement agreement);
        void UpdateAgreement(Agreement agreement);
        void DeleteAgreement(Agreement agreement);

        IEnumerable<Customer> GetCustomers();
        Customer GetCustomer(Guid customerId);
        IEnumerable<Customer> GetCustomers(IEnumerable<Guid> customerIds);
        void AddCustomer(Customer customer);
        void DeleteCustomer(Customer customer);
        void UpdateCustomer(Customer customer);
        bool CustomerExists(Guid customerId);
        bool Save();
    }
}
