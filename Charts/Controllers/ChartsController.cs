using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Charts.DAL;

namespace Charts.Controllers
{
    public class ChartsController : Controller
    {
        public IActionResult Index()
        {
            using (var db = new Context())
            {
                var model = db.Track
                              .Include(x => x.ChartTracks)
                              .ThenInclude(x => x.Chart)
                              .Include(x => x.SingerTrack)
                              .ThenInclude(x => x.Singer)
                              .ToList()
                              .SelectMany(x => x.ChartTracks)
                              .Select(x => x.Chart)
                              .Distinct()
                              .ToList();

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