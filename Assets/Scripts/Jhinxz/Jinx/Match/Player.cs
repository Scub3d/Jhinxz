using System.Collections.Generic;
using Jhinxz.Jhin.Champion;
using SimpleJSON;

// ReSharper disable All

namespace Jhinxz.Jinx.Match {
	// See if needed. Only adding LiveGameTeam. Removing some other stuff tho
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
		public List<int> Champions { get; set; } // Check back on this when LCS resumes
		public int LiveGameTeam { get; set; }
		
		public Player(int id, string slug, string name, string firstName, string lastName, string roleSlug, string photoUrl, string hometown, string region, string birthdate, string createdAt, string updatedAt, Dictionary<string, string> bios, Dictionary<string, string> foreignIds, Dictionary<string, string> socialNetworks, List<int> champions, int liveGameTeam) {
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
			LiveGameTeam = liveGameTeam;
		}

		public static Player parsePlayerJSON(JSONNode json) {
			Dictionary<string, string> bios = Chompers.Chompers.parseStringStringDictionaryJSON(json["bios"]);
			Dictionary<string, string> foreignIds = Chompers.Chompers.parseStringStringDictionaryJSON(json["foreignIds"]);
			Dictionary<string, string> socialNetworks = Chompers.Chompers.parseStringStringDictionaryJSON(json["socialNetworks"]);
			List<int> champions = Chompers.Chompers.parseIntArrayJSON(json["champions"].AsArray);

			return new Player(json["id"], json["slug"], json["name"], json["firstName"], json["lastName"],
				json["roleSlug"], json["photoUrl"], json["hometown"], json["region"], json["birthdate"],
				json["createdAt"], json["updatedAt"], bios, foreignIds, socialNetworks, champions,
				json["liveGameTeam"]);
		}

		public static List<Player> parsePlayersJSON(JSONArray json) {
			List<Player> players = new List<Player>();
			foreach (JSONNode playerJSON in json) {
				players.Add(parsePlayerJSON(playerJSON));
			}

			return players;
		}
	}
}