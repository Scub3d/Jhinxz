using System.Collections.Generic;
using SimpleJSON;
// ReSharper disable All

namespace Jhinx.Zoe.Fantasy {
	public class TrendByWeek {
		public string WeekNumber { get; set; }
		public float OwnedPercentage { get; set; }
		public float StartingPercentage { get; set; }
		public int StartingNumber { get; set; }
		public int TotalAdds { get; set; }
		public int TotalDrops { get; set; }

		public TrendByWeek(string weekNumber, float ownedPercentage, float startingPercentage, int startingNumber, int totalAdds, int totalDrops) {
			WeekNumber = weekNumber;
			OwnedPercentage = ownedPercentage;
			StartingPercentage = startingPercentage;
			StartingNumber = startingNumber;
			TotalAdds = totalAdds;
			TotalDrops = totalDrops;
		}

		public static TrendByWeek parseTrendByWeekJSON(JSONArray json, string weekNumber) {
			return new TrendByWeek(weekNumber, json[0].AsFloat, json[1].AsFloat, json[2].AsInt, json[3].AsInt, json[4].AsInt);
		}
		
		public static List<TrendByWeek> parseTrendsByWeekJSON(JSONNode json) {
			List<TrendByWeek> trendsByWeek = new List<TrendByWeek>();
			foreach (string weekKey in json.Keys) {
				trendsByWeek.Add(parseTrendByWeekJSON(json[weekKey].AsArray, weekKey));
			}

			return trendsByWeek;
		}
	}
}