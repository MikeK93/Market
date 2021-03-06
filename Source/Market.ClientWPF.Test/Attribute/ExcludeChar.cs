﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Market.ClientWPF.Test.Attribute
{
    internal class ExcludeChar : ValidationAttribute
    {
        private string _characters;

        public ExcludeChar(string characters)
        {
            _characters = characters;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value != null)
            {
                for (int i = 0; i < _characters.Length; i++)
                {
                    var valueAsString = value.ToString();
                    if (valueAsString.Contains(_characters[i]))
                    {
                        var errorMessage = FormatErrorMessage(validationContext.DisplayName);
                        return new ValidationResult(errorMessage);
                    }
                }
            }

            return ValidationResult.Success;
        }

    }
}