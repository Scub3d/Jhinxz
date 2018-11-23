using System.Collections.Generic;
using SimpleJSON;

// ReSharper disable All

namespace Jhinx.Jinx.Game {
	public class Participant {
		public int ParticipantId { get; set; }
		public int TeamId { get; set; }
		public int ChampionId { get; set; }
		public int SummonerSpell1 { get; set; }
		public int SummonerSpell2 { get; set; }
		public List<Mastery> Masteries { get; set; }
		public List<Rune> Runes { get; set; }
		public string HighestAchievedSeasonTier { get; set; }		
		public Stats ParticipantStats { get; set; }
		public Timeline Timeline { get; set; }

		public Participant(int participantId, int teamId, int championId, int summonerSpell1, int summonerSpell2, List<Mastery> masteries, List<Rune> runes, string highestAchievedSeasonTier, Stats participantStats, Timeline timeline) {
			ParticipantId = participantId;
			TeamId = teamId;
			ChampionId = championId;
			SummonerSpell1 = summonerSpell1;
			SummonerSpell2 = summonerSpell2;
			Masteries = masteries;
			Runes = runes;
			HighestAchievedSeasonTier = highestAchievedSeasonTier;
			ParticipantStats = participantStats;
			Timeline = timeline;
		}

		public static Participant parseParticipantJSON(JSONNode json) {
			List<Mastery> masteries = Mastery.parseMasteriesJSON(json["masteries"]);
			List<Rune> runes = Rune.parseRunesJSON(json["runes"]);
			Stats stats = Stats.parseStatsJSON(json["stats"]);
			Timeline timeline = Timeline.parseTimelineJSON(json["timeline"]);
			return new Participant(json["participantId"], json["teamId"], json["championId"], json["spell1Id"], json["spell2Id"], 
				masteries, runes, json["highestAchievedSeasonTier"], stats, timeline);
		}

		public static List<Participant> parseParticipantsJSON(JSONNode json) {
			List<Participant> participants = new List<Participant>();
			foreach (JSONNode participantJSON in json) {
				participants.Add(parseParticipantJSON(participantJSON));
			}

			return participants;
		}
	}
}