#pragma warning disable CS8618
namespace DateValidator.Models;
using System.ComponentModel.DataAnnotations;

public class User
{
    [Required]
    public string Name {get;set;}
    [Required]
    [DataType(DataType.Date)]
    [FutureDate]
    public DateTime Birthday {get;set;}
}

public class FutureDateAttribute : ValidationAttribute
{
    protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
    {
        if((DateTime)value > DateTime.Now)
        {
            return new ValidationResult("Birthday must be in the past!");
        } else {
            return ValidationResult.Success;
        }
    }
}