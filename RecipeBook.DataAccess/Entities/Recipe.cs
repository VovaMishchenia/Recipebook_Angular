using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace RecipeBook.DataAccess.Entities
{
    public class Recipe
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Ingredients { get; set; }
        public string PhotoPath { get; set; }
        [Required]
        public string Instruction { get; set; }

        public virtual Cuisine Cuisine { get; set; }
       
        public virtual RecipeType Type { get; set; }
        [Required]
        public float CookingTime { get; set; }
        public int Rating { get; set; }
        [Required]
        public int Calories{ get; set; }
       
        public int CuisineId { get; set; }
        public int TypeId { get; set; }

        public string UserId { get; set; }
        public virtual User User { get; set; }

    }
}
