using System.Collections.Generic;

namespace Cadastro_Series.src
{
    public class MovieRepository : IRepository<Movie>
    {
        private List<Movie> movies = new List<Movie>();

        public void Delete(int id)
        {
            movies[id].DeletedMovie();
        }

        public Movie ReturnById(int id)
        {
            return movies[id];
        }

        public void Insert(Movie production)
        {
            movies.Add(production);
        }

        public int NextId()
        {
            return movies.Count;
        }

        public void Update(int id, Movie production)
        {
            movies[id] = production;
        }

        public List<Movie> catalog()
        {
            return movies;
        }

    }
}