using System.Collections.Generic;
using SimpleJSON;

// ReSharper disable All

namespace Jhinx.Jinx.Match {
	public class Team {
		public int Id { get; set; }
		public string Slug { get; set; }
		public string Name { get; set; }
		public string Guid { get; set; }
		public string TeamPhotoURL { get; set; }
		public string LogoURL { get; set; }
		public string Acronym { get; set; }
		public string HomeLeague { get; set; }
		public string AltLogoURL { get; set; }
		public string CreatedAt { get; set; }
		public string UpdatedAt { get; set; }
		public Dictionary<string, string> Bios { get; set; }
		public Dictionary<string, string> ForeignIds { get; set; }
		public List<int> Players { get; set; }
		public List<int> Starters { get; set; }
		public List<int> Subs { get; set; }

		public Team(int id, string slug, string name, string guid, string teamPhotoUrl, string logoUrl, string acronym, string homeLeague, string altLogoUrl, string createdAt, string updatedAt, Dictionary<string, string> bios, Dictionary<string, string> foreignIds, List<int> players, List<int> starters, List<int> subs) {
			Id = id;
			Slug = slug;
			Name = name;
			Guid = guid;
			TeamPhotoURL = teamPhotoUrl;
			LogoURL = logoUrl;
			Acronym = acronym;
			HomeLeague = homeLeague;
			AltLogoURL = altLogoUrl;
			CreatedAt = createdAt;
			UpdatedAt = updatedAt;
			Bios = bios;
			ForeignIds = foreignIds;
			Players = players;
			Starters = starters;
			Subs = subs;
		}

		public static Team parseTeamJSON(JSONNode json) {
			Dictionary<string, string> bios = Chompers.Chompers.parseStringStringDictionaryJSON(json["bios"]);
			Dictionary<string, string> foreignIds = Chompers.Chompers.parseStringStringDictionaryJSON(json["foreignIds"]);
			List<int> players = Chompers.Chompers.parseIntArrayJSON(json["players"].AsArray);
			List<int> starters = Chompers.Chompers.parseIntArrayJSON(json["starters"].AsArray);
			List<int> subs = Chompers.Chompers.parseIntArrayJSON(json["subs"].AsArray);

			return new Team(json["id"], json["slug"], json["name"], json["guid"], json["teamPhotoUrl"], json["logoUrl"],
				json["acronym"], json["homeLeague"], json["altLogoUrl"], json["createdAt"], json["updatedAt"], bios,
				foreignIds, players, starters, subs);
		}

		public static List<Team> parseTeamsJSON(JSONArray json) {
			List<Team> teams = new List<Team>();
			foreach (JSONNode teamJSON in json) {
				teams.Add(parseTeamJSON(teamJSON));
			}
			
			return teams;
		}
	}
}