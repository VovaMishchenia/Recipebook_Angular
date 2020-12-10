using System;
using System.Collections.Generic;
using System.Text;

namespace RecipeBook.DataAccess.Entities
{
    public class RecipeUserInfo
    {
        public int RecipeId { get; set; }
        public Recipe Recipe { get; set; }

        public int UserInfoId { get; set; }
        public UserInfo UserInfo { get; set; }
    }
}
