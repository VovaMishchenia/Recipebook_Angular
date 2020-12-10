using RecipeBook.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace RecipeBook.DTO
{
    public class RecipeDTO
    {
       
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Ingredients { get; set; }
        public string PhotoPath { get; set; }
        [Required]
        public string Instruction { get; set; }
        [Required]
        public string Cuisine { get; set; }
        [Required]
        public string Type { get; set; }
        [Required]
        public float CookingTime { get; set; }
        public int Rating { get; set; }
        [Required]
        public int Calories { get; set; }
        public int CuisineId { get; set; }
        public int TypeId { get; set; }
    }
}
