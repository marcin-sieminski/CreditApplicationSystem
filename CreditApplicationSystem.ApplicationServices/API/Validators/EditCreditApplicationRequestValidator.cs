using System;
using CreditApplicationSystem.ApplicationServices.API.Domain.CreditApplication;
using FluentValidation;

namespace CreditApplicationSystem.ApplicationServices.API.Validators;

public class EditCreditApplicationRequestValidator : AbstractValidator<EditCreditApplicationRequest>
{
    public EditCreditApplicationRequestValidator()
    {
        RuleFor(x => x.AmountRequested).GreaterThan(0);
        RuleFor(x => x.DateOfSubmission).GreaterThanOrEqualTo(new DateTime(2022, 1, 1));
        RuleFor(x => x.DateOfLastStatusChange).GreaterThanOrEqualTo(new DateTime(2022, 1, 1));
    }
}