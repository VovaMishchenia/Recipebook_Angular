using System;
using System.Collections.Generic;
using System.Text;

namespace RecipeBook.DTO
{
    public class MessageDTO
    {
        public string MessageText { get; set; }
        public RecipeDTO Recipe { get; set; }
        public string UserToEmail { get; set; }
    }
}
