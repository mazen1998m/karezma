//using App.Domain.Auths;
//using App.Domain.Users;
//using App.web.JwtServices;
//using Microsoft.AspNetCore.Mvc;
//using System.Security.Claims;

//namespace App.web.Controllers;

////[CustomAuthorize]
//public class AccountController : ControllerBase
//{
//    [HttpPost("login")]
//    public IActionResult Login([FromBody] AuthRequest request)
//    {
//        // Validate user credentials
//        // ...

//        // Generate token
//        var claims = new List<Claim>
//        {
//            new ("name", request.EmailOrUsername),
//        };

//        var token = TokenService.GenerateToken(claims);

//        // Set token in cookies
//        Response.Cookies.Append("jwt", token, new CookieOptions
//        {
//            HttpOnly = true,
//            SameSite = SameSiteMode.Strict
//        });

//        return Ok(new { Token = token });
//    }

//    [HttpPost("logout")]
   
//    public IActionResult Logout()
//    {
       
//        // Remove token from cookies
//        //Response.Cookies.Delete("jwt");
//        var x= HttpContext.User.FindFirst("name");
//        var y = User.FindFirst("name");
//        return Ok(y);
//    }
//}

