using App.Domain.Users;
using App.Domain.Users.Auths;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace App.Application.Users;

public class JwtService
{
    #region ctor

    private readonly IHttpContextAccessor _httpContextAccessor;
    private readonly IConfiguration _configuration;

    public JwtService(
        IHttpContextAccessor httpContextAccessor,
        IConfiguration configuration
    )
    {
        _httpContextAccessor = httpContextAccessor;
        _configuration = configuration;
    }


    #endregion

    private string CreateToken(LoginResponse user)
    {
        var jwtSecurityToken = new JwtSecurityToken(
            claims: GetUserAsClaim(user),
            expires: Convert.ToDateTime(DateTime.Now.AddDays(10)),
            signingCredentials: GetSigningCredentials()
        );

        var token = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken);
        user.Token = token;
        return token;

    }

    private static IEnumerable<Claim> GetUserAsClaim(LoginResponse user)
    => new[]
        {
            new Claim(nameof(User.Id), user.Id.ToString()),
        };


    public void SetToken(LoginResponse user)
    {

        var token = CreateToken(user);
        _httpContextAccessor.HttpContext!.Response.Cookies.Append("token", token, new CookieOptions
        {
            HttpOnly = true,
            Expires = DateTime.Now.AddDays(1),
        });
    }
    private SigningCredentials GetSigningCredentials()
    {
        var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
        return new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
    }

    public void RemoveToken() => _httpContextAccessor.HttpContext!.Response.Cookies.Delete("token");





}
