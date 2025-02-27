using Azure.Core;
using first.EF.ServicesUser;
using First.Core.JwtMapper;
using First.Core.Models;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace First.ServicesUser
{
    public class TokenServices
    {
        private readonly JwtMap _jwt;
        //private readonly IHttpContextAccessor _httpContextAccessor;
        public TokenServices(IOptions<JwtMap> jwt)
        {
            _jwt = jwt.Value;
        }
        public JwtSecurityToken GenerateToken(User user)
        {
            var claims = new List<Claim> {
            new Claim("Email",user.Email),
            new Claim("UserId",user.Id.ToString()),
            };
            // for signature
            var symmetricKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwt.Key));
            var signingCredentials = new SigningCredentials(symmetricKey, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: _jwt.Issuer,
                audience: _jwt.Audience,
                expires: DateTime.Now.AddDays(7),
                claims: claims,
                signingCredentials: signingCredentials
                );
            return token;
        }
        //public ClaimsDto GetClaim()
        //{
        //    var authorizationHeader = Request.Headers["Authorization"].ToString();
        //    var token = authorizationHeader.Replace("Bearer ", "");
        //    var handler = new JwtSecurityTokenHandler();
        //    var jwtToken = handler.ReadJwtToken(token);
        //    var email = jwtToken.Claims.FirstOrDefault(c => c.Type == "Email")?.Value;
        //    var UserId = jwtToken.Claims.FirstOrDefault(c => c.Type == "UserId")?.Value;
        //    return new ClaimsDto { Email = email, UserId = int.Parse(UserId) };
        //}
    }
}
