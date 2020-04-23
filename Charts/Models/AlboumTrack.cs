using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Charts.Models
{
	public class AlboumTrack
	{
		public int ID { get; set; }
		public int IDTrack { get; set; }
		public int IDAlboum { get; set; }
		[ForeignKey(nameof(AlboumTrack.IDTrack))]
		public virtual Track Track { get; set; }
		[ForeignKey(nameof(AlboumTrack.IDAlboum))]
		public virtual Alboum Alboum { get; set; }
	}
}
