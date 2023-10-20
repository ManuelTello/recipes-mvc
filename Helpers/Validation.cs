using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Text.RegularExpressions;
using recipes.Lib;

namespace recipes.Helpers
{
    public class ListValidation : ValidationAttribute
    {
        private string Destiny { get; }

        public ListValidation(string destiny)
        {
            this.Destiny = destiny;
        }

        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (value == null)
            {
                return new ValidationResult($"Recipe must have at least one {this.Destiny}.");
            }
            else
            {
                List<string?> list = (value as IEnumerable<object>)!.Cast<string?>().ToList();
                Common<string> common = new Common<string>();

                // If it founds any element of the list is null
                // then rejects the validation
                bool has_null = common.CheckListForNull(list);

                if (has_null)
                {
                    return new ValidationResult($"All fields of {this.Destiny}s must be completed.");
                }
                else
                {
                    bool regexisvalid = common.CheckIfInputIsValid(list!);

                    if (regexisvalid)
                    {
                        return ValidationResult.Success;
                    }
                    else
                    {
                        return new ValidationResult($"All fields of {this.Destiny}s must be completed.");
                    }
                }
            }
        }

    }

    public class GreaterThan : ValidationAttribute
    {
        private int MinimumNumber { get; }

        public GreaterThan(int number)
        {
            this.MinimumNumber = number;
        }

        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if ((int)value! > this.MinimumNumber)
            {
                return ValidationResult.Success;
            }
            else
            {
                return new ValidationResult($"Value must me greater than {this.MinimumNumber}.");
            }
        }
    }
}