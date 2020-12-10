using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RecipeBook.DataAccess;
using RecipeBook.DataAccess.Entities;
using RecipeBook.Domain.Abstraction;
using RecipeBook.DTO;
using System.Collections.Generic;
using System.Linq;

namespace RecipeBook.WebApi_Client.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecipeController : ControllerBase
    {
        private readonly ApplicationContext _context;
        private readonly UserManager<User> _userManager;
        private readonly Mapper mapperToRecipeDTO = null;
        private readonly IJwtTokenService _iJWTTokenService;
        private readonly Mapper mapperToRecipe = null;

        public RecipeController(ApplicationContext context, UserManager<User> userManager, IJwtTokenService iJWTTokenService)
        {
            _context = context;
            _userManager = userManager;
            _iJWTTokenService = iJWTTokenService;
            var config = new MapperConfiguration(cfg => cfg.CreateMap<Recipe, RecipeDTO>()
             .ForMember(x => x.Cuisine, opt => opt.MapFrom(x => _context.Cuisines.Find(x.CuisineId).Name))
             .ForMember(x => x.Type, opt => opt.MapFrom(x => _context.RecipeTypes.Find(x.TypeId).Name)));
            var config2 = new MapperConfiguration(cfg => cfg.CreateMap<RecipeDTO, Recipe>()
             .ForMember(x => x.Cuisine, opt => opt.MapFrom(x => _context.Cuisines.Where(j => j.Name == x.Cuisine).FirstOrDefault()))
             .ForMember(x => x.Type, opt => opt.MapFrom(x => _context.RecipeTypes.Where(j => j.Name == x.Type).FirstOrDefault())));
            //.ForMember(x => x.TypeId, opt => opt.MapFrom(x => x.TypeId))
            //.ForMember(x => x.CuisineId, opt => opt.MapFrom(x => x.CuisineId)));




            mapperToRecipeDTO = new Mapper(config);
            mapperToRecipe = new Mapper(config2);


        }
        [HttpGet("getRecipes")]
       
        public List<RecipeDTO> GetRecipes(string id)
        {
            List<RecipeDTO> results = mapperToRecipeDTO.Map<List<RecipeDTO>>(_context.Recipes.AsEnumerable().Where(x => x.UserId == id).ToList());
            return results;
        }
        [HttpGet("getAllRecipes")]
       
        public List<RecipeDTO> GetAllRecipes()
        {
            List<RecipeDTO> results = mapperToRecipeDTO.Map<List<RecipeDTO>>(_context.Recipes.AsEnumerable().ToList());
            return results;
        }

        [HttpGet("getRecipe")]
   
        public RecipeDTO GetRecipe(int id)
        {
            RecipeDTO recipe = mapperToRecipeDTO.Map<RecipeDTO>(_context.Recipes.Find(id));
            return recipe;
        }

        [HttpPost("deleteRecipe")]
        
        public void DeleteRecipe([FromBody]int id)
        {
            Recipe recipe = _context.Recipes.Find(id);
            if (recipe != null)
            {
                _context.Recipes.Remove(recipe);
                _context.SaveChanges();
            }

        }
        [HttpPost("addRecipe")]
       
        public void AddRecipe([FromBody] RecipeDTO model)
        {
            var token = HttpContext.Request.Headers["Authorization"].ToString().Split(" ")[1];
            var userId = _iJWTTokenService.GetUserId(token);
            _userManager.FindByIdAsync(userId).Result.Recipes.Add(mapperToRecipe.Map<Recipe>(model));
            _context.SaveChanges();

        }
        [HttpPost("updateRecipe")]
        
        public void UpdateRecipe([FromBody] RecipeDTO model)
        {
            var recipe = _context.Recipes.AsNoTracking().FirstOrDefault(x=>x.Id==model.Id);
            var token = HttpContext.Request.Headers["Authorization"].ToString().Split(" ")[1];
            var userId = _iJWTTokenService.GetUserId(token);
            if (recipe != null)
            {
                
                recipe = mapperToRecipe.Map<Recipe>(model);
                recipe.UserId = userId;
                _context.Recipes.Update(recipe);
                _context.SaveChanges();
                
              
            }

        }
        [HttpGet("getTypes")]
        
        public List<RecipeType> GetTypes()
        {
            return _context.RecipeTypes.ToList();
        }
        [HttpPost("addType")]
        public void AddType([FromBody] RecipeType model)
        {
            _context.RecipeTypes.Add(model);
            _context.SaveChanges();
        }
        [HttpGet("getCuisines")]
        
        public List<Cuisine> GetCuisines()
        {
            return _context.Cuisines.ToList();
        }
        [HttpPost("addCuisine")]
       
        public void AddCuisine([FromBody] Cuisine model)
        {
            _context.Cuisines.Add(model);
            _context.SaveChanges();
        }
        [HttpPost("deleteType")]
        
        public void DeleteType(int id)
        {
            var type = _context.RecipeTypes.Find(id);
            if (type != null)
            {
                _context.RecipeTypes.Remove(type);
                _context.SaveChanges();
            }
        }
        [HttpPost("deleteCuisine")]
        
        public void DeleteCuisine(int id)
        {
            var cuisine = _context.Cuisines.Find(id);
            if (cuisine != null)
            {
                _context.Cuisines.Remove(cuisine);
                _context.SaveChanges();
            }
        }
        [HttpGet("searchRecipes")]
        
        public List<RecipeDTO> SearchRecipes(string pattern)
        {
            var token = HttpContext.Request.Headers["Authorization"].ToString().Split(" ")[1];
            var userId = _iJWTTokenService.GetUserId(token);
           
                List<RecipeDTO> recipes = mapperToRecipeDTO.Map<List<RecipeDTO>>(_context.Recipes.Where(x => x.Name.ToLower().Contains(pattern.ToLower()) &&
                x.UserId == userId).ToList());
                return recipes;
            
        }
    }
}
