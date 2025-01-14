#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
// Needed for the [NotMapped] functionality
using System.ComponentModel.DataAnnotations.Schema;

namespace ProductsAndCategories.Models;

public class Category
{
    [Key]
    public int CategoryId {get;set;}

    [Required]
    public string Name {get;set;}

    public DateTime CreatedAt {get;set;} = DateTime.Now;
    
    public DateTime UpdatedAt {get;set;} = DateTime.Now;

    public List<Association> RelatedItems {get;set;} = new List<Association>();
}