using System.Collections.Generic;
using SimpleJSON;

// ReSharper disable All

namespace Jhinx.Zoe {
	public class Stats {
		public List<TeamStat> ProjectedTeamStats { get; set; }
		public List<TeamStat> ActualTeamStats { get; set; }
		public List<PlayerStat> ProjectedPlayerStats { get; set; }
		public List<PlayerStat> ActualPlayerStats { get; set; }

		public Stats(List<TeamStat> projectedTeamStats, List<TeamStat> actualTeamStats, List<PlayerStat> projectedPlayerStats, List<PlayerStat> actualPlayerStats) {
			ProjectedTeamStats = projectedTeamStats;
			ActualTeamStats = actualTeamStats;
			ProjectedPlayerStats = projectedPlayerStats;
			ActualPlayerStats = actualPlayerStats;
		}

		public static Stats parseStatsJSON(JSONNode json) {
			List<TeamStat> projectedTeamStats = TeamStat.parseTeamStats(json["projectedTeamStats"]);
			List<TeamStat> actualTeamStats = TeamStat.parseTeamStats(json["actualTeamStats"]);
			List<PlayerStat> projectedPlayerStats = PlayerStat.parsePlayerStats(json["projectedPlayerStats"]);
			List<PlayerStat> actualPlayerStats = PlayerStat.parsePlayerStats(json["actualPlayerStats"]);

			return new Stats(projectedTeamStats, actualTeamStats, projectedPlayerStats, actualPlayerStats);
		}
	}
}