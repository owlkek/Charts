using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Charts.Models
{
	public class Track
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public DateTime DateCreated { get; set; }
		public TimeSpan? Time { get; set; }
		public string Path { get; set; }


		public virtual ICollection<GenreTrack> GenreTrack { get; set; } = new HashSet<GenreTrack>();
		[NotMapped]
		public virtual IEnumerable<Genre> Genres => GenreTrack.Select(x => x.Genre);

		public virtual ICollection<SingerTrack> SingerTrack { get; set; } = new HashSet<SingerTrack>();
		[NotMapped]
		public IEnumerable<Singer> Singers => SingerTrack.Select(x => x.Singer);
	}
}

