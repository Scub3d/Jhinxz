using System.Collections.Generic;
using SimpleJSON;

// ReSharper disable All

namespace Jhinxz.Jinx.Player {
	public class StatsSummary {
		public string PlayerId { get; set; }
		public float KdaRatio { get; set; }
		public int KdaRatioRank { get; set; }
		public float CsPerTenMinutes { get; set; }
		public int CsPerTenMinutesRank { get; set; }
		public float KillParticipation { get; set; }
		public int KillParticipationRank { get; set; }
		public List<MostPlayedChampion> MostPlayedChampions { get; set; }
		
		public StatsSummary(string playerId, float kdaRatio, int kdaRatioRank, float csPerTenMinutes, int csPerTenMinutesRank, float killParticipation, int killParticipationRank, List<MostPlayedChampion> mostPlayedChampions) {
			PlayerId = playerId;
			KdaRatio = kdaRatio;
			KdaRatioRank = kdaRatioRank;
			CsPerTenMinutes = csPerTenMinutes;
			CsPerTenMinutesRank = csPerTenMinutesRank;
			KillParticipation = killParticipation;
			KillParticipationRank = killParticipationRank;
			MostPlayedChampions = mostPlayedChampions;
		}

		public static StatsSummary parseStatsSummaryJSON(JSONNode json) {
			List<MostPlayedChampion> mostPlayedChampions = MostPlayedChampion.parseMostPlayedChampionsJSON(json["mostPlayedChampions"].AsArray);
			return new StatsSummary(json["playerId"], json["kdaRatio"], json["kdaRatioRank"], json["csPerTenMinutes"], 
				json["csPerTenMinutesRank"], json["killParticipation"], json["killParticipationRank"], mostPlayedChampions);
		}

		// Don't think this is needed. API calls only seem to return an array of length 1, but still...
		public static List<StatsSummary> parseStatsSummariesJSON(JSONArray json) {
			List<StatsSummary> statsSummaries = new List<StatsSummary>();
			foreach (JSONNode statsSummaryJSON in json) {
				statsSummaries.Add(parseStatsSummaryJSON(statsSummaryJSON));
			}

			return statsSummaries;
		}
	}
}