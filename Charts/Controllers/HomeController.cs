using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Charts.DAL;

using System.Linq;
namespace Charts.Controllers
{
	public class HomeController : Controller
	{
		public readonly ILogger<HomeController> _logger;
		private IHostingEnvironment _env;
		public HomeController(IHostingEnvironment env, ILogger<HomeController> logger)
		{
			_env = env;
			_logger = logger;
		}

		public IActionResult Index()
		{

			using (var db = new Context())
			{
				var model = db.Track
					.Include(x => x.SingerTrack)
					.ThenInclude(x => x.Singer)
					.Include(x => x.GenreTrack)
					.ThenInclude(x => x.Genre)
					.ToList()
					.SelectMany(x => x.GenreTrack)
					.Select(x => x.Genre)
					.Distinct()
					.ToList();
				return View(model);

			}

		}


	}
}
