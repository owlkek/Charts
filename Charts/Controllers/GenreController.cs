using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Charts.DAL;
using System.Collections.Generic;
using System.Linq;


namespace Charts.Controllers
{
	public class GenreController : Controller
	{
		public readonly ILogger<HomeController> _logger;

		private IHostingEnvironment _env;

		public GenreController(IHostingEnvironment env, ILogger<HomeController> logger)
		{
			_env = env;
			_logger = logger;
		}
		public IActionResult Info(int id)
		{
			using (var db = new Context())
			{
				var model = db.Track
					.Include(x => x.SingerTrack)
					.ThenInclude(x => x.Singer)
					.Include(x => x.GenreTrack)
					.ThenInclude(x => x.Genre)
					.Where(x => x.GenreTrack.Any(y => y.IDGenre == id))
					.ToList()
					.SelectMany(x => x.GenreTrack)
					.Select(x => x.Genre)
					.FirstOrDefault();
				return View(model);

			}
		}



	}
}