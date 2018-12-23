// ReSharper disable All

using System.Collections.Generic;
using SimpleJSON;

namespace Jhinxz.Zoe.Fantasy {
	public class ProMatch {
		public int Id { get; set; }
		public string RiotId { get; set; }
		public int Week { get; set; }
		public string Time { get; set; }
		public int RedTeamId { get; set; }
		public int BlueTeamId { get; set; }
		public bool Complete { get; set; }
		public int Winner { get; set; }
		public int RedTeamPointsMultiplier { get; set; }
		public int BlueTeamPointsMultiplier { get; set; }

		public ProMatch(int id, string riotId, int week, string time, int redTeamId, int blueTeamId, bool complete, int winner, int redTeamPointsMultiplier, int blueTeamPointsMultiplier) {
			Id = id;
			RiotId = riotId;
			Week = week;
			Time = time;
			RedTeamId = redTeamId;
			BlueTeamId = blueTeamId;
			Complete = complete;
			Winner = winner;
			RedTeamPointsMultiplier = redTeamPointsMultiplier;
			BlueTeamPointsMultiplier = blueTeamPointsMultiplier;
		}

		public static ProMatch parseProMatchJSON(JSONNode json) {
			return new ProMatch(json["id"], json["riotId"], json["week"], json["time"], json["redTeamId"], json["blueTeamId"], json["complete"], json["winner"], json["redTeamPointsMultiplier"], json["blueTeamPointsMultiplier"]);
		}
		
		public static List<ProMatch> parseProMatchesJSON(JSONArray json) {
			List<ProMatch> proMatches = new List<ProMatch>();
			foreach (JSONNode proMatchJSON in json) {
				proMatches.Add(parseProMatchJSON(proMatchJSON));
			}
			
			return proMatches;
		}
	}
}