using FluentValidation.Results;
using System;
using System.Collections.Generic;

namespace TicketManagementSystemAPI.Application.Exceptions
{
    public class ValidationException : ApplicationException
    {
        public List<string> ValdationErrors { get; set; }

        public ValidationException(ValidationResult validationResult)
        {
            ValdationErrors = new List<string>();

            foreach (ValidationFailure validationError in validationResult.Errors)
            {
                ValdationErrors.Add(validationError.ErrorMessage);
            }
        }
    }
}
