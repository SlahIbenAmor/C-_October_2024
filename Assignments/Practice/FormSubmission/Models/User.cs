#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
namespace FormSubmission.Models;

public class User
{
    [Required]
    [MinLength(2, ErrorMessage = "Name must be at least 2 characters long")]
    public string Name {get;set;}
    [Required]
    [EmailAddress]
    [Display(Name = "Email Address")]
    public string Email {get;set;}
    [Required]
    [DataType(DataType.Date)]
    [PastDate]
    public DateTime DoB {get;set;}
    [Required]
    [MinLength(8, ErrorMessage = "Password must be at least 8 characters")]
    public string Password {get;set;}
    [Required]
    [Display(Name = "Favorite Odd Number")]
    [OddNumber]
    public int FavOddNumber {get;set;}
}

public class PastDateAttribute : ValidationAttribute
{ 
    protected override ValidationResult IsValid(object value, ValidationContext validationContext)    
    {
        if (((DateTime)value) > DateTime.Now)
        {  
            return new ValidationResult("Date must be in the past!");   
        } else {   
            return ValidationResult.Success;  
        }  
    }
}

public class OddNumberAttribute : ValidationAttribute
{
    protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
    {
        if((int)value % 2 == 0)
        {
            return new ValidationResult("Number must be odd!");
        } else {
            return ValidationResult.Success;
        }
    }
}

