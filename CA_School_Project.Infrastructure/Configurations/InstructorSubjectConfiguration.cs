using CA_School_Project.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CA_School_Project.Infrastructure.Configurations;

public class InstructorSubjectConfiguration : IEntityTypeConfiguration<InstructorSubject>
{
   public void Configure(EntityTypeBuilder<InstructorSubject> builder)
   {

      // configure Composite Keys
      builder.HasKey(ins => new { ins.InstructorId, ins.SubjectId });

   }
}
