using ApiTaskFromFurdak.Options;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ApiTaskFromFurdak.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AuthenticationController : ControllerBase
{
    private readonly AuthorizationOptions _authorizationOptions;

	public AuthenticationController(IOptions<AuthorizationOptions> options)
	{
        _authorizationOptions = options.Value;
	}

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [Produces("application/json")]
    public IActionResult Authenticate(string userName, string password)
    {
        if (!userName.Equals(_authorizationOptions.Username) && !password.Equals(_authorizationOptions.Password))
        {
            return Unauthorized();
        }

        var securityKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_authorizationOptions.SecretForKey));

        var signingCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

        var claimsForToken = new List<Claim>
        {
            new("username", userName),
            new("password", password)
        };

        var jwtSecurityToken = new JwtSecurityToken(claims: claimsForToken, expires: DateTime.Now.AddHours(1),
            signingCredentials: signingCredentials);

        return Ok(new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken));
    }
}
