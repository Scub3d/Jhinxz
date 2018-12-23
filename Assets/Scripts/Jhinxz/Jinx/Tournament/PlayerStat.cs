// ReSharper disable All

using System.Collections;
using System.Collections.Generic;
using SimpleJSON;
using UnityEngine;
using UnityEngine.Networking;

namespace Jhinxz.Jinx {
	public class PlayerStat {
		public int Id { get; set; }
		public string Name { get; set; }
		public string Position { get; set; }
		public string PlayerSlug { get; set; }
		public string Team { get; set; }
		public int GamesPlayed { get; set; }
		public float Kda { get; set; }
		public int Kills { get; set; }
		public int Deaths { get; set; }
		public int Assists { get; set; }
		public float KillParticipation { get; set; }
		public float CsPerMin { get; set; }
		public int Cs { get; set; }
		public int MinutesPlayed { get; set; }
		public string TeamSlug { get; set; }

		public PlayerStat(int id, string name, string position, string playerSlug, string team, int gamesPlayed, float kda, int kills, int deaths, int assists, float killParticipation, float csPerMin, int cs, int minutesPlayed, string teamSlug) {
			Id = id;
			Name = name;
			Position = position;
			PlayerSlug = playerSlug;
			Team = team;
			GamesPlayed = gamesPlayed;
			Kda = kda;
			Kills = kills;
			Deaths = deaths;
			Assists = assists;
			KillParticipation = killParticipation;
			CsPerMin = csPerMin;
			Cs = cs;
			MinutesPlayed = minutesPlayed;
			TeamSlug = teamSlug;
		}

		public static PlayerStat parsePlayerStatJSON(JSONNode json) {
			return new PlayerStat(json["id"], json["name"], json["position"], json["playerSlug"], json["team"], json["gamesPlayed"], 
				json["kda"], json["kills"], json["deaths"], json["assists"], json["killParticipation"], json["csPerMin"], 
				json["cs"], json["minutesPlayed"], json["teamSlug"]);
		}

		public static List<PlayerStat> parsePlayerStatsJSON(JSONArray json) {
			List<PlayerStat> playerStats = new List<PlayerStat>();
			foreach (JSONNode playerStatJOSN in json) {
				playerStats.Add(parsePlayerStatJSON(playerStatJOSN));
			}
			
			return playerStats;
		}

		public static IEnumerator getRunes(string tournamentId) {
			using (UnityWebRequest www = UnityWebRequest.Get("https://api.lolesports.com/api/v2/tournamentPlayerStats?tournamentId=" + tournamentId)) {
				yield return www.Send();
				if (www.isNetworkError || www.isHttpError) {
					Debug.Log(www.error);
					yield return null;
				} else {
					JSONNode playerStatsJSON = JSON.Parse(www.downloadHandler.text)["data"];
					List<PlayerStat> playerStats = parsePlayerStatsJSON(playerStatsJSON.AsArray);
					yield return playerStats;
				}
			}
		}
	}
}