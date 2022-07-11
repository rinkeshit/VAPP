using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VAPP.Data;
using VAPP.Models;
using VAPP.ViewModels;

namespace VAPP.Controllers
{
    [EnableCors]
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private readonly VAPPContext _context;

        public MoviesController(VAPPContext context)
        {
            _context = context;
        }

        // GET: api/Movies
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Movie>>> GetMovie()
        {
            return await _context.Movie.ToListAsync();
        }

        // GET: api/Movies/5
        [HttpGet]
        [Route("GetMovieByCategory/{id}")]
        public async Task<ActionResult<IEnumerable<Movie>>> GetMovieByCategory(int id)
        {
            var movie = await (from m in _context.Movie
                               where m.CategoryId == id
                               select new Movie
                               {
                                   Id = m.Id,
                                   Title = m.Title,
                                   Poster=m.Poster
                               }).ToListAsync(); 

            if (movie == null)
            {
                return NotFound();
            }

            return movie;
        }


        // GET: api/Movies/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Movie>> GetMovie(int id)
        {
            //var movie =await (from m in _context.Movie
            //              where m.Id == id
            //              select new MovieVM
            //              {
            //                  MovieId = m.Id,
            //                  Title = m.Title,
            //                  Year = m.Year,
            //                  NumberOfSeason = m.NumberOfSeason,
            //                  Plot = m.Plot,
            //                  Cast = m.Cast,
            //                  Creator = m.Creator,
            //                  Seasons = (from s in _context.Season
            //                             where s.MovieId == m.Id
            //                             select new MovieSeasonVM
            //                             {
            //                                 Id = s.Id,
            //                                 Name = s.Name,
            //                                 episodes = (from ep in _context.Episode
            //                                            where ep.SeasonId == s.Id
            //                                            select new MovieSeasonEpisodeVM
            //                                            {
            //                                                Id = ep.Id,
            //                                                Title = ep.Title,
            //                                                Duration = ep.Duration,
            //                                                Plot = ep.Plot,
            //                                                Video = ep.Video,
            //                                                Poster=ep.Poster
            //                                            }
            //                                          ).ToList()
            //                             }).ToList()
            //              }).FirstOrDefaultAsync();





            var movie = await _context.Movie.FindAsync(id);

            if (movie == null)
            {
                return NotFound();
            }

            return movie;
        }

        // GET: api/Movies/5
        [HttpGet]
        [Route("GetMovie1/{id}")]
        public async Task<ActionResult<MovieVM>> GetMovie1(int id)
        {
            var movie = await (from m in _context.Movie
                               where m.Id == id
                               select new MovieVM
                               {
                                   MovieId = m.Id,
                                   Title = m.Title,
                                   Year = m.Year,
                                   NumberOfSeason = m.NumberOfSeason,
                                   Plot = m.Plot,
                                   Cast = m.Cast,
                                   Creator = m.Creator,
                                   Seasons = (from s in _context.Season
                                              where s.MovieId == m.Id
                                              select new MovieSeasonVM
                                              {
                                                  Id = s.Id,
                                                  Name = s.Name,
                                                  episodes = (from ep in _context.Episode
                                                              where ep.SeasonId == s.Id
                                                              select new MovieSeasonEpisodeVM
                                                              {
                                                                  Id = ep.Id,
                                                                  Title = ep.Title,
                                                                  Duration = ep.Duration,
                                                                  Plot = ep.Plot,
                                                                  Video = ep.Video,
                                                                  Poster = ep.Poster
                                                              }
                                                           ).ToList()
                                              }).ToList()
                               }).FirstOrDefaultAsync();





            //var movie = await _context.Movie.FindAsync(id);

            if (movie == null)
            {
                return NotFound();
            }

            return movie;
        }

        // PUT: api/Movies/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMovie(int id, Movie movie)
        {
            if (id != movie.Id)
            {
                return BadRequest();
            }

            _context.Entry(movie).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MovieExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Movies
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Movie>> PostMovie(Movie movie)
        {
            _context.Movie.Add(movie);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMovie", new { id = movie.Id }, movie);
        }

        // DELETE: api/Movies/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMovie(int id)
        {
            var movie = await _context.Movie.FindAsync(id);
            if (movie == null)
            {
                return NotFound();
            }

            _context.Movie.Remove(movie);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool MovieExists(int id)
        {
            return _context.Movie.Any(e => e.Id == id);
        }
    }
}
