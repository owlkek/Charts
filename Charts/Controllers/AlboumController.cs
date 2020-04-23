using System.IO;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Charts.DAL;

namespace  Charts.Controllers
{
	public class AlboumController : Controller
	{
		private readonly ILogger<AlboumController> _logger;

		public AlboumController(ILogger<AlboumController> logger)
		{
			_logger = logger;
		}

		public IActionResult Info(int id)
		{
			using (var db = new Context())
			{
				var model = db.Track.Include(x => x.SingerTrack)
									.ThenInclude(x => x.Singer)
									.Include(x => x.AlboumTracks)
									.ThenInclude(x => x.Alboum)
									.Where(x => x.AlboumTracks.Any(y => y.IDAlboum == id))
									.ToList()
									.SelectMany(x => x.AlboumTracks)
									.Select(x => x.Alboum)
									.FirstOrDefault();

				//Чистка папки audio
				DirectoryInfo dirInfo = new DirectoryInfo("D:\\Projects\\MusicCharts\\MusicCharts\\wwwroot\\audio");
				foreach (FileInfo file in dirInfo.GetFiles())
				{
					file.Delete();
				}

				return View(model);
			}
		}
	}
}