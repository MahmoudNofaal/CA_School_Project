
using CA_School_Project.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace CA_School_Project.Infrastructure.Context;

public class ApplicationDbContext : DbContext
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

}
