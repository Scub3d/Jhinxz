using System.Collections.Generic;
using SimpleJSON;
// ReSharper disable All

namespace Jhinxz.Zoe.Fantasy {
	public class ProjectedPlayerStat {
		public int PlayerId { get; set; }
		public int TeamId { get; set; }
		public int MatchId { get; set; }
		public int GameId { get; set; }
		public float Kills { get; set; }
		public float Deaths { get; set; }
		public float Assists { get; set; }
		public float Cs { get; set; }
		public float DoubleKills { get; set; }
		public float TripleKills { get; set; }
		public float QuadraKills { get; set; }
		public float PentaKills { get; set; }
		public float TenPlusKDA { get; set; }

		public ProjectedPlayerStat(int playerId, int teamId, int matchId, int gameId, float kills, float deaths, float assists, float cs, float doubleKills, float tripleKills, float quadraKills, float pentaKills, float tenPlusKda) {
			PlayerId = playerId;
			TeamId = teamId;
			MatchId = matchId;
			GameId = gameId;
			Kills = kills;
			Deaths = deaths;
			Assists = assists;
			Cs = cs;
			DoubleKills = doubleKills;
			TripleKills = tripleKills;
			QuadraKills = quadraKills;
			PentaKills = pentaKills;
			TenPlusKDA = tenPlusKda;
		}

		public static ProjectedPlayerStat parseProjectedPlayerStatJSON(JSONArray json) {
			return new ProjectedPlayerStat(json[0], json[1], json[2], json[3], json[4], json[5], json[6], json[7], json[8],
				json[9], json[10], json[11], json[12]);
		}

		public static List<ProjectedPlayerStat> parseProjectedPlayerStatsJSON(JSONArray json) {
			List<ProjectedPlayerStat> playerStats = new List<ProjectedPlayerStat>();
			foreach (JSONArray playerStatJSON in json) {
				playerStats.Add(parseProjectedPlayerStatJSON(playerStatJSON));
			}

			return playerStats;
		}
	}
}