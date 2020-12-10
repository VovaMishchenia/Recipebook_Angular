using System.ComponentModel.DataAnnotations;

namespace RecipeBook.DTO
{
    public class CuisineDTO
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
    }
}
