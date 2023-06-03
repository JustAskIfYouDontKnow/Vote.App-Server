using System.Security.Claims;

using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using VoteApp.Database;
using VoteApp.Database.User;
using VoteApp.Models.API.User;

namespace VoteApp.Host.Controllers.Client;


public class UserController : AbstractClientController
{
   public UserController(IDatabaseContainer databaseContainer) : base(databaseContainer)
   { }
   
   [AllowAnonymous]
   [HttpPost]
   public async Task<IActionResult> Register(RequestRegisterUser requestRegisterUser)
   {
      if (!ModelState.IsValid)
      {
         return BadRequest();
      }
      
      await DatabaseContainer.UserWeb.CreateUser(
         requestRegisterUser.Login,
         requestRegisterUser.FirstName,
         requestRegisterUser.LastName,
         requestRegisterUser.Phone,
         requestRegisterUser.Password);
      
                
      return Ok();
   }


   [AllowAnonymous]
   [HttpPost]
   public async Task<IActionResult> Login([FromBody] RequestLoginUser requestLoginUser)
   {
      if (!ModelState.IsValid)
      {
         return BadRequest();
      }
      
      var user = await DatabaseContainer.UserWeb.FindOneByLogin(requestLoginUser.Login);

      if (user is null)
      {
         return BadRequest();
      }

      if (user.Password != requestLoginUser.Password)
      {
         return Forbid();
      }

      var claims = new[]
      {
         new Claim(UserClaims.Id.ToString(),   user.Id.ToString()),
         new Claim(UserClaims.Name.ToString(), user.FirstName),
         new Claim(UserClaims.Role.ToString(), user.UserRole.ToString())
      };
        
      var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
      var principal = new ClaimsPrincipal(identity);
        
      await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);
      return Ok();
   }
}