using System;
using HomeAssignmentLibrary.API.Entities;
using Microsoft.EntityFrameworkCore;

namespace HomeAssignmentLibrary.API.DbContexts
{
    public class HomeAssignmentLibraryContext : DbContext
    {
        public HomeAssignmentLibraryContext(DbContextOptions<HomeAssignmentLibraryContext> options)
            : base(options)
        {
        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Agreement> Agreements { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // seed the database with data
            modelBuilder.Entity<Customer>().HasData(
                new Customer()
                {
                    Id = Guid.Parse("d28888e9-2ba9-473a-a40f-e38cb54f9b35"),
                    PersonalId = "67812203006",
                    FirstName = "Goras",
                    LastName = "Trusevičius"
                },
                new Customer()
                {
                    Id = Guid.Parse("da2fd609-d754-4feb-8acd-c4f9ff13ba96"),
                    PersonalId = "78706151287",
                    FirstName = "Dange",
                    LastName = "Kulkavičiutė"
                }
                );

            modelBuilder.Entity<Agreement>().HasData(
               new Agreement
               {
                   Id = Guid.Parse("5b1c2b4d-48c7-402a-80c3-cc796ad49c6b"),
                   CustomerId = Guid.Parse("d28888e9-2ba9-473a-a40f-e38cb54f9b35"),
                   Amount = 12000,
                   BaseRateCode = "VILIBOR3m",
                   Margin = 1.6m,
                   AgreementDuration = 60,
               },
               new Agreement
               {
                   Id = Guid.Parse("d8663e5e-7494-4f81-8739-6e0de1bea7ee"),
                   CustomerId = Guid.Parse("da2fd609-d754-4feb-8acd-c4f9ff13ba96"),
                   Amount = 8000,
                   BaseRateCode = "VILIBOR1y",
                   Margin = 2.2m,
                   AgreementDuration = 36,
               },
               new Agreement
               {
                   Id = Guid.Parse("d173e20d-159e-4127-9ce9-b0ac2564ad97"),
                   CustomerId = Guid.Parse("da2fd609-d754-4feb-8acd-c4f9ff13ba96"),
                   Amount = 1000,
                   BaseRateCode = "VILIBOR6m",
                   Margin = 1.85m,
                   AgreementDuration = 24,
               }
               );

            base.OnModelCreating(modelBuilder);
        }
    }
}
