using System.Collections;
using System.Collections.Generic;
using SimpleJSON;
using UnityEngine;
using UnityEngine.Networking;

// ReSharper disable All

namespace Jhinxz.Jinx.Player {
	public class MostPlayedChampion {
		public int ChampionId { get; set; }
		public int Wins { get; set; }
		public int Losses { get; set; }
		public int Total { get; set; }
		public float KdaRatio { get; set; }

		public MostPlayedChampion(int championId, int wins, int losses, int total, float kdaRatio) {
			ChampionId = championId;
			Wins = wins;
			Losses = losses;
			Total = total;
			KdaRatio = kdaRatio;
		}

		public static MostPlayedChampion parseMostPlayedChampionJSON(JSONNode json) {
			return new MostPlayedChampion(json["championId"], json["wins"], json["losses"], json["total"], json["kdaRatio"]);
		}

		public static List<MostPlayedChampion> parseMostPlayedChampionsJSON(JSONArray json) {
			List<MostPlayedChampion> mostPlayedChampions = new List<MostPlayedChampion>();
			foreach (JSONNode mostPlayedChampionJSON in json) {
				mostPlayedChampions.Add(parseMostPlayedChampionJSON(mostPlayedChampionJSON));
			}
			
			return mostPlayedChampions;
		}
	}
}