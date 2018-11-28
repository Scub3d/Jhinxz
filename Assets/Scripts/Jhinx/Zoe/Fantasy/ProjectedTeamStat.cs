using System.Collections.Generic;
using SimpleJSON;
// ReSharper disable All

namespace Jhinx.Zoe.Fantasy {
	public class ProjectedTeamStat {
		public int TeamId { get; set; }
		public int MatchId { get; set; }
		public int GameId { get; set; }
		public int FirstBlood { get; set; }
		public int TowersDestroyed { get; set; }
		public float BaronsKilled { get; set; }
		public float DragonsKilled { get; set; }
		public int Victory { get; set; }
		public int Defeat { get; set; }
		public int QuickWinBonus { get; set; }

		public ProjectedTeamStat(int teamId, int matchId, int gameId, int firstBlood, int towersDestroyed, float baronsKilled, float dragonsKilled, int victory, int defeat, int quickWinBonus) {
			TeamId = teamId;
			MatchId = matchId;
			GameId = gameId;
			FirstBlood = firstBlood;
			TowersDestroyed = towersDestroyed;
			BaronsKilled = baronsKilled;
			DragonsKilled = dragonsKilled;
			Victory = victory;
			Defeat = defeat;
			QuickWinBonus = quickWinBonus;
		}

		public static ProjectedTeamStat parseProjectedTeamStatJSON(JSONArray json) {
			return new ProjectedTeamStat(json[0], json[1], json[2], json[3], json[4], json[5], json[6], json[7], json[8], json[9]);
		}

		public static List<ProjectedTeamStat> parseProjectedTeamStatsJSON(JSONArray json) {
			List<ProjectedTeamStat> projectedTeamStats = new List<ProjectedTeamStat>();
			foreach (JSONArray projectedTeamStatJSON in json) {
				projectedTeamStats.Add(parseProjectedTeamStatJSON(projectedTeamStatJSON));
			}
			
			return projectedTeamStats;
		}
	}
}