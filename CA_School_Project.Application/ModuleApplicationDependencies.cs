using CA_School_Project.Application.Services;
using CA_School_Project.Application.Services.Abstractions;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace CA_School_Project.Application;

public static class ModuleApplicationDependencies
{

   public static IServiceCollection AddApplicationDependencies(this IServiceCollection services)
   {
      services.AddTransient<IStudentService, StudentService>();

      // MediatR Registration
      // this will scan and register all the handlers in the assembly
      services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()));

      // AutoMapper Registration
      services.AddAutoMapper(Assembly.GetExecutingAssembly());

      return services;
   }

}
