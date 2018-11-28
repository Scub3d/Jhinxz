using System.Collections.Generic;
using SimpleJSON;

// ReSharper disable All

namespace Jhinx.Jinx.Player {
	public class Player {
		public int Id { get; set; }
		public string Slug { get; set; }
		public string Name { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string RoleSlug { get; set; }
		public string PhotoUrl { get; set; }
		public string Hometown { get; set; }
		public string Region { get; set; }
		public string Birthdate { get; set; }
		public string CreatedAt { get; set; }
		public string UpdatedAt { get; set; }
		public Dictionary<string, string> Bios { get; set; }
		public Dictionary<string, string> ForeignIds { get; set; }
		public Dictionary<string, string> SocialNetworks { get; set; }
		public List<Champion> Champions { get; set; } // Check back on this when LCS resumes
		public List<int> StarterOnTeams { get; set; }
		public List<int> SubOnTeams { get; set; }
		public List<int> Teams { get; set; }
		public PhotoInformation PhotoInformation { get; set; }
		public List<ScheduleItem> ScheduleItems { get; set; }
		public string PlayerStatsSummary { get; set; }
		public List<string> PlayerStatsHistory { get; set; }
		
		public Player(int id, string slug, string name, string firstName, string lastName, string roleSlug, string photoUrl, string hometown, string region, string birthdate, string createdAt, string updatedAt, Dictionary<string, string> bios, Dictionary<string, string> foreignIds, Dictionary<string, string> socialNetworks, List<Champion> champions, List<int> starterOnTeams, List<int> subOnTeams, List<int> teams, PhotoInformation photoInformation, List<ScheduleItem> scheduleItems, string playerStatsSummary, List<string> playerStatsHistory) {
			Id = id;
			Slug = slug;
			Name = name;
			FirstName = firstName;
			LastName = lastName;
			RoleSlug = roleSlug;
			PhotoUrl = photoUrl;
			Hometown = hometown;
			Region = region;
			Birthdate = birthdate;
			CreatedAt = createdAt;
			UpdatedAt = updatedAt;
			Bios = bios;
			ForeignIds = foreignIds;
			SocialNetworks = socialNetworks;
			Champions = champions;
			StarterOnTeams = starterOnTeams;
			SubOnTeams = subOnTeams;
			Teams = teams;
			PhotoInformation = photoInformation;
			ScheduleItems = scheduleItems;
			PlayerStatsSummary = playerStatsSummary;
			PlayerStatsHistory = playerStatsHistory;
		}

		public static Player parsePlayerJSON(JSONNode json) {
			Dictionary<string, string> bios = Chompers.Chompers.parseStringStringDictionaryJSON(json["bios"]);
			Dictionary<string, string> foreignIds = Chompers.Chompers.parseStringStringDictionaryJSON(json["foreignIds"]);
			Dictionary<string, string> socialNetworks = Chompers.Chompers.parseStringStringDictionaryJSON(json["socialNetworks"]);
			List<Champion> champions = Champion.parseChampionsJSON(json["champions"].AsArray);
			List<int> starterOnTeams = Chompers.Chompers.parseIntArrayJSON(json["starterOnTeams"].AsArray);
			List<int> subsOnTeams = Chompers.Chompers.parseIntArrayJSON(json["subsOnTeams"].AsArray);
			List<int> teams = Chompers.Chompers.parseIntArrayJSON(json["teams"].AsArray);
			PhotoInformation photoInformation = PhotoInformation.parsePhotoInformationJSON(json["photoInformaiton"]);
			// Check to see if they are the same format
			List<ScheduleItem> scheduleItems = ScheduleItem.parseScheduleItemsJSON(json["scheduledItems"].AsArray);
			List<string> playerStatsHistory = Chompers.Chompers.parseStringArrayJSON(json["playerStatsHistory"].AsArray);
			
			return new Player(json["id"], json["slug"], json["name"], json["firstName"], json["lastName"],
				json["roleSlug"], json["photoUrl"], json["hometown"], json["region"], json["birthdate"],
				json["createdAt"], json["updatedAt"], bios, foreignIds, socialNetworks, champions, starterOnTeams,
				subsOnTeams, teams, photoInformation, scheduleItems, json["playerStatsSummary"], playerStatsHistory);
		}

		public static List<Player> parsePlayersJSON(JSONArray json) {
			List<Player> players = new List<Player>();
			foreach (JSONNode playerJSON in json) {
				players.Add(parsePlayerJSON(playerJSON));
			}

			return players;
		}
		
		// Yeah. Need to figure it out
	}
}