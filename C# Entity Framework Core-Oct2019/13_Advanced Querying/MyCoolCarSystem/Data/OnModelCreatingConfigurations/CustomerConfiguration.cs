using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyCoolCarSystem.Data.Models;

namespace MyCoolCarSystem.Data.OnModelCreatingConfigurations
{
    public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> customer)
        {
            customer.HasOne(c => c.Address)
                             .WithOne(a => a.Customer)
                             .HasForeignKey<Address>(a => a.CustomerId)
                             .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
