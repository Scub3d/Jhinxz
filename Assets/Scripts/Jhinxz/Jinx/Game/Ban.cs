// ReSharper disable All

using System.Collections.Generic;
using SimpleJSON;

namespace Jhinxz.Jinx.Game {
	public class Ban {
		public int ChampionId { get; set; }
		public int PickTurn { get; set; }

		public Ban(int championId, int pickTurn) {
			ChampionId = championId;
			PickTurn = pickTurn;
		}

		public static Ban parseBanJSON(JSONNode json) {
			return new Ban(json["championId"], json["pickTurn"]);
		}

		public static List<Ban> parseBansJSON(JSONNode json) {
			List<Ban> bans = new List<Ban>();
			foreach (JSONNode banJSON in json) {
				bans.Add(parseBanJSON(banJSON));
			}

			return bans;
		}
	}
}