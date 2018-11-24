using System.Collections.Generic;
using SimpleJSON;

// ReSharper disable All

namespace Jhinx.Zoe {
	public class ProPlayer {
		public int Id { get; set; }
		public int RiotId { get; set; }
		public string Name { get; set; }
		public string PhotoURL { get; set; }
		public List<string> Positions { get; set; }
		public int ProTeamId { get; set; }
		public List<FlavorTextEntry> FlavorTextEntries { get; set; } // always null?
		public List<TrendByWeek> TrendsByWeek { get; set; }
		
		public ProPlayer(int id, int riotId, string name, string photoUrl, List<string> positions, int proTeamId, List<FlavorTextEntry> flavorTextEntries, List<TrendByWeek> trendsByWeek) {
			Id = id;
			RiotId = riotId;
			Name = name;
			PhotoURL = photoUrl;
			Positions = positions;
			ProTeamId = proTeamId;
			FlavorTextEntries = flavorTextEntries;
			TrendsByWeek = trendsByWeek;
		}

		public static ProPlayer parseProPlayerJSON(JSONNode json) {
			List<string> positions = Chompers.Chompers.parseStringArrayJSON(json["positions"].AsArray);
			List<FlavorTextEntry> flavorTextEntries = FlavorTextEntry.parseFlavorTextEntriesJSON(json["flavorTextEntries"].AsArray);
			List<TrendByWeek> trendsByWeek = TrendByWeek.parseTrendsByWeekJSON(json["trendsByWeek"]);
			
			return new ProPlayer(json["id"], json["riotId"], json["name"], json["photoUrl"], positions, json["proTeamId"], flavorTextEntries, trendsByWeek);
		}

		public static List<ProPlayer> parseProPlayersJSON(JSONArray json) {
			List<ProPlayer> proPlayers = new List<ProPlayer>();
			foreach (JSONNode proPlayerJSON in json) {
				proPlayers.Add(parseProPlayerJSON(proPlayerJSON));
			}
			
			return proPlayers;
		}
	}
}