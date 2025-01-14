using System;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace CRUDelicious.Models
{
    public class Dish
    {
        [Key]

        public int DishesId { get; set; }
        [Required]
        public string DishName { get; set; }
        [Required]
        public string ChefName { get; set; }
        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Please enter a value bigger than zero")]
        public int Calories { get; set; }
        [Required]
        public int Tastiness { get; set; }
        [Required]
        public string Description { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;

        public DateTime UpdatedAt { get; set; } = DateTime.Now;
    }
}