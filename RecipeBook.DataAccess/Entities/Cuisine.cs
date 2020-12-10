using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace RecipeBook.DataAccess.Entities
{
    public class Cuisine
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public virtual ICollection<Recipe> Recipes { get; set; }

        public Cuisine() {
            Recipes = new List<Recipe>();
        }
    }
}
