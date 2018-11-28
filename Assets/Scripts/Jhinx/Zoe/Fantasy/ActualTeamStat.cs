// ReSharper disable All

using System.Collections.Generic;
using SimpleJSON;

namespace Jhinx.Zoe.Fantasy {
	public class ActualTeamStat {
		public int TeamId { get; set; }
		public int MatchId { get; set; }
		public int GameId { get; set; }
		public int FirstBlood { get; set; }
		public int TowersDestroyed { get; set; }
		public int BaronsKilled { get; set; }
		public int DragonsKilled { get; set; }
		public int Victory { get; set; }
		public int Defeat { get; set; }
		public int QuickWinBonus { get; set; }

		public ActualTeamStat(int teamId, int matchId, int gameId, int firstBlood, int towersDestroyed, int baronsKilled, int dragonsKilled, int victory, int defeat, int quickWinBonus) {
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

		public static ActualTeamStat parseActualTeamStatJSON(JSONArray json) {
			return new ActualTeamStat(json[0], json[1], json[2], json[3], json[4], json[5], json[6], json[7], json[8], json[9]);
		}

		public static List<ActualTeamStat> parseActualTeamStatsJSON(JSONArray json) {
			List<ActualTeamStat> actualTeamStats = new List<ActualTeamStat>();
			foreach (JSONArray actualTeamStatJSON in json) {
				actualTeamStats.Add(parseActualTeamStatJSON(actualTeamStatJSON));
			}
			
			return actualTeamStats;
		}
	}
}