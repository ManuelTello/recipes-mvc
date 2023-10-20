using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace recipes.Models
{
    public class User
    {
        [Key]
        [Column(name: "id")]
        public int Id { get; set; }

        [Column(name: "username")]
        public string Username { get; set; } = string.Empty;

        [Column(name: "email")]
        public string Email { get; set; } = string.Empty;

        [Column(name: "password")]
        public string Password { get; set; } = string.Empty;

        public ICollection<Recipe> Recipes { get; set; } = new List<Recipe>();
    }
}