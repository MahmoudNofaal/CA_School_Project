using CA_School_Project.Application.Features.Students.Commands.Models;
using CA_School_Project.Application.Resources;
using CA_School_Project.Application.Services.Abstractions;
using FluentValidation;
using Microsoft.Extensions.Localization;
using System;
using System.Collections.Generic;
using System.Text;

namespace CA_School_Project.Application.Features.Students.Commands.Validators;

public class AddStudentValidator : AbstractValidator<AddStudentCommand>
{
   private readonly IStudentService _studentService;
   private readonly IStringLocalizer<SharedResources> _stringLocalizer;

   public AddStudentValidator(IStudentService studentService, IStringLocalizer<SharedResources> stringLocalizer)
	{
      this._studentService = studentService;
      this._stringLocalizer = stringLocalizer;

      this.ApplyValidationRules();
		this.ApplyCustomValidations();
   }

	public void ApplyValidationRules()
	{
		RuleFor(x => x.Name)
			.NotEmpty().WithMessage(_stringLocalizer[SharedResourcesKeys.NotEmpty])
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
