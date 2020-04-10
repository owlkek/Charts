using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using MusicCharts.DAL;

namespace MusicCharts.Controllers
{
	public class GenreController : Controller
	{
		private readonly ILogger<GenreController> _logger;

		public GenreController(ILogger<GenreController> logger)
		{
			_logger = logger;
		}

		public IActionResult Info(int id)
		{
			using (var db = new Context())
			{
				var model = db.Track.Include(x => x.SingerTracks)
									.ThenInclude(x => x.Singer)
									.Include(x => x.GenreTracks)
									.ThenInclude(x => x.Genre)
									.Where(x => x.GenreTracks.Any(y => y.IDGenre == id))
									.ToList()
									.SelectMany(x => x.GenreTracks)
									.Select(x => x.Genre)
									.FirstOrDefault();

				return View(model);
			}
		}
	}
}