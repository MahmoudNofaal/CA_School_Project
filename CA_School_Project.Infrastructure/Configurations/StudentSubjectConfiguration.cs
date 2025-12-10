using CA_School_Project.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CA_School_Project.Infrastructure.Configurations;

public class StudentSubjectConfiguration : IEntityTypeConfiguration<StudentSubject>
{
   public void Configure(EntityTypeBuilder<StudentSubject> builder)
   {

      // configure Composite Keys
      builder.HasKey(ss => new { ss.StudentId, ss.SubjectId });

   }
}
