using HomeAssignmentLibrary.API.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using HomeAssignmentLibrary.API.DbContexts;
using Microsoft.EntityFrameworkCore;


namespace HomeAssignmentLibrary.API.Services
{
    public class HomeAssignmentLibraryRepository : IHomeAssignmentLibraryRepository, IDisposable
    {
        private readonly HomeAssignmentLibraryContext _context;
        
        public HomeAssignmentLibraryRepository(HomeAssignmentLibraryContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }


        public void AddCustomer(Customer customer)
        {
            throw new NotImplementedException();
        }

        public bool CustomerExists(Guid customerId)
        {
            if (customerId == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(customerId));
            }

            return _context.Customers.Any(a => a.Id == customerId);
        }

        public Customer GetCustomer(Guid customerId)
        {
            if (customerId == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(customerId));
            }

            return _context.Customers.FirstOrDefault(a => a.Id == customerId);
        }

        public IEnumerable<Customer> GetCustomers()
        {
            return _context.Customers.ToList<Customer>();
        }

        public IEnumerable<Customer> GetCustomers(IEnumerable<Guid> customerIds)
        {
            throw new NotImplementedException();
        }

        public void UpdateCustomer(Customer customer)
        {
            throw new NotImplementedException();
        }

        public void DeleteCustomer(Customer customer)
        {
            throw new NotImplementedException();
        }


        public void AddAgreement(Guid customerId, Agreement agreement)
        {
            throw new NotImplementedException();
        }

        public Agreement GetAgreement(Guid customerId, Guid agreementId)
        {
            if (customerId == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(customerId));
            }

            if (agreementId == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(agreementId));
            }

            return _context.Agreements.FirstOrDefault(c => c.CustomerId == customerId && c.Id == agreementId);
        }

        public IEnumerable<Agreement> GetAgreements(Guid customerId)
        {
            if (customerId == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(customerId));
            }

            return _context.Agreements
                .Include(c => c.Customer)
                .Where(c => c.CustomerId == customerId)
                .OrderBy(c => c.Amount).ToList();
        }

        public void UpdateAgreement(Agreement agreement)
        {
            throw new NotImplementedException();
        }

        public void DeleteAgreement(Agreement agreement)
        {
            throw new NotImplementedException();
        }

        
        public bool Save()
        {
            throw new NotImplementedException();
        }
        
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                // dispose resources when needed
            }
        }
    }
}
