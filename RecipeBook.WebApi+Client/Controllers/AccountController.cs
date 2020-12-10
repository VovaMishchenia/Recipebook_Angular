using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using RecipeBook.DataAccess;
using RecipeBook.DataAccess.Entities;
using RecipeBook.Domain.Abstraction;
using RecipeBook.DTO;
using RecipeBook.DTO.Result;
using RecipeBook.WebApi_Client.Helpers;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;

namespace RecipeBook.WebApi_Client.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly ApplicationContext _context;
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly IJwtTokenService _iJWTTokenService;
        
        
        private readonly Mapper mapperToRecipeDTO = null;

        public AccountController(ApplicationContext context,
                             UserManager<User> userManager,
                                 IJwtTokenService iJWTTokenService,
                                 SignInManager<User> signInManager
            )
        {
            _context = context;
            _userManager = userManager;
            _iJWTTokenService = iJWTTokenService;
            _signInManager = signInManager;
            
            var config = new MapperConfiguration(cfg => cfg.CreateMap<Recipe, RecipeDTO>()
            .ForMember(x => x.Cuisine, opt => opt.MapFrom(x => x.Cuisine.Name))
            .ForMember(x => x.Type, opt => opt.MapFrom(x => x.Type.Name)));
            var config2 = new MapperConfiguration(cfg => cfg.CreateMap<RecipeDTO, Recipe>()
             .ForMember(x => x.Cuisine, opt => opt.MapFrom(x => new Cuisine { Name = x.Cuisine }))
             .ForMember(x => x.Type, opt => opt.MapFrom(x => new RecipeType { Name = x.Type })));
            mapperToRecipeDTO = new Mapper(config);

        }

        [HttpPost("register")]

        public async Task<ResultDTO> Register([FromBody] UserRegisterDTO model)
        {
            if (!ModelState.IsValid)
            {
                return new ErrorResultDTO()
                {
                    StatusCode = 403,
                    Message = "Error"
                };
            }
            var user = new User()
            {
                UserName = model.Email,
                Email = model.Email,
                PhoneNumber = model.Phone
            };
            var userInfo = new UserInfo
            {
                Address = model.Address,
                FullName = model.FullName,
                Id = user.Id
            };
            var identityResult = await _userManager.CreateAsync(user, model.Password);
            if (!identityResult.Succeeded)
                return new ErrorResultDTO
                {
                    StatusCode = 500,
                    Message = "Registration Error",
                    Errors = CustomValidator.GetErrotByModel(ModelState)

                };
            var result = await _userManager.AddToRoleAsync(user, "User");
            _context.UserInfos.Add(userInfo);

            //var res=_iCuisineService.GetCuisines();
            return new ResultDTO
            {
                StatusCode = 200,
                Message = "OK"
            };
        }
        [HttpPost("login")]

        public async Task<ResultDTO> Login([FromBody] UserLoginDTO model)
        {
            if (!ModelState.IsValid)
            {
                return new ErrorResultDTO
                {
                    StatusCode = 403,
                    Message = "Login Error",
                    Errors = CustomValidator.GetErrotByModel(ModelState)
                };

            }
            var result = await _signInManager.PasswordSignInAsync(model.Email, model.Password, false, false);
            if (!result.Succeeded)
            {
                return new ErrorResultDTO
                {
                    StatusCode = 402,
                    Message = "Login failed",
                    Errors = new List<string>
                    {
                        "Login or password error"
                    }
                };
            }
            else
            {
                var user = await _userManager.FindByEmailAsync(model.Email);
                await _signInManager.SignInAsync(user, false);

               
                return new SuccessResultDTO
                {
                    StatusCode = 200,
                    Message = "Ok",
                    Token = _iJWTTokenService.CreateToken(user)
                };
            }


        }






       
    }
}
