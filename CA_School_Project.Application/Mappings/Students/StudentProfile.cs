using AutoMapper;
using CA_School_Project.Application.Features.Students.Queries.Responses;
using CA_School_Project.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CA_School_Project.Application.Mappings.Students;

public partial class StudentProfile : Profile
{

	public StudentProfile()
	{

		this.GetStudentListMapping();
		this.GetSingleStudentMapping();
		this.AddStudentCommandMapping();
		this.EditStudentCommandMapping();

   }

}

