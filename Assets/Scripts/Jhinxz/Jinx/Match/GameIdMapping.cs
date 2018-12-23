using System.Collections.Generic;
using SimpleJSON;
// ReSharper disable All

namespace Jhinxz.Jinx.Match {
	public class GameIdMapping {
		public string Id { get; set; }
		public string GameHash { get; set; }
		
		public GameIdMapping(string id, string gameHash) {
			Id = id;
			GameHash = gameHash;
		}

		public static GameIdMapping parseGameIdMappingJSON(JSONNode json) {
			return new GameIdMapping(json["id"], json["gameHash"]);
		}

		public static List<GameIdMapping> parseGameIdMappingsJSON(JSONArray json) {
			List<GameIdMapping> gameIdMappings = new List<GameIdMapping>();
			foreach (JSONNode gameIdMappingJSON in json) {
				gameIdMappings.Add(parseGameIdMappingJSON(gameIdMappingJSON));
			}

			return gameIdMappings;
		}
	}
}