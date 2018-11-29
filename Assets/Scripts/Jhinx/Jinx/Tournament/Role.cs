// ReSharper disable All

using System.Collections.Generic;
using SimpleJSON;

namespace Jhinx.Jinx.Tournament {
	public class Role {
		public string Origin { get; set; }
		public string Region { get; set; }
		public string SummonerName { get; set; }
		public int SummonerLevel { get; set; }
		public int ProfileIconId { get; set; }
		public bool Admin { get; set; }
		
		public Role(string origin, string region, string summonerName, int summonerLevel, int profileIconId, bool admin) {
			Origin = origin;
			Region = region;
			SummonerName = summonerName;
			SummonerLevel = summonerLevel;
			ProfileIconId = profileIconId;
			Admin = admin;
		}

		public static Role parseRoleJSON(JSONNode json) {
			return new Role(json["origin"], json["region"], json["summonerName"], json["summonerLevel"], json["profileIconId"], json["admin"]);
		}

		public static List<Role> parseRolesJSON(JSONArray json) {
			List<Role> roles = new List<Role>();
			foreach (JSONNode roleJSON in json) {
				roles.Add(parseRoleJSON(roleJSON));
			}

			return roles;
		}
	}
}