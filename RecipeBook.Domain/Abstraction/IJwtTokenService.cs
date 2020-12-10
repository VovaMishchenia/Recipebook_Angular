using RecipeBook.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace RecipeBook.Domain.Abstraction
{
    public interface IJwtTokenService
    {
        string CreateToken(User user);
        string GetUserId(string token);
    }
}
