using Microsoft.EntityFrameworkCore;

namespace TestInGameInWebApi.Model
{
    public class GenreBook
    {
        public int GenreBookId { get; set; }       
        public string Name { get; set; }
        public IEnumerable<Book> Books { get; set; }
    }
}
