using Practice_jwt.Abstract;
using Practice_jwt.Dtos;
using Practice_jwt.Models;

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
            throw new NotImplementedException();
        }
    }
}
