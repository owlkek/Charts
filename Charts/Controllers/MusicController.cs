using System.IO;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Charts.DAL;

namespace Charts.Controllers
{
	public class MusicController : Controller
	{
		private readonly ILogger<MusicController> _logger;

		public MusicController(ILogger<MusicController> logger)
		{
			_logger = logger;
		}

		public IActionResult Info(int id)
		{
			using (var db = new Context())
			{
				var model = db.Track.Include(x => x.SingerTrack)
									.ThenInclude(x => x.Singer)
									.Include(x => x.GenreTrack)
									.ThenInclude(x => x.Genre)
									.Where(x => x.SingerTrack.Any(y => y.IDTrack == id))
									.ToList()
									.FirstOrDefault();


				//Чистка папки audio
				DirectoryInfo dirInfo = new DirectoryInfo(@"D:\Учеба\ВУЗ\3 курс\2й семестр\МиСПИСиТ\Практики\практика 6\Charts\Charts\wwwroot\audio");
				foreach (FileInfo file in dirInfo.GetFiles())
				{
					file.Delete();
				}

				return View(model);
			}
		}
	}
}