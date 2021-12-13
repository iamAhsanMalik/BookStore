using System.ComponentModel.DataAnnotations;

namespace BookStore.Helper
{
    public class NumberValidatorAttribute : ValidationAttribute
    {
        private readonly int _num;

        public NumberValidatorAttribute(int num)
        {
            _num = num;
        }
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (value != null)
            {
                int result = Convert.ToInt32(value);

                if (_num <= result)
                {
                    return ValidationResult.Success;
                }
            }
            return new ValidationResult(ErrorMessage ?? "Invalid Input");
        }
    }
}
