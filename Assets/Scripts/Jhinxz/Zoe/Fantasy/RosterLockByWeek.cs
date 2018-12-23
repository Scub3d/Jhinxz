using System.Collections.Generic;
using SimpleJSON;
// ReSharper disable All

namespace Jhinxz.Zoe.Fantasy {
	public class RosterLockByWeek {
		public string WeekNumber { get; set; }
		public string NALockDate { get; set; }
		public string EULockDate { get; set; }
		
		public RosterLockByWeek(string weekNumber, string naLockDate, string euLockDate) {
			WeekNumber = weekNumber;
			NALockDate = naLockDate;
			EULockDate = euLockDate;
		}

		public static RosterLockByWeek parseRosterLockByWeekJSON(JSONNode json, string weekNumber) {
			return new RosterLockByWeek(weekNumber, json["NA"], json["EU"]);
		}

		public static List<RosterLockByWeek> parseRosterLocksByWeekJSON(JSONNode json) {
			List<RosterLockByWeek> rosterLocksByWeek = new List<RosterLockByWeek>();
			foreach (string weekKey in json.Keys) {
				rosterLocksByWeek.Add(parseRosterLockByWeekJSON(json[weekKey], weekKey));
			}

			return rosterLocksByWeek;
		}
	}
}