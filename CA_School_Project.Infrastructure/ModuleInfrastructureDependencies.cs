using CA_School_Project.Domain.Entities.Identity;
using CA_School_Project.Infrastructure.Context;
using CA_School_Project.Infrastructure.Repositories;
using CA_School_Project.Infrastructure.Repositories.Abstractionss;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace CA_School_Project.Infrastructure;

public static class ModuleInfrastructureDependencies
{
   public static IServiceCollection AddInfrastructureDependencies(this IServiceCollection services, IConfiguration configuration)
   {
      services.AddTransient<IStudentRepository, StudentRepository>();
      services.AddTransient<IDepartmentRepository, DepartmentRepository>();
      services.AddTransient<ISubjectRepository, SubjectRepository>();
      services.AddTransient<IInstructorRepository, InstructorRepository>();

      services.AddTransient(typeof(IGenericRepositoryAsync<>), typeof(GenericRepositoryAsync<>));

      services.AddDbContext<ApplicationDbContext>(options =>
      {
         options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
      });

      return services;
   }
}
