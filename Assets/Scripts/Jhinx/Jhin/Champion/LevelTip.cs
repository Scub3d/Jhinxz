using System.Collections.Generic;
// ReSharper disable All

namespace Jhinx.Jhin.Champion {
	public class LevelTip {
		public List<string> Label { get; set; }
		public List<string> Effect { get; set; }
		
		public LevelTip(List<string> label, List<string> effect) {
			Label = label;
			Effect = effect;
		}
	}
}