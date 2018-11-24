using System.Collections.Generic;
using Jhinx.Jinx.Game;
using SimpleJSON;

// ReSharper disable All

namespace Jhinx.Zoe {
	public class Fantasy {
		public string SeasonName { get; set; }
		public string SeasonSplit { get; set; }
		public string SeasonBegins { get; set; }
		public string SeasonEnds { get; set; }
		public int NumberOfWeeks { get; set; }
		public List<int> ByeWeeks { get; set; }
		public List<RosterLockByWeek> RosterLocksByWeek { get; set; }
		public List<ProTeam> ProTeams { get; set; }
		public List<ProPlayer> ProPlayers { get; set; }
		public List<ProMatch> ProMatches { get; set; }
		public Stats Stats { get; set; }
		public bool RosterTrendsDisabled { get; set; }
		
		public Fantasy(string seasonName, string seasonSplit, string seasonBegins, string seasonEnds, int numberOfWeeks, List<int> byeWeeks, List<RosterLockByWeek> rosterLocksByWeek, List<ProTeam> proTeams, List<ProPlayer> proPlayers, List<ProMatch> proMatches, Stats stats, bool rosterTrendsDisabled) {
			SeasonName = seasonName;
			SeasonSplit = seasonSplit;
			SeasonBegins = seasonBegins;
			SeasonEnds = seasonEnds;
			NumberOfWeeks = numberOfWeeks;
			ByeWeeks = byeWeeks;
			RosterLocksByWeek = rosterLocksByWeek;
			ProTeams = proTeams;
			ProPlayers = proPlayers;
			ProMatches = proMatches;
			Stats = stats;
			RosterTrendsDisabled = rosterTrendsDisabled;
		}

		public static Fantasy parseFantasyJSON(JSONNode json) {
			List<int> byeWeeks = Chompers.Chompers.parseIntArrayJSON(json["byeWeeks"].AsArray);
			List<RosterLockByWeek> rosterLocksByWeek = RosterLockByWeek.parseRosterLocksByWeekJSON(json["rosterLocksByWeek"]);
			
			/*Dictionary<string, Dictionary<string, string>> rosterLocksByWeek = new Dictionary<string, Dictionary<string, string>>();
			foreach (string weekKey in json["rosterLocksByWeek"].Keys) {
				Dictionary<string, string> rosterLock = new Dictionary<string, string>();
				foreach (string rosterKey in json["rosterLocksByWeek"][weekKey].Keys) {
					rosterLock.Add(rosterKey, json["rosterLocksByWeek"][weekKey][rosterKey]);
				}
				rosterLocksByWeek.Add(weekKey, rosterLock);
			}*/

			List<ProTeam> proTeams = ProTeam.parseProTeamsJSON(json["proTeams"]);
			List<ProPlayer> proPlayers = ProPlayer.parseProPlayersJSON(json["proPlayers"]);
			List<ProMatch> proMatches = ProMatch.parseProMatchsJSON(json["proMatches"]);
			Stats stats = Stats.parseStatsJSON(json["stats"]);

			return new Fantasy(json["seasonName"], json["seasonSplit"], json["seasonBegins"], json["seasonEnds"],
				json["numberOfWeeks"], byeWeeks, rosterLocksByWeek, proTeams, proPlayers, proMatches, stats,
				json["rosterTrendsDisabled"]);
		}
	}
}