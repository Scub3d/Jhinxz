using System.Collections.Generic;
using SimpleJSON;

// ReSharper disable All

namespace Jhinx.Zoe.Fantasy {
	public class Stats {
		public List<ProjectedTeamStat> ProjectedTeamStats { get; set; }
		public List<ActualTeamStat> ActualTeamStats { get; set; }
		public List<ProjectedPlayerStat> ProjectedPlayerStats { get; set; }
		public List<ActualPlayerStat> ActualPlayerStats { get; set; }

		public Stats(List<ProjectedTeamStat> projectedTeamStats, List<ActualTeamStat> actualTeamStats, List<ProjectedPlayerStat> projectedPlayerStats, List<ActualPlayerStat> actualPlayerStats) {
			ProjectedTeamStats = projectedTeamStats;
			ActualTeamStats = actualTeamStats;
			ProjectedPlayerStats = projectedPlayerStats;
			ActualPlayerStats = actualPlayerStats;
		}

		public static Stats parseStatsJSON(JSONNode json) {
			List<ProjectedTeamStat> projectedTeamStats = ProjectedTeamStat.parseProjectedTeamStatsJSON(json["projectedTeamStats"].AsArray);
			List<ActualTeamStat> actualTeamStats = ActualTeamStat.parseActualTeamStatsJSON(json["actualTeamStats"].AsArray);
			List<ProjectedPlayerStat> projectedPlayerStats = ProjectedPlayerStat.parseProjectedPlayerStatsJSON(json["projectedPlayerStats"].AsArray);
			List<ActualPlayerStat> actualPlayerStats = ActualPlayerStat.parseActualPlayerStatsJSON(json["actualPlayerStats"].AsArray);

			return new Stats(projectedTeamStats, actualTeamStats, projectedPlayerStats, actualPlayerStats);
		}
	}
}