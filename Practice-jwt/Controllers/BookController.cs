using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Practice_jwt.Models;

namespace Practice_jwt.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    
    public class BookController : ControllerBase
    {
        private readonly List<Book> books;
        public BookController() 
        {
            books = new List<Book>()
            {
                new Book()
                {
                     Id= 1,
                     Name = "Kürk Mantolu Madonna"
                },
                new Book()
                {
                    Id= 2,
                    Name  ="Kuyucaklı Yusuf"
                }
            };
        }

        [HttpGet]
        public IEnumerable<Book> GetBooks()
        {
            return books;
        }

    }
}
