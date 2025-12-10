using CA_School_Project.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CA_School_Project.Infrastructure.Configurations;

public class InstructorConfiguration : IEntityTypeConfiguration<Instructor>
{
   public void Configure(EntityTypeBuilder<Instructor> builder)
   {

      // Instructor-Supervisor relationship (prevent cascade delete)
      builder.HasOne(i => i.Supervisor)
             .WithMany(i => i.Instructors)
             .HasForeignKey(i => i.SupervisorId)
             .OnDelete(DeleteBehavior.Restrict);


      // Instructor-Department relationship
      builder.HasOne(i => i.Department)
             .WithMany(d => d.Instructors)
             .HasForeignKey(i => i.DepartmentId)
             .OnDelete(DeleteBehavior.Restrict);


   }
}
