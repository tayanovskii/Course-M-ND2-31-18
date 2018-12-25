using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace Validation_CardHolder.Validations
{
    public class CreditCardNumberAttribute : ValidationAttribute, IClientModelValidator
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var inputValue = value as string;

            if (inputValue == null)
            {
                return new ValidationResult("Number of credit card must not be empty");
            }
            inputValue = inputValue.Replace("-", "").Replace(" ", "");
            int checksum = 0;
            bool evenDigit = false;
            foreach (char digit in inputValue.ToCharArray().Reverse())
            {
                if (!char.IsDigit(digit))
                {
                    return new ValidationResult("Number of credit card must include only digits");
                }
                int digitValue = (digit - '0') * (evenDigit ? 2 : 1);
                evenDigit = !evenDigit;
                while (digitValue > 0)
                {
                    checksum += digitValue % 10;
                    digitValue /= 10;
                }
            }
            return checksum % 10 == 0 ? ValidationResult.Success : new ValidationResult("Incorrect card number");
            
        }

        public void AddValidation(ClientModelValidationContext context)
        {
            context.Attributes.Add("data-val", "true");
            context.Attributes.Add("data-val-creditcardnumber",
                "Incorrect card number. " +
                "Examples of credit card number: " +
                "Visa: 4111 1111 1111 1111 " + 
                "MasterCard: 5500 0000 0000 0004 " +
                "American Express: 3400 0000 0000 009 ");
        }
    }
}
