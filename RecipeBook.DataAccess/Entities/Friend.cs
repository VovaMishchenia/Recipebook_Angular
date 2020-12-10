using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace RecipeBook.DataAccess.Entities
{
    public class Friend
    {
        [Key]
        public int Id { get; set; }
        public virtual UserInfo FriendUser1 { get; set; }
        public virtual UserInfo FriendUser2 { get; set; }
    }
}
