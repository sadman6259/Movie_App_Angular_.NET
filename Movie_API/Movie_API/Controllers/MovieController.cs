using Movie_API.Interfaces;
using Movie_API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Data;


namespace Movie_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        IMovieService movieService;
        public MovieController(IMovieService _movieService)
        {
            movieService = _movieService;
        }

        [HttpGet]

        public IActionResult GetMoviesbyTitle(string s,string apikey)
        {
            try
            {
                List<MovieDTO> movieList = movieService.GetMovieList(s);
                return Ok(movieList);
            }
            catch (Exception )
            {
                throw ;
            }

        }

    }
}
