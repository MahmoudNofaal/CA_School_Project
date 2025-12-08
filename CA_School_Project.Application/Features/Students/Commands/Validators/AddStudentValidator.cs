using CA_School_Project.Application.Features.Students.Commands.Models;
using CA_School_Project.Application.Services.Abstractions;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace CA_School_Project.Application.Features.Students.Commands.Validators;

public class AddStudentValidator : AbstractValidator<AddStudentCommand>
{
   private readonly IStudentService _studentService;

   public AddStudentValidator(IStudentService studentService)
	{
      this._studentService = studentService;

		this.ApplyValidationRules();
		this.ApplyCustomValidations();
   }

	public void ApplyValidationRules()
	{
		RuleFor(x => x.Name)
			.NotEmpty().WithMessage("Student name is required.")
			.NotNull().WithMessage("Student name cannot be null.")
         .MaximumLength(100).WithMessage("Student name must not exceed 100 characters.");

      RuleFor(x => x.Address)
         .NotEmpty().WithMessage("Address is required.")
         .NotNull().WithMessage("{PropertyName} cannot be null.")
         .MaximumLength(100).WithMessage("{PropertyName} must not exceed 100 characters.");

   }

	public void ApplyCustomValidations()
	{
		RuleFor(x => x.Name)
			.MustAsync(async (key, CancellationToken) =>
				!await _studentService.IsNameExistsAsync(key)
         ).WithMessage("Name must be unique.");

      // Add any custom validation logic here if needed in the future
   }

}
