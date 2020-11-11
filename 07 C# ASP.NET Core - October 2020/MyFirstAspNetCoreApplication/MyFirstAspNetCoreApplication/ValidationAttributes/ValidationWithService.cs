using System.ComponentModel.DataAnnotations;

namespace MyFirstAspNetCoreApplication.ValidationAttributes
{
    public class ValidationWithService : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            //validationContext.GetService<ServiceName>();
            //Можем да ползваме сървиз който имаме и да го ползваме за валидация. Базата данни също можем за ползваме.

            return new ValidationResult("");
        }
    }
}
