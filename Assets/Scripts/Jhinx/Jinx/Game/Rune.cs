// ReSharper disable All

using System.Collections.Generic;
using SimpleJSON;

namespace Jhinx.Jinx.Game {
	public class Rune {
		public int RuneId { get; set; }
		public int Rank { get; set; }
		
		public Rune(int runeId, int rank) {
			RuneId = runeId;
			Rank = rank;
		}

		public static Rune parseRuneJSON(JSONNode json) {
			return new Rune(json["runeId"], json["rank"]);
		}

		public static List<Rune> parseRunesJSON(JSONNode json) {
			List<Rune> runes = new List<Rune>();
			foreach (JSONNode runeJSON in json) {
				runes.Add(parseRuneJSON(runeJSON));
			}

			return runes;
		}
	}
}