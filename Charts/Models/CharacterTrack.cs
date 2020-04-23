using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace  Charts.Models
{
	public class CharacterTrack
	{
		public int ID { get; set; }
		public int IDTrack { get; set; }
		public int IDCharacter { get; set; }
		[ForeignKey("IDTrack")]
		public virtual Track Track { get; set; }
		[ForeignKey("IDCharacter")]
		public virtual Character Character { get; set; }
	}
}
