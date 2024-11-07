using Movie_API.Interfaces;
using Movie_API.Models;
using Movie_API.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Movie_API.Services
{
    public class MovieService : IMovieService
    {
        private readonly MovieRepository repo = null;
        private readonly MovieDbContext context;
        public MovieService(IConfiguration Config)
        {
            this.context = new MovieDbContext(Config);
            this.repo = new MovieRepository(this.context);

        }
     
        public List<MovieDTO> GetMovieList(string s)
        {
            try
            {
                return repo.GetMovieList(s);
            }
            catch(Exception) { throw; }
        }

       
    }
}
