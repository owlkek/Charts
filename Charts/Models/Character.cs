using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Charts.Models
{
	public class Character
	{
		public int ID { get; set; }
		public string Name { get; set; }

		[NotMapped]
		public virtual ICollection<CharacterTrack> CharacterTrack { get; set; } = new List<CharacterTrack>();
		[NotMapped]
		public virtual IEnumerable<Track> Tracks { get { return CharacterTrack.Select((x) => x.Track); } }
	}
}
