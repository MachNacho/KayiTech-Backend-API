using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.Account;
using api.Interfaces;
using api.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace api.Controllers
{
    [Route("api/account")]
    [ApiController]
    public class AccountController:ControllerBase
    {
        private readonly UserManager<User> _UserManager;
        private readonly iTokenService _itokenservice;
        private readonly SignInManager<User> _signInManager;
        public AccountController(UserManager<User> userManager, iTokenService iTokenService,SignInManager<User> signInManager){
            _UserManager = userManager;
            _itokenservice = iTokenService;
            _signInManager = signInManager;
        }
        
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterDTO Register){
            try
            {
                if(!ModelState.IsValid)return BadRequest(ModelState);
                var user = new User
                {
                    UserName = Register.Username,
                    UserFirstName = Register.UserFirstName,
                    UserLastName = Register.UserLastName,
                    Email = Register.Email
                };
                var userEmail = await _UserManager.FindByEmailAsync(user.Email);
                if(userEmail != null){return StatusCode(500);}
                var createUser = await _UserManager.CreateAsync(user,Register.Password);
                if(createUser.Succeeded){
                    var roleResult = await _UserManager.AddToRoleAsync(user,"User");
                    if(roleResult.Succeeded)
                    {
                        return Ok(                
                            new NewUserDTO{
                                Email = user.Email,
                                UserName = user.UserName,
                                Token =  _itokenservice.createToken(user)
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
                return BadRequest(ex.Message);
            }
        }
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginDTO login)
        {
            if(!ModelState.IsValid)return BadRequest(ModelState);
            var user = await _UserManager.Users.FirstOrDefaultAsync(x => x.Email == login.Email);
            if(user == null) return Unauthorized("Invalid Username!");
            var result = await _signInManager.CheckPasswordSignInAsync(user,login.Password,false);
            if(!result.Succeeded)return Unauthorized("Username not found and/or password incorrect");
            return Ok(
                new NewUserDTO{
                    Email = user.Email,
                    UserName = user.UserName,
                    Token =  _itokenservice.createToken(user)
                }
            );
        }
        
    }
}   