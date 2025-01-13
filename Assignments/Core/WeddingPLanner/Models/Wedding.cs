#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace WeddingPLanner.Models;

public class Wedding
{
    [Key]
    public int WeddingId { get; set; }

    [Required(ErrorMessage = "WedderOneFirstName is required")]
    public string WedderOneFirstName { get; set; }
    

    [Required(ErrorMessage = "WedderTwoFirstName is required")]
    public string WedderTwoFirstName { get; set; }


    [Required]
    [FutureDate] 
    public DateTime Date { get; set; }

    [Required(ErrorMessage = "Wedding Address is required")]
    public string Address { get; set; }

    [Required(ErrorMessage = "UserID is required")]
    public int UserID { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime UpdatedAt { get; set; } = DateTime.Now;
    public User? Creator { get; set; }

    public List<RSVP> Attendees { get; set; } = new List<RSVP>();

}
public class FutureDateAttribute : ValidationAttribute
{
    protected override ValidationResult IsValid(object value, ValidationContext validationContext)
    {
        DateTime date = (DateTime)value;
        if (date < DateTime.Now)
        {
            return new ValidationResult("The date must be in the future.");
        }
        return ValidationResult.Success;
    }
}