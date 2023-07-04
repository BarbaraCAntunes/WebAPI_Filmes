using Filmes.Models;


namespace Filmes.Mocks
{
    public static class MockData
    {
        public static List<Filme> Filmes = new List<Filme>
        {
            new Filme(1, "Matrix", "2h 30m", "Lana Wachowski, Lilly Wachowski", "Ação, Ficção científica"),
            new Filme(2, "Interestelar", "2h 49m", "Christopher Nolan", "Aventura, Drama, Ficção científica"),
            new Filme(3, "Inception", "2h 28m", "Christopher Nolan", "Ação, Aventura, Ficção científica"),
            new Filme(4, "Pulp Fiction", "2h 34m", "Quentin Tarantino", "Crime, Drama"),
            new Filme(5, "The Dark Knight", "2h 32m", "Christopher Nolan", "Ação, Crime, Drama")
        };
    }
}
