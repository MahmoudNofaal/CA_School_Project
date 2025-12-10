using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CA_School_Project.Domain.Entities;

public class InstructorSubject
{
   [Key]
   public int InstructorId { get; set; }

   [Key]
   public int SubjectId { get; set; }

   [ForeignKey(nameof(InstructorId))]
   [InverseProperty(nameof(Entities.Instructor.Ins_Subjects))]
   public Instructor? Instructor { get; set; }

   [ForeignKey(nameof(SubjectId))]
   [InverseProperty(nameof(Entities.Subject.InstrcutorSubjects))]
   public Subject? Subject { get; set; }

}
