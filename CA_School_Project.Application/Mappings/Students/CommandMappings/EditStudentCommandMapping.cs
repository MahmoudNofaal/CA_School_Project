using CA_School_Project.Application.Features.Students.Commands.Models;
using CA_School_Project.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CA_School_Project.Application.Mappings.Students;

public partial class StudentProfile
{

   public void EditStudentCommandMapping()
   {
      CreateMap<EditStudentCommand, Student>()
         .ForMember(dest => dest.StudID, opt => opt.MapFrom(src => src.Id))
         .ForMember(dest => dest.DID, opt => opt.MapFrom(src => src.DepartmentId));

   }

}
