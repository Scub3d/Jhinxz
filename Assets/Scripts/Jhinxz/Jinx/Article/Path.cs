using System.Collections.Generic;
// ReSharper disable All

namespace Jhinx.Jinx.Article {
	public class Path {
		public string Canonical { get; set; }
		public List<string> Alternate { get; set; }
		
		public Path(string canonical, List<string> alternate) {
			Canonical = canonical;
			Alternate = alternate;
		}
	}
}