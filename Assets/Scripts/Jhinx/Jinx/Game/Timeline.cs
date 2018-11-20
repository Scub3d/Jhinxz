using System.Collections.Generic;
// ReSharper disable All

namespace Jhinx.Jinx.Game {
	public class Timeline {
		public Dictionary<string, float> CreepsPerMinDeltas { get; set; }
		public Dictionary<string, float> CsDiffPerMinDeltas { get; set; }
		public Dictionary<string, float> DamageTakeDiffPerMineDeltas { get; set; }
		public Dictionary<string, float> DamageTakenPerMinDeltas { get; set; }
		public Dictionary<string, float> GoldPerMinDeltas { get; set; }
		public Dictionary<string, float> XpDiffPerMinDeltas { get; set; }
		public Dictionary<string, float> XpPerMinDeltas { get; set; }

		public Timeline(Dictionary<string, float> creepsPerMinDeltas, Dictionary<string, float> csDiffPerMinDeltas, Dictionary<string, float> damageTakeDiffPerMineDeltas, Dictionary<string, float> damageTakenPerMinDeltas, Dictionary<string, float> goldPerMinDeltas, Dictionary<string, float> xpDiffPerMinDeltas, Dictionary<string, float> xpPerMinDeltas) {
			this.CreepsPerMinDeltas = creepsPerMinDeltas;
			this.CsDiffPerMinDeltas = csDiffPerMinDeltas;
			this.DamageTakeDiffPerMineDeltas = damageTakeDiffPerMineDeltas;
			this.DamageTakenPerMinDeltas = damageTakenPerMinDeltas;
			this.GoldPerMinDeltas = goldPerMinDeltas;
			this.XpDiffPerMinDeltas = xpDiffPerMinDeltas;
			this.XpPerMinDeltas = xpPerMinDeltas;
		}
	}
}