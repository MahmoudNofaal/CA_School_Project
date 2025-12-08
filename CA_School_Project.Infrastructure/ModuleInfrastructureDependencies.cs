using CA_School_Project.Infrastructure.Abstractionss;
using CA_School_Project.Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace CA_School_Project.Infrastructure;

public static class ModuleInfrastructureDependencies
{

   public static IServiceCollection AddInfrastructureDependencies(this IServiceCollection services)
   {

      services.AddTransient<IStudentRepository, StudentRepository>();


      return services;
   }


}
