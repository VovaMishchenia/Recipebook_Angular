using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace RecipeBook.DataAccess.Entities
{
    public class User:IdentityUser
    {
        public virtual UserInfo UserInfo { get; set; }
        public virtual ICollection<Recipe> Recipes { get; set; }

        public User()
        {
            Recipes = new List<Recipe>();
        }
    }
}
