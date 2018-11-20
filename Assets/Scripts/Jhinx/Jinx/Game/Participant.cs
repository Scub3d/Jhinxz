using System.Collections.Generic;
// ReSharper disable All

namespace Jhinx.Jinx.Game {
	public class Participant {
		public int Id { get; set; }
		public int ChampionId { get; set; }
		public int ParticipantId { get; set; }
		public int Icon { get; set; }
		public int SummonerSpell1 { get; set; }
		public int SummonerSpell2 { get; set; }
		public int TeamId { get; set; }
		
		public string Lane { get; set; }
		public string Role { get; set; }
		public string SummonerName { get; set; }
		public List<Mastery> Masteries { get; set; }
		public List<Rune> Runes { get; set; }
		public Stats ParticipantStats { get; set; }
		public Timeline Timeline { get; set; }

		public Participant(int id, int championId, int participantId, int profileIcon, int summonerSpell1, int summonerSpell2, int teamId, string lane, string role, string summonerName, List<Mastery> masteries, List<Rune> runes, Stats gameParticipantStats, Timeline timeline) {
			Id = id;
			ChampionId = championId;
			ParticipantId = participantId;
			Icon = profileIcon;
			SummonerSpell1 = summonerSpell1;
			SummonerSpell2 = summonerSpell2;
			TeamId = teamId;
			Lane = lane;
			Role = role;
			SummonerName = summonerName;
			Masteries = masteries;
			Runes = runes;
			ParticipantStats = gameParticipantStats;
			Timeline = timeline;
		}
	}
}