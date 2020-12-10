using System.ComponentModel.DataAnnotations;

namespace RecipeBook.DTO
{
    public class RecipeTypeDTO
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
    }
}
