using CA_School_Project.Application.Features.Students.Queries.Responses;
using CA_School_Project.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CA_School_Project.Application.Mappings.Students;

public partial class StudentProfile
{

   public void GetSingleStudentMapping()
   {

      CreateMap<Student, GetSingleStudentReponse>()
         .ForMember(dest => dest.DepartmentName, opt => opt.MapFrom(src => src.Department.DName));

   }

}