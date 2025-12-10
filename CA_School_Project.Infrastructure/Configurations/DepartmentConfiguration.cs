using CA_School_Project.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Net;
using System.Reflection.Emit;
using System.Text;

namespace CA_School_Project.Infrastructure.Configurations;

public class DepartmentConfiguration : IEntityTypeConfiguration<Department>
{
   public void Configure(EntityTypeBuilder<Department> builder)
   {

      // Department-Manager relationship (prevent cascade delete)
      builder.HasOne(d => d.Manager)
             .WithOne(i => i.DepartmentManager)
             .HasForeignKey<Department>(d => d.ManagerId)
             .OnDelete(DeleteBehavior.Restrict);

   }
}
