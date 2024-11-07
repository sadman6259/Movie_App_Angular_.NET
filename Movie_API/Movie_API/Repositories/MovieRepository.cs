using Movie_API.Models;
using Microsoft.EntityFrameworkCore;

namespace Movie_API.Repositories
{
    public class MovieRepository
    {
        private readonly MovieDbContext movieDbContext;
        public MovieRepository(MovieDbContext _movieDbContext)
        {
            this.movieDbContext = _movieDbContext;
        }

        public List<MovieDTO> GetMovieList(string s)
        {
            try
            {
                List<Movie> movieList = movieDbContext.Movies.Where(x => !string.IsNullOrEmpty(x.MovieTitle) && x.MovieTitle.Contains(s)).ToList();
               
                List<MovieDTO> movieDTOs = new List<MovieDTO>();

                foreach (Movie movie in movieList) {

                    MovieDTO movieDTO = new MovieDTO();

                    movieDTO.Id = movie.Id;
                    movieDTO.MovieTitle = movie.MovieTitle;
                    movieDTO.ReleaseYear = movie.ReleaseYear;
                    movieDTO.PostarImage = movie.PostarImage;
                    movieDTOs.Add(movieDTO);
                }
                return movieDTOs;
            }
            catch (Exception)
            {
                throw;
            }

        }
    }
}
