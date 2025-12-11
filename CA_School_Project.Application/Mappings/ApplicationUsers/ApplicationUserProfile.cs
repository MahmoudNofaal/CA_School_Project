using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace CA_School_Project.Application.Mappings.ApplicationUsers;

public partial class ApplicationUserProfile : Profile
{

	public ApplicationUserProfile()
	{

		this.AddStudentCommandMapping();
		this.GetUserPaginatedListMapping();
		this.GetSingleUserQueryMapping();

   }

}
