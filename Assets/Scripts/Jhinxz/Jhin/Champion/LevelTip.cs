using System.Collections.Generic;
using SimpleJSON;
using UnityEngine;

// ReSharper disable All

namespace Jhinxz.Jhin.Champion {
	public class LevelTip {
		public List<string> Label { get; set; }
		public List<string> Effect { get; set; }
		
		public LevelTip(List<string> label, List<string> effect) {
			Label = label;
			Effect = effect;
		}

		// Ugh
		public static LevelTip parseLevelTipJSON(JSONNode json) {
			List<string> label = null;
			List<string> effect = null;
			
			if (json["label"] != null) {
				label = Chompers.Chompers.parseStringArrayJSON(json["label"].AsArray);
			} else {
				label = null;
			}

			if (json["effect"] != null) {
				effect = Chompers.Chompers.parseStringArrayJSON(json["effect"].AsArray);
			} else {
				effect = null;
			}
			
			return new LevelTip(label, effect);
		}
	}
}