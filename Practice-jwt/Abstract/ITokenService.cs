using Practice_jwt.Dtos;
using Practice_jwt.Models;

namespace Practice_jwt.Abstract
{
    public interface ITokenService
    {
        TokenDto CreateToken(UserApp userApp);
    }
}
