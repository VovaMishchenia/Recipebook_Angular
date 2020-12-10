using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace RecipeBook.DataAccess.Entities
{
    public class Message
    {
        [Key]
        public int Id { get; set; }
        public virtual UserInfo FromUser { get; set; }
        public virtual UserInfo ToUser { get; set; }
        public virtual Recipe Recipe { get; set; }
        public string MessageText { get; set; }
    }
}
