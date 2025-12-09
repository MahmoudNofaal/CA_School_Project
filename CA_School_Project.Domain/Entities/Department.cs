using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CA_School_Project.Domain.Entities;

public partial class Department
{
   public Department()
   {
      Students = new HashSet<Student>();
      DepartmentSubjects = new HashSet<DepartmentSubject>();
   }

   [Key]
   public int DID { get; set; }

   [StringLength(500)]
   public string DName_Ar { get; set; }
   [StringLength(500)]
   public string DName_En { get; set; }

   public virtual ICollection<Student> Students { get; set; }
   public virtual ICollection<DepartmentSubject> DepartmentSubjects { get; set; }

}
