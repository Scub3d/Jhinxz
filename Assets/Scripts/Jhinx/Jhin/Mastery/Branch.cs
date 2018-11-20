using System.Collections.Generic;
// ReSharper disable All

namespace Jhinx.Jhin.Mastery {
	public class Branch {
		public string Name { get; set; }
		public List<List<Entry>> Entries { get; set; }
		
		public Branch(string name, List<List<Entry>> entries) {
			Name = name;
			Entries = entries;
		}
		
		// TODO: This is also a bit fucky
	}
}