using System.Collections.Generic;
using SimpleJSON;

// ReSharper disable All

namespace Jhinxz.Jinx.Game {
	public class Team {
		public int TeamId { get; set; }
		public bool Win { get; set; }
		public bool FirstBlood { get; set; }
		public bool FirstTower { get; set; }
		public bool FirstInhibitor { get; set; }
		public bool FirstBaron { get; set; }
		public bool FirstDragon { get; set; }
		public bool FirstRiftHerald { get; set; }
		public int TowerKills { get; set; }
		public int InhibitorKills { get; set; }
		public int BaronKills { get; set; }
		public int DragonKills { get; set; }
		public int VilemawKills { get; set; }
		public int RiftHeraldKills { get; set; }
		public int DominionVictoryScore { get; set; }
		public List<Ban> Bans { get; set; }

		public Team(int teamId, bool win, bool firstBlood, bool firstTower, bool firstInhibitor, bool firstBaron, bool firstDragon, bool firstRiftHerald, int towerKills, int inhibitorKills, int baronKills, int dragonKills, int vilemawKills, int riftHeraldKills, int dominionVictoryScore, List<Ban> bans) {
			TeamId = teamId;
			Win = win;
			FirstBlood = firstBlood;
			FirstTower = firstTower;
			FirstInhibitor = firstInhibitor;
			FirstBaron = firstBaron;
			FirstDragon = firstDragon;
			FirstRiftHerald = firstRiftHerald;
			TowerKills = towerKills;
			InhibitorKills = inhibitorKills;
			BaronKills = baronKills;
			DragonKills = dragonKills;
			VilemawKills = vilemawKills;
			RiftHeraldKills = riftHeraldKills;
			DominionVictoryScore = dominionVictoryScore;
			Bans = bans;
		}
		
		public static Team parseTeamJSON(JSONNode json) {
			List<Ban> bans = Ban.parseBansJSON(json["bans"]);
			return new Team(json["teamId"], json["win"], json["firstBlood"], json["firstTower"], json["firstInhibitor"], 
				json["firstBaron"], json["firstDragon"], json["firstRiftHerald"], json["towerkills"], json["inhibitorKills"], 
				json["baronKills"], json["dragonKills"], json["vilemawKills"], json["riftHeraldKills"], json["dominionVictoryScore"], bans);
		}

		public static List<Team> parseTeamsJSON(JSONNode json) {
			List<Team> teams = new List<Team>();
			foreach (JSONNode teamJSON in json) {
				teams.Add(parseTeamJSON(teamJSON));
			}
			
			return teams;
		}
	}
}