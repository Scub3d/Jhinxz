// ReSharper disable All

using System.Collections.Generic;
using SimpleJSON;

namespace Jhinx.Jinx.Game {
	public class Mastery {
		public int MasteryId { get; set; }
		public int Rank { get; set; }
		
		public Mastery(int masteryId, int rank) {
			MasteryId = masteryId;
			Rank = rank;
		}

		public static Mastery parseMasteryJSON(JSONNode json) {
			return new Mastery(json["masteryId"], json["rank"]);
		}

		public static List<Mastery> parseMasteriesJSON(JSONNode json) {
			List<Mastery> masteries = new List<Mastery>();
			foreach (JSONNode masteryJSON in json) {
				masteries.Add(parseMasteryJSON(masteryJSON));
			}

			return masteries;
		}
	}
}