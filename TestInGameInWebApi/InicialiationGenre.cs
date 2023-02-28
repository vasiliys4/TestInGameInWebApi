using Microsoft.EntityFrameworkCore;
using TestInGameInWebApi.Model;

namespace TestInGameInWebApi
{
    public static class InicialiationGenre
    {
        public static void Seeder(ApplicationContext db)
        {
            db.genreBooks.AddRange(
                new List<GenreBook>
                {
                    new GenreBook {Name = "horror" },
                    new GenreBook { Name = "Fantasy"},
                    new GenreBook { Name = "Comedy"}
                });
            db.SaveChanges();
        }
    }
}
