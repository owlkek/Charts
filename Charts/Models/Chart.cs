using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace  Charts.Models
{
	public class Chart
	{
		public int ID { get; set; }
		public string Name { get; set; }

		public virtual ICollection<ChartTrack> ChartTracks { get; set; } = new HashSet<ChartTrack>();
		[NotMapped]
		public virtual IEnumerable<Track> Tracks { get { return ChartTracks.Select((x) => x.Track); } }
	}
}
