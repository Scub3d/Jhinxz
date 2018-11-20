using System.Collections.Generic;
// ReSharper disable All

namespace Jhinx.Jinx.Game {
	public class GameStats {
		public string Id { get; set; }
		public string Name { get; set; }
		public string Patch { get; set; }
		public string MatchId { get; set; }
		public int SeasonId { get; set; }
		public int GameDuration { get; set; }
		public int MapId { get; set; }
		public long GameCreation { get; set; }
		public List<Team> Teams { get; set; }
		public List<Participant> Participants { get; set; }
		public List<ParticipantIdentity> ParticipantIdentitieses { get; set; }

		public GameStats(string id, string name, string patch, string matchId, int seasonId, int gameDuration, int mapId, long gameCreation, List<Team> teams, List<Participant> participants, List<ParticipantIdentity> participantIdentitieses) {
			Id = id;
			Name = name;
			Patch = patch;
			MatchId = matchId;
			SeasonId = seasonId;
			GameDuration = gameDuration;
			MapId = mapId;
			GameCreation = gameCreation;
			Teams = teams;
			Participants = participants;
			ParticipantIdentitieses = participantIdentitieses;
		}
	}
}