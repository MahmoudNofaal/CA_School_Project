
using CA_School_Project.Domain.Entities;
using CA_School_Project.Domain.Entities.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace CA_School_Project.Infrastructure.Context;

public class ApplicationDbContext : IdentityDbContext<ApplicationUser,IdentityRole<int>, int, IdentityUserClaim<int>, IdentityUserRole<int>, IdentityUserLogin<int>, IdentityRoleClaim<int>, IdentityUserToken<int>>
{

	public ApplicationDbContext()
	{
	}

	public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
   {

	}

	public DbSet<Department> Departments { get; set; }
	public DbSet<DepartmentSubject> DepartmentSubjects { get; set; }
	public DbSet<Student> Students { get; set; }
	public DbSet<StudentSubject> StudentSubjects { get; set; }
	public DbSet<Subject> Subjects { get; set; }

	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		base.OnModelCreating(modelBuilder);

		modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

   }

}
