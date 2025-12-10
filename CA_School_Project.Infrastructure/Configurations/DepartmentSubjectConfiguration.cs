using CA_School_Project.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CA_School_Project.Infrastructure.Configurations;

public class DepartmentSubjectConfiguration : IEntityTypeConfiguration<DepartmentSubject>
{
   public void Configure(EntityTypeBuilder<DepartmentSubject> builder)
   {

      // configure Composite Keys
      builder.HasKey(ds => new { ds.DepartmentId, ds.SubjectId });

   }
}
