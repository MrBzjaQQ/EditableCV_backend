using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EditableCV_backend.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace EditableCV_backend.Controllers
{
  [Route("api/register")]
  [ApiController]
  public class RegisterController : ControllerBase
  {
    public RegisterController(UserManager<User> userManager, SignInManager<User> signInManager)
    {
      _userManager = userManager;
      _signInManager = signInManager;
    }

    [HttpPost]
    public async Task<IActionResult> Register(RegisterModel registerData)
    {
      User user = new User
      {
        Email = registerData.Email,
        UserName = registerData.UserName,
      };
      var result = await _userManager.CreateAsync(user, registerData.Password);
      if (result.Succeeded)
      {
        await _signInManager.SignInAsync(user, false);
        return Ok(ModelState);
      }
      else
      {
        foreach(var error in result.Errors)
        {
          ModelState.AddModelError("errors", error.Description);
        }
      }
      return BadRequest(ModelState);
    }

    private readonly UserManager<User> _userManager;
    private readonly SignInManager<User> _signInManager;
  }
}
