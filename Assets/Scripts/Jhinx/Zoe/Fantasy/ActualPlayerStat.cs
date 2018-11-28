// ReSharper disable All

using System.Collections.Generic;
using SimpleJSON;

namespace Jhinx.Zoe.Fantasy {
	public class ActualPlayerStat {
		public int PlayerId { get; set; }
		public int TeamId { get; set; }
		public int MatchId { get; set; }
		public int GameId { get; set; }
		public int Kills { get; set; }
		public int Deaths { get; set; }
		public int Assists { get; set; }
		public int Cs { get; set; }
		public int DoubleKills { get; set; }
		public int TripleKills { get; set; }
		public int QuadraKills { get; set; }
		public int PentaKills { get; set; }
		public int TenPlusKDA { get; set; }

		public ActualPlayerStat(int playerId, int teamId, int matchId, int gameId, int kills, int deaths, int assists, int cs, int doubleKills, int tripleKills, int quadraKills, int pentaKills, int tenPlusKda) {
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

		public static ActualPlayerStat parseActualPlayerStatJSON(JSONArray json) {
			return new ActualPlayerStat(json[0], json[1], json[2], json[3], json[4], json[5], json[6], json[7], json[8],
				json[9], json[10], json[11], json[12]);
		}

		public static List<ActualPlayerStat> parseActualPlayerStatsJSON(JSONArray json) {
			List<ActualPlayerStat> playerStats = new List<ActualPlayerStat>();
			foreach (JSONArray playerStatJSON in json) {
				playerStats.Add(parseActualPlayerStatJSON(playerStatJSON));
			}

			return playerStats;
		}
	}
}