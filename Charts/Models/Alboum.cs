using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Charts.Models
{
	public class Alboum
	{
		public int ID { get; set; }
		public string Name { get; set; }
		public DateTime DateCreated { get; set; }

		public virtual ICollection<AlboumTrack> AlboumTracks { get; set; } = new HashSet<AlboumTrack>();
		[NotMapped]
		public virtual IEnumerable<Track> Tracks { get { return AlboumTracks.Select((x) => x.Track); } }
	}
}
