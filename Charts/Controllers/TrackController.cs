using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Charts.DAL;
using FileIO = System.IO.File;
using System.IO;
using Microsoft.AspNetCore.Hosting;


namespace Charts.Controllers
{
	public class TrackController : Controller
	{
		private readonly ILogger<TrackController> _logger;

		private readonly IHostingEnvironment _env;

		private const string musicDir = @"D:\Учеба\ВУЗ\3 курс\2й семестр\МиСПИСиТ\Практики\практика 6\Charts\Charts";

		public TrackController(IHostingEnvironment env, ILogger<TrackController> logger)
		{
			_env = env;
			_logger = logger;
		}

		public IActionResult LoadMusic(int Id)
		{
			using (var db = new Context())
			{
				var track = db.Track.Include(x => x.SingerTrack)
									.ThenInclude(x => x.Singer)
									.Include(x => x.GenreTrack)
									.ThenInclude(x => x.Genre)
									.FirstOrDefault(x => x.ID == Id);

				if (track == null)
				{
					var ex = new Exception($"Track is not found by ID = {Id}");
					_logger.LogWarning(ex, "", null);
					throw ex;
				}
				if (string.IsNullOrEmpty(track.Path))
				{
					var ex = new Exception($"Track path is empty by ID = {Id}");
					_logger.LogWarning(ex, "", null);
					throw ex;
				}

				var buf = FileIO.ReadAllBytes(Path.Combine(musicDir, track.Path));
				var webPath = Path.Combine("audio", $"{track.ID}{Path.GetExtension(track.Path)}");
				var path = Path.Combine(_env.WebRootPath, webPath);

				FileIO.WriteAllBytes(path, buf);

				//special path for web
				webPath = @"" + webPath.Replace("/", @"");
				return Json(webPath);
			}
		}
	}
}