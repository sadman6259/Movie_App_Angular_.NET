using EntityFrameworkCoreMock;
using Movie_API.Controllers;
using Movie_API.Models;
using Movie_API.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MovieAPI_Test
{
    public class UnitTestMovieAPI
    {
        private DbContextMock<MovieDbContext> getDbContext(Movie[] initialEntities)
        {
            DbContextMock<MovieDbContext> dbContextMock = new DbContextMock<MovieDbContext>(new DbContextOptionsBuilder<MovieDbContext>().Options);
            dbContextMock.CreateDbSetMock(x => x.Movies, initialEntities);
            return dbContextMock;
        }

        private MovieRepository MovieRepoInit(DbContextMock<MovieDbContext> dbContextMock)
        {
            return new MovieRepository(dbContextMock.Object);
        }

        private Movie[] getInitialDbEntities()
        {
            return new Movie[]
             {
                new Movie {Id = 1, MovieTitle ="ssd", ReleaseYear =2023 },
                new Movie {Id = 2, MovieTitle ="b", ReleaseYear = 2023 },
                new Movie {Id = 3, MovieTitle ="c", ReleaseYear = 2022  },
            };
        }

        [Fact]
        public void GetMovieList_Success()
        {
            DbContextMock<MovieDbContext> dbContextMock = getDbContext(getInitialDbEntities());
            MovieRepository movieRepository = MovieRepoInit(dbContextMock);

            var result = movieRepository.GetMovieList("ssd").FirstOrDefault();
            MovieDTO value = result;

            Assert.Equal("ssd", result.MovieTitle);
        }
        
    }
}