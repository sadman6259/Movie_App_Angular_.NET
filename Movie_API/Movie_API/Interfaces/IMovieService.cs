using Movie_API.Models;

namespace Movie_API.Interfaces
{
    public interface IMovieService
    {
        List<MovieDTO> GetMovieList(string s);
      

    }
}
