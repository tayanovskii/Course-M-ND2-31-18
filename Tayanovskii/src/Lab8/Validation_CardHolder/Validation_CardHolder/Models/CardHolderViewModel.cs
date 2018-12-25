using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Validation_CardHolder.Validations;

namespace Validation_CardHolder.Models
{
    public class CardHolderViewModel
    {
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string PostCode { get; set; }
        public string Email { get; set; }
        public decimal Amount { get; set; }
        public string Description { get; set; }
        [CreditCardNumber]
        public string CreditCardNumber { get; set; }
        public int ExpirationMonth { get; set; }
        [ExpirationDate(nameof(ExpirationMonth))]
        public int ExpirationYear { get; set; }
        public string SecurityCode { get; set; }
    }
}
