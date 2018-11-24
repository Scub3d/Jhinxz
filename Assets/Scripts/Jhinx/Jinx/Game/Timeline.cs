using System.Collections.Generic;
using SimpleJSON;

// ReSharper disable All

namespace Jhinx.Jinx.Game {
	public class Timeline {
		public Dictionary<string, float> CreepsPerMinDeltas { get; set; }
		public Dictionary<string, float> CsDiffPerMinDeltas { get; set; }
		public Dictionary<string, float> DamageTakenDiffPerMinDeltas { get; set; }
		public Dictionary<string, float> DamageTakenPerMinDeltas { get; set; }
		public Dictionary<string, float> GoldPerMinDeltas { get; set; }
		public Dictionary<string, float> XpDiffPerMinDeltas { get; set; }
		public Dictionary<string, float> XpPerMinDeltas { get; set; }

		public Timeline(Dictionary<string, float> creepsPerMinDeltas, Dictionary<string, float> csDiffPerMinDeltas, Dictionary<string, float> damageTakenDiffPerMinDeltas, Dictionary<string, float> damageTakenPerMinDeltas, Dictionary<string, float> goldPerMinDeltas, Dictionary<string, float> xpDiffPerMinDeltas, Dictionary<string, float> xpPerMinDeltas) {
			CreepsPerMinDeltas = creepsPerMinDeltas;
			CsDiffPerMinDeltas = csDiffPerMinDeltas;
			DamageTakenDiffPerMinDeltas = damageTakenDiffPerMinDeltas;
			DamageTakenPerMinDeltas = damageTakenPerMinDeltas;
			GoldPerMinDeltas = goldPerMinDeltas;
			XpDiffPerMinDeltas = xpDiffPerMinDeltas;
			XpPerMinDeltas = xpPerMinDeltas;
		}

		public static Timeline parseTimelineJSON(JSONNode json) {
			Dictionary<string, float> creepsPerMinDeltas = Chompers.Chompers.parseStringFloatDictionaryJSON(json["creepsPerMinDeltas"]);
			Dictionary<string, float> csDiffPerMinDeltas = Chompers.Chompers.parseStringFloatDictionaryJSON(json["csDiffPerMinDeltas"]);
			Dictionary<string, float> damageTakenDiffPerMinDeltas = Chompers.Chompers.parseStringFloatDictionaryJSON(json["damageTakenDiffPerMinDeltas"]);
			Dictionary<string, float> damageTakenPerMinDeltas = Chompers.Chompers.parseStringFloatDictionaryJSON(json["damageTakenPerMinDeltas"]);
			Dictionary<string, float> goldPerMinDeltas = Chompers.Chompers.parseStringFloatDictionaryJSON(json["goldPerMinDeltas"]);
			Dictionary<string, float> xpDiffPerMinDeltas = Chompers.Chompers.parseStringFloatDictionaryJSON(json["xpDiffPerMinDeltas"]);
			Dictionary<string, float> xpPerMinDeltas = Chompers.Chompers.parseStringFloatDictionaryJSON(json["xpPerMinDeltas"]);
			return new Timeline(creepsPerMinDeltas, csDiffPerMinDeltas, damageTakenDiffPerMinDeltas, damageTakenPerMinDeltas, goldPerMinDeltas, xpDiffPerMinDeltas, xpPerMinDeltas);
		}
	}
}