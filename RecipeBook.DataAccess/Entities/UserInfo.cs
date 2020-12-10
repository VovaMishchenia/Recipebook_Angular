﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace RecipeBook.DataAccess.Entities
{
    public class UserInfo
    {
        [Key]
        public string Id { get; set; }
        public string FullName { get; set; }
        public string Address { get; set; }
        //public virtual ICollection<Recipe> Recipes { get; set; }
        
        //public UserInfo()
        //{
        //    Recipes = new List<Recipe>();
            
        //}
       
        public virtual User User { get; set; }
    }
}
