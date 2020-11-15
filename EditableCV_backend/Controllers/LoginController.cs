using EditableCV_backend.DataTransferObjects.LoginDto;
using EditableCV_backend.Exceptions.Auth;
using EditableCV_backend.Models;
using EditableCV_backend.Options.Tokens;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace EditableCV_backend.Controllers
{
  [Route("api/login")]
  [ApiController]
  public class LoginController: ControllerBase
  {
    public LoginController(UserManager<User> userManager, SignInManager<User> signInManager)
    {
      _userManager = userManager;
      _signInManager = signInManager;
    }

    [HttpPost]
    public async Task<IActionResult> Login(LoginModel model)
    {
      if (ModelState.IsValid)
      {
        User user = await _userManager.FindByEmailAsync(model.Email);
        if (user == null)
        {
          ModelState.AddModelError("error", "Incorrect email");
          return BadRequest(ModelState);
        }
        var result = await _signInManager.PasswordSignInAsync(user, model.Password, true, false);
        if (result.Succeeded)
        {
          // return Ok(ModelState);
          var now = DateTime.UtcNow;
          var jwt = new JwtSecurityToken(
            issuer: AuthOptions.ISSUER,
            audience: AuthOptions.AUDIENCE,
            notBefore: now,
            expires: now.Add(TimeSpan.FromMinutes(AuthOptions.LIFETIME)),
            signingCredentials: new SigningCredentials(AuthOptions.GetSymmetricSecurityKey(), SecurityAlgorithms.HmacSha256)
           );
          string token = new JwtSecurityTokenHandler().WriteToken(jwt);
          var tokenResult = await _userManager.SetAuthenticationTokenAsync(user, AuthOptions.ISSUER, AuthOptions.TOKEN_NAME, token);
          if (tokenResult.Succeeded)
          {
            return Ok(new LoginSucceedResponceDto
            {
              AccessToken = token,
              Email = model.Email,
            });
          } else
          {
            foreach(var error in tokenResult.Errors)
            {
              ModelState.AddModelError("errors", error.Description);
            }
            return BadRequest(ModelState);
          }

        }
        else
        {
          ModelState.AddModelError("errors", "Incorrect password");
        }
      }
      return BadRequest(ModelState);
    }

    private readonly UserManager<User> _userManager;
    private readonly SignInManager<User> _signInManager;
  }
}
