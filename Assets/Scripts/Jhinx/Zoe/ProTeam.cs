using System.Collections.Generic;
// ReSharper disable All

namespace Jhinx.Zoe {
	public class ProTeam {
		public int Id { get; set; }
		public int RiotId { get; set; }
		public string Name { get; set; }
		public string ShortName { get; set; }
		public List<string> FlavorTextEntries { get; set; } // always null?
		public List<TrendByWeek> TrendsByWeek { get; set; }
		public List<string> Positions { get; set; }
		public string League { get; set; }
		
	}
}