using CA_School_Project.API.Middlewares;
using CA_School_Project.Application;
using CA_School_Project.Domain;
using CA_School_Project.Domain.Entities.Identity;
using CA_School_Project.Infrastructure;
using CA_School_Project.Infrastructure.Context;
using Microsoft.AspNetCore.Identity;
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

      #region Identity

      builder.Services.AddIdentity<ApplicationUser, IdentityRole<int>>(options =>
      {
         // Password settings.
         options.Password.RequireDigit = true;
         options.Password.RequireLowercase = true;
         options.Password.RequireNonAlphanumeric = true;
         options.Password.RequireUppercase = true;
         options.Password.RequiredLength = 6;
         options.Password.RequiredUniqueChars = 1;

         // Lockout settings.
         options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
         options.Lockout.MaxFailedAccessAttempts = 5;
         options.Lockout.AllowedForNewUsers = true;

         // User settings.
         options.User.AllowedUserNameCharacters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+";
         options.User.RequireUniqueEmail = true;
         //options.SignIn.RequireConfirmedEmail = true;

      })
      .AddEntityFrameworkStores<ApplicationDbContext>()
      .AddDefaultTokenProviders();

      #endregion

      #region Dependencies (Dependency Injection)

      builder.Services.AddInfrastructureDependencies(builder.Configuration)
                      .AddApplicationDependencies()
                      .AddDomainDependencies();

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


      #region CORS Configuration

      var school_mobile = "School_Mobile";
      builder.Services.AddCors(options =>
      {
         options.AddPolicy(name: school_mobile,
                           policy =>
                           {
                              policy.AllowAnyOrigin()
                                    .AllowAnyHeader()
                                    .AllowAnyMethod();
                           });
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

      app.UseCors(school_mobile);


      app.UseAuthentication();
      app.UseAuthorization();


      app.MapControllers();

      app.Run();
   }
}
