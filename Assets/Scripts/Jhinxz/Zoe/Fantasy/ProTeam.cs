using System.Collections.Generic;
using SimpleJSON;

// ReSharper disable All

namespace Jhinxz.Zoe.Fantasy {
	public class ProTeam {
		public int Id { get; set; }
		public int RiotId { get; set; }
		public string Name { get; set; }
		public string ShortName { get; set; }
		public List<FlavorTextEntry> FlavorTextEntries { get; set; }
		public List<TrendByWeek> TrendsByWeek { get; set; }
		public List<string> Positions { get; set; }
		public string League { get; set; }
		
		public ProTeam(int id, int riotId, string name, string shortName, List<FlavorTextEntry> flavorTextEntries, List<TrendByWeek> trendsByWeek, List<string> positions, string league) {
			Id = id;
			RiotId = riotId;
			Name = name;
			ShortName = shortName;
			FlavorTextEntries = flavorTextEntries;
			TrendsByWeek = trendsByWeek;
			Positions = positions;
			League = league;
		}

		public static ProTeam parseProTeamJSON(JSONNode json) {
			List<FlavorTextEntry> flavorTextEntries = FlavorTextEntry.parseFlavorTextEntriesJSON(json["flavorTextEntries"].AsArray);
			List<TrendByWeek> trendsByWeek = TrendByWeek.parseTrendsByWeekJSON(json["trendsByWeek"]);
			List<string> positions = Chompers.Chompers.parseStringArrayJSON(json["positions"].AsArray);
			
			return new ProTeam(json["id"], json["riotId"], json["name"], json["shortName"], flavorTextEntries, trendsByWeek, positions, json["league"]);
		}

		public static List<ProTeam> parseProTeamsJSON(JSONArray json) {
			List<ProTeam> proTeams = new List<ProTeam>();
			foreach (JSONNode proTeamJSON in json) {
				proTeams.Add(parseProTeamJSON(proTeamJSON));
			}

			return proTeams;
		}
	}
}