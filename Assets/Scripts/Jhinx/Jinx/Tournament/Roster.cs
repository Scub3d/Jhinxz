// ReSharper disable All

using System.Collections.Generic;
using SimpleJSON;

namespace Jhinx.Jinx.Tournament {	
	public class Roster {
		public string Id { get; set; }
		public string Name { get; set; }
		public string Roles { get; set; } // null??
		public string TeamReference { get; set; }
		public string Substitutions { get; set; } // null??
		public string Team { get; set; }

		public Roster(string id, string name, string roles, string teamReference, string substitutions, string team) {
			Id = id;
			Name = name;
			Roles = roles;
			TeamReference = teamReference;
			Substitutions = substitutions;
			Team = team;
		}

		public static Roster parseRosterJSON(JSONNode json) {
			return new Roster(json["id"], json["name"], json["roles"], json["teamReference"], json["substitutions"], json["team"]);
		}

		public static List<Roster> parseRostersJSON(JSONArray json) {
			List<Roster> rosters = new List<Roster>();
			foreach (JSONNode rosterJSON in json) {
				rosters.Add(parseRosterJSON(rosterJSON));
			}
			
			return rosters;
		}
	}
}