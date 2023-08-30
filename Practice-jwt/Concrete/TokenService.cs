using Microsoft.IdentityModel.Tokens;
using Practice_jwt.Abstract;
using Practice_jwt.Dtos;
using Practice_jwt.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace Practice_jwt.Concrete
{
    public class TokenService : ITokenService
    {
        private readonly TokenOptions _tokenOptions;
        private readonly IConfiguration _configuration;
        public TokenService(IConfiguration configuration)
        {
            _configuration = configuration;
            _tokenOptions = _configuration.GetSection("TokenOption").Get<TokenOptions>(); // appsettingsden okuduk nesneye çevirdik
        }

        public TokenDto CreateToken(UserApp userApp)
        {
            var securityKey = SignService.GetSymmetricSecurityKey(_tokenOptions.SecurityKey);
            var accessTokenExpiration = DateTime.Now.AddMinutes(_tokenOptions.AccessTokenExpiration);

            SigningCredentials signingCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256Signature);
            JwtSecurityToken jwtSecurityToken = new JwtSecurityToken
                (
                    issuer : _tokenOptions.Issuer,
                    expires : accessTokenExpiration,
                    notBefore : DateTime.Now,
                    claims : GetClaims(userApp, new List<string> { _tokenOptions.Audience }),
                    signingCredentials : signingCredentials
                );

            var token = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken);

            var tokenDto = new TokenDto
            {
                Token = token,
                Expiration = accessTokenExpiration,
            };

            return tokenDto;
        }

        private IEnumerable<Claim> GetClaims(UserApp userApp , List<string> audiences)
        {
            var userList = new List<Claim>()
            {
                new Claim(ClaimTypes.NameIdentifier , userApp.Id),
                new Claim(JwtRegisteredClaimNames.Email, userApp.Email),
                new Claim(ClaimTypes.Name,userApp.UserName),
                new Claim(JwtRegisteredClaimNames.Jti , Guid.NewGuid().ToString())  
            };

            userList.AddRange(audiences.Select(x=> new Claim(JwtRegisteredClaimNames.Aud,x)));

            return userList;
        }
    }
}
