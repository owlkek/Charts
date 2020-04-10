using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Charts.Models
{
	public class Genre
	{
		public int Id { get; set; }
		public string Name { get; set; }

		public virtual ICollection<GenreTrack> GenreTracks { get; set; } = new HashSet<GenreTrack>();

		[NotMapped]
		public virtual IEnumerable<Track> Tracks => GenreTracks.Select(x => x.Track);
	}
}
