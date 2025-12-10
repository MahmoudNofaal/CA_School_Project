using CA_School_Project.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CA_School_Project.Infrastructure.Configurations;

public class StudentConfiguration : IEntityTypeConfiguration<Student>
{
   public void Configure(EntityTypeBuilder<Student> builder)
   {

      // Student-Department relationship
      builder.HasOne(s => s.Department)
             .WithMany(d => d.Students)
             .HasForeignKey(s => s.DepartmentId)
             .OnDelete(DeleteBehavior.Restrict);

   }
}
