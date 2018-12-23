using System.Collections;
using System.Collections.Generic;
using SimpleJSON;
using UnityEngine;
using UnityEngine.Networking;

// ReSharper disable All

namespace Jhinxz.Jinx.Match {
	public class Match {
		public List<Team> Teams { get; set; }
		public List<Player> Players { get; set; }
		public List<ScheduleItem> ScheduleItems { get; set; }
		public List<GameIdMapping> GameIdMappings { get; set; }
		public List<Video> Videos { get; set; }
		public List<HtmlBlock> HtmlBlocks { get; set; }

		public Match(List<Team> teams, List<Player> players, List<ScheduleItem> scheduleItems, List<GameIdMapping> gameIdMappings, List<Video> videos, List<HtmlBlock> htmlBlocks) {
			Teams = teams;
			Players = players;
			ScheduleItems = scheduleItems;
			GameIdMappings = gameIdMappings;
			Videos = videos;
			HtmlBlocks = htmlBlocks;
		}

		public static Match parseMatchJSON(JSONNode json) {
			List<Team> teams = Team.parseTeamsJSON(json["teams"].AsArray);
			List<Player> players = Player.parsePlayersJSON(json["players"].AsArray);
			List<ScheduleItem> scheduleItems = ScheduleItem.parseScheduleItemsJSON(json["scheduleItems"].AsArray);
			List<GameIdMapping> gameIdMappings = GameIdMapping.parseGameIdMappingsJSON(json["gameIdMappings"].AsArray);
			List<Video> videos = Video.parseVideosJSON(json["videos"].AsArray);
			List<HtmlBlock> htmlBlocks = HtmlBlock.parseHtmlBlocksJSON(json["htmlBlocks"].AsArray);
			return new Match(teams, players, scheduleItems, gameIdMappings, videos, htmlBlocks);
		}
		
		public static IEnumerator getMatch(string tournamentId, string matchId) {
			using (UnityWebRequest www = UnityWebRequest.Get("http://api.lolesports.com/api/v2/highlanderMatchDetails?tournamentId=" + tournamentId + "&matchId=" + matchId)) {
				yield return www.Send();
				if (www.isNetworkError || www.isHttpError) {
					Debug.Log(www.error);
					yield return null;
				} else {
					JSONNode matchJSON = JSON.Parse(www.downloadHandler.text);
					yield return parseMatchJSON(matchJSON);
				}
			}
		}
	}
}