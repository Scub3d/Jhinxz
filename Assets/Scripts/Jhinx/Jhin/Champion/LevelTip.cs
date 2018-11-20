using System.Collections.Generic;
using SimpleJSON;

// ReSharper disable All

namespace Jhinx.Jhin.Champion {
	public class LevelTip {
		public List<string> Label { get; set; }
		public List<string> Effect { get; set; }
		
		public LevelTip(List<string> label, List<string> effect) {
			Label = label;
			Effect = effect;
		}

		public static LevelTip parseLevelTipJSON(JSONNode json) {
			return new LevelTip(Chompers.Chompers.parseStringArrayJSON(json["label"].AsArray),
				Chompers.Chompers.parseStringArrayJSON(json["effect"].AsArray));
		}
	}
}