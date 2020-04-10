using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Charts.Models;
using Charts.DAL;
using Microsoft.EntityFrameworkCore;

using Charts;
using Microsoft.AspNetCore.Hosting;
using System.IO;

namespace Charts.Controllers
{
	public class HomeController : Controller
	{
		private readonly ILogger<HomeController> _logger;
		///private IWebHostEnvironment _env;

		public HomeController(ILogger<HomeController> logger/*, IWebHostEnvironment env*/)
		{
			_logger = logger;
			//_env = env;
		}

		public IActionResult Index()
		{
			var liet = new List<Track>();


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

		public IActionResult Privacy()
		{
			return View();
		}



		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
	}
}

