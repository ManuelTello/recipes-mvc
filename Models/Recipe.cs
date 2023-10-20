using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace recipes.Models
{
    public class Recipe
    {
        [Key]
        [Column(name: "id")]
        public int Id { get; set; }

        [Column(name: "title")]
        public string Title { get; set; } = string.Empty;

        [Column(name: "cookingtime")]
        public int CookingTime { get; set; }

        [Column(name: "difficulty")]
        public string Difficulty { get; set; } = string.Empty;

        [Column(name: "steps")]
        public string Steps { get; set; } = string.Empty;

        [Column(name: "ingredients")]
        public string Ingredients { get; set; } = string.Empty;

        [Column(name: "datecreated")]
        public string DateCreated { get; set; } = string.Empty;

        [Column(name: "userid")]
        public int UserId { get; set; }

        public User User { get; set; }
    }
}