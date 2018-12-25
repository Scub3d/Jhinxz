using System.Collections;
using System.Collections.Generic;
using Jhinxz.Jinx.Game;
using SimpleJSON;
using UnityEngine;
using UnityEngine.Networking;

// ReSharper disable All

namespace Jhinxz.Zoe.Fantasy {
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
			List<ProTeam> proTeams = ProTeam.parseProTeamsJSON(json["proTeams"].AsArray);
			List<ProPlayer> proPlayers = ProPlayer.parseProPlayersJSON(json["proPlayers"].AsArray);
			List<ProMatch> proMatches = ProMatch.parseProMatchesJSON(json["proMatches"].AsArray);
			Stats stats = Stats.parseStatsJSON(json["stats"]);

			return new Fantasy(json["seasonName"], json["seasonSplit"], json["seasonBegins"], json["seasonEnds"],
				json["numberOfWeeks"], byeWeeks, rosterLocksByWeek, proTeams, proPlayers, proMatches, stats,
				json["rosterTrendsDisabled"]);
		}
		
		public static IEnumerator getFantasyStats(string region, string language, int season) {
			using (UnityWebRequest www = UnityWebRequest.Get("https://fantasy." + region + ".lolesports.com/" + language + "/api/season/" + season)) {
				yield return www.SendWebRequest();
				if (www.isNetworkError || www.isHttpError) {
					Debug.Log(www.error);
					yield return null;
				} else {
					yield return parseFantasyJSON(JSON.Parse(www.downloadHandler.text));                       
				}
			}
		}
	}
}