﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NotesApp.Models;
using NotesApp.Services.Interface;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NotesApp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
  

        public UserController(IUserService userService)
        {
            _userService = userService;
        }


        [HttpPost("authenticate")]
        [AllowAnonymous]
        public IActionResult Authenticate([FromBody] LoginModel model)
        {
            try
            {
                UserModel user = _userService.Authenticate(model.Username, model.Password);
                if(user == null)
                {
                    Log.Information($"the user with username {model.Username}  and password {model.Password} doesnt exist in the db");
                    return NotFound("User does not exist!");
                }
                return Ok(user);
            }
            catch (Exception ex)
            {
                Log.Error(ex, $"Message: {ex.Message}");
                return BadRequest("Username or password is incorrect!");
            }
        }



        [HttpPost("register")]
        [AllowAnonymous]
        public IActionResult Register([FromBody] RegisterModel model)
        {
            try
            {
                _userService.Register(model);
                return Ok("Successfully registered user!");
            }
            catch
            {
                return BadRequest("Something went wrong! Please try again later!");
            }
        }
    }
}
