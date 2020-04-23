using System.IO;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Charts.DAL;

namespace Charts.Controllers
{
    public class ChartController : Controller
    {
        private readonly ILogger<ChartController> _logger;

        public ChartController(ILogger<ChartController> logger)
        {
            _logger = logger;
        }

        public IActionResult Info(int id)
        {
            using (var db = new Context())
            {
                var model = db.Track.Include(x => x.SingerTrack)
                                    .ThenInclude(x => x.Singer)
                                    .Include(x => x.ChartTracks)
                                    .ThenInclude(x => x.Chart)
                                    .Where(x => x.ChartTracks.Any(y => y.IDChart == id))
                                    .ToList()
                                    .SelectMany(x => x.ChartTracks)
                                    .Select(x => x.Chart)
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