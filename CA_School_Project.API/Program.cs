using CA_School_Project.API.Middlewares;
using CA_School_Project.Application;
using CA_School_Project.Infrastructure;
using CA_School_Project.Infrastructure.Context;
using Microsoft.AspNetCore.Localization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Swashbuckle.AspNetCore.SwaggerGen;
using Swashbuckle.AspNetCore.SwaggerUI;
using System.Globalization;

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

      #region Localization Configuration

      builder.Services.AddLocalization(options =>
      {
         options.ResourcesPath = "";
      });

      builder.Services.Configure<RequestLocalizationOptions>(options =>
      {
         var supportedCultures = new List<CultureInfo>
         {
            new CultureInfo("en-US"),
            new CultureInfo("ar-EG"),
         };

         options.DefaultRequestCulture = new RequestCulture("en-US");
         options.SupportedCultures = supportedCultures;
         options.SupportedUICultures = supportedCultures;
      });

      #endregion

      var app = builder.Build();

      // Configure the HTTP request pipeline.
      if (app.Environment.IsDevelopment())
      {
         //app.MapOpenApi();
         app.UseSwagger();
         app.UseSwaggerUI();
      }

      #region Localization Middleware
      var localizationOptions = app.Services.GetService<IOptions<RequestLocalizationOptions>>();
      app.UseRequestLocalization(localizationOptions!.Value);
      #endregion

      app.UseMiddleware<ErrorHandlerMiddleware>();

      app.UseHttpsRedirection();

      app.UseAuthorization();


      app.MapControllers();

      app.Run();
   }
}
