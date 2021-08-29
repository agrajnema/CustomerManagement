using CustomerManagement.Domain.Common;
using CustomerManagement.Domain.Customer;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CustomerManagement.Persistence
{
    public class CustomerManagementDbContext : DbContext
    {
        private Guid LoggedInUserId = Guid.Parse("{e6b3d969-3210-4f15-b481-44ba3548f1c0}");  //ideally this should be the logged in user ID making changes
        public CustomerManagementDbContext(DbContextOptions<CustomerManagementDbContext> options)
            : base(options)
        {

        }
        public DbSet<Customer> Customer { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //add seed data with the initial migration
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(CustomerManagementDbContext).Assembly);
            modelBuilder.Entity<Customer>().HasData(new Customer
            {
                CustomerId = Guid.Parse("{d96a0111-06f3-464c-bf1e-638a5801b749}"),
                FirstName = "Agraj",
                LastName = "Nema",
                DateOfBirth = Convert.ToDateTime("06/11/1986")
            });

            modelBuilder.Entity<Customer>().HasData(new Customer
            {
                CustomerId = Guid.Parse("{de01cefb-6e0a-4cd0-80a7-3da849214c88}"),
                FirstName = "Another",
                LastName = "User",
                DateOfBirth = Convert.ToDateTime("01/01/1990")
            });
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            foreach (var entry in ChangeTracker.Entries<Base>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.CreatedDate = DateTime.Now;
                        entry.Entity.CreatedBy = LoggedInUserId;
                        break;
                    case EntityState.Modified:
                        entry.Entity.ModifiedDate = DateTime.Now;
                        entry.Entity.ModifiedBy = LoggedInUserId;
                        break;
                }
            }
            return base.SaveChangesAsync(cancellationToken);
        }
    }
}
