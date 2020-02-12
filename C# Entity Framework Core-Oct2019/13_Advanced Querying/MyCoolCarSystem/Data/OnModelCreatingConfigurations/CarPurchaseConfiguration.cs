﻿using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyCoolCarSystem.Data.Models;

namespace MyCoolCarSystem.Data.OnModelCreatingConfigurations
{
    public class CarPurchaseConfiguration : IEntityTypeConfiguration<CarPurchase>
    {
        public void Configure(EntityTypeBuilder<CarPurchase> carPurchase)
        {
            carPurchase.HasKey(p => new
                {
                    p.CustomerId,
                    p.CarId
                });

            carPurchase.HasOne(p => p.Customer)
                             .WithMany(c => c.Purchases)
                             .HasForeignKey(p => p.CustomerId)
                             .OnDelete(DeleteBehavior.Restrict);

            carPurchase.HasOne(p => p.Car)
                             .WithMany(c => c.Owners)
                             .HasForeignKey(p => p.CarId)
                             .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
