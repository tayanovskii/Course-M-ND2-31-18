using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace Validation_CardHolder.Validations
{
    public class ExpirationDateAttribute: ValidationAttribute, IClientModelValidator
    {
        private readonly string expirationMonthProperty;

        public ExpirationDateAttribute(string expirationMonthProperty)
        {
            this.expirationMonthProperty = expirationMonthProperty;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var expirationMonth = (int)validationContext.ObjectType.GetProperty(expirationMonthProperty).GetValue(validationContext.ObjectInstance);
            var expirationYear = value is int i ? i : 0;
            if (expirationYear.Equals(DateTime.Now.Year))
                {
                    if(expirationMonth <= DateTime.Now.Month)
                        return new ValidationResult("The expiration month must be greater then current month");
                }    
            if(expirationYear < DateTime.Now.Year)  
                return new ValidationResult("Expiration year must be greater or equal current year");
            return ValidationResult.Success;
        }

        public void AddValidation(ClientModelValidationContext context)
        {
            context.Attributes.Add("data-val", "true");
            context.Attributes.Add("data-val-expirationdate", $"{context.ModelMetadata.GetDisplayName()} or {expirationMonthProperty} is invalid");
            context.Attributes.Add("data-val-expirationdate-value", expirationMonthProperty);
        }
    }
}
