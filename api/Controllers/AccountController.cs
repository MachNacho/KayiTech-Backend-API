using api.Dtos.Account;
using api.Interfaces;
using api.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace api.Controllers
{
    [Route("/account")]
    [ApiController]
    public class AccountController:ControllerBase
    {
        private readonly UserManager<QuizUser> _UserManager; //User identity manager
        private readonly iTokenService _itokenservice; //JWT token service
        private readonly SignInManager<QuizUser> _signInManager;
        public AccountController(UserManager<QuizUser> userManager, iTokenService iTokenService,SignInManager<QuizUser> signInManager){
            _UserManager = userManager;
            _itokenservice = iTokenService;
            _signInManager = signInManager;
        }
        
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterDTO Register){
            try
            {
                if(!ModelState.IsValid)return BadRequest(ModelState);//checks if inputted data is valid to the model
                var user = new QuizUser
                {
                    UserName = Register.Username,
                    UserFirstName = Register.UserFirstName,
                    UserLastName = Register.UserLastName,
                    Email = Register.Email
                };
                var userEmail = await _UserManager.Users.FirstOrDefaultAsync(x => x.Email == user.Email); //Checks if user email exists
                if(userEmail != null) return Unauthorized("Invalid email");
                var createUser = await _UserManager.CreateAsync(user,Register.Password); // Checks DB if user can be created

                if(createUser.Succeeded){
                    var roleResult = await _UserManager.AddToRoleAsync(user,"User"); //adds user role for customer
                    if(roleResult.Succeeded)
                    {
                        return Ok(                
                            new NewUserDTO{
                                Email = user.Email,
                                UserName = user.UserName,
                                Token =  _itokenservice.createToken(user),
                                userID = user.Id
                            }
                        );
                    }
                    else
                    {
                        return StatusCode(500, roleResult.Errors);
                    }
                }
                else
                {
                    return StatusCode(500, createUser.Errors);
                }
            }
            catch(Exception ex)
            {
                 return StatusCode(500, ex);
            }
        }
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginDTO login)
        {
            if(!ModelState.IsValid)return BadRequest(ModelState);//checks if inputted data is valid to the model
            var user = await _UserManager.Users.FirstOrDefaultAsync(x => x.Email == login.Email); //Checks if user email exists
            if(user == null) return Unauthorized("Invalid Username!");
            var result = await _signInManager.CheckPasswordSignInAsync(user,login.Password,false); //Verifies password
            if(!result.Succeeded)return Unauthorized("User not found and/or password incorrect");
            return Ok(
                new NewUserDTO{
                    Email = user.Email,
                    UserName = user.UserName,
                    Token =  _itokenservice.createToken(user),
                    userID = user.Id
                }
            );
        }
        
    }
}   
