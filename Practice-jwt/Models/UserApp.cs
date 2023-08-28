using Microsoft.AspNetCore.Identity;

namespace Practice_jwt.Models
{
    public class UserApp : IdentityUser
    {
        public string? City { get; set; }
    }
}
