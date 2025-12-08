using CA_School_Project.Application;
using CA_School_Project.Infrastructure;
using CA_School_Project.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.SwaggerGen;
using Swashbuckle.AspNetCore.SwaggerUI;

namespace CA_School_Project.API;

public class Program
{
   public static void Main(string[] args)
   {
      var builder = WebApplication.CreateBuilder(args);

      // Add services to the container.

      builder.Services.AddControllers();
      // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
      builder.Services.AddOpenApi();

      #region Swagger Configuration

      builder.Services.AddSwaggerGen();

      #endregion

      builder.Services.AddDbContext<ApplicationDbContext>(options =>
      {
         options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
      });

      #region Dependencies (Dependency Injection)

      builder.Services.AddInfrastructureDependencies()
                      .AddApplicationDependencies();

      #endregion

      var app = builder.Build();

      // Configure the HTTP request pipeline.
      if (app.Environment.IsDevelopment())
      {
         //app.MapOpenApi();
         app.UseSwagger();
         app.UseSwaggerUI();
      }

      app.UseHttpsRedirection();

      app.UseAuthorization();


      app.MapControllers();

      app.Run();
   }
}
