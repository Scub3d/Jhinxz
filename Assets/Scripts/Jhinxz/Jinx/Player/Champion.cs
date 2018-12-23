// ReSharper disable All

using System.Collections.Generic;
using SimpleJSON;

namespace Jhinxz.Jinx.Player {
	public class Champion {
		public int Id { get; set; }
		public int PlayerId { get; set; }
		public string ChampionKey { get; set; }
		public string ChampionName { get; set; }
		public string CreatedAt { get; set; }
		public string UpdatedAt { get; set; }

		public Champion(int id, int playerId, string championKey, string championName, string createdAt, string updatedAt) {
			Id = id;
			PlayerId = playerId;
			ChampionKey = championKey;
			ChampionName = championName;
			CreatedAt = createdAt;
			UpdatedAt = updatedAt;
		}

		public static Champion parseChampionJSON(JSONNode json) {
			return new Champion(json["id"], json["playerId"], json["championKey"], json["championName"], json["createdAt"], json["updatedAt"]);
		}

		public static List<Champion> parseChampionsJSON(JSONArray json) {
			List<Champion> champions = new List<Champion>();
			foreach (JSONNode championJSON in json) {
				champions.Add(parseChampionJSON(championJSON));
			}
			
			return champions;
		}
	}
}