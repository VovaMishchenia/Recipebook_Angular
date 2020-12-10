using System.Collections.Generic;

namespace RecipeBook.DTO.Result
{
    public class ErrorResultDTO : ResultDTO
    {
        public List<string> Errors { get; set; } = new List<string>();
    }
}
