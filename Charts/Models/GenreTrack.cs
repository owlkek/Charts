using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace Charts.Models
{
	public class GenreTrack
	{
		public int Id { get; set; }
		public int IDTrack { get; set; }
		public int IDGenre { get; set; }

		[ForeignKey(nameof(GenreTrack.IDTrack))]
		public Track Track { get; set; }

		[ForeignKey(nameof(GenreTrack.IDGenre))]
		public Genre Genre { get; set; }
	}
}
