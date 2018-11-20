// ReSharper disable All
namespace Jhinx.Jinx.Player {
	public class StatsHistory {
		public string Id { get; set; }
		public string PlayerId { get; set; }
		public int ChampionId { get; set; }
		public long Timestamp { get; set; }
		public int Assists { get; set; }
		public int Deaths { get; set; }
		public int Kills { get; set; }
		public float CsPerTenMin { get; set; }
		public float KdaRatio { get; set; }
		public float KillParticipation { get; set; }
		public bool Win { get; set; }
		public string Match { get; set; }
		public int Team { get; set; }
		public int Opponent { get; set; }
		public string Game { get; set; }
		
		public StatsHistory(string id, string playerId, int championId, long timestamp, int assists, int deaths, int kills, float csPerTenMin, int kdaRatio, int killParticipation, bool win, string match, int team, int opponent, string game) {
			Id = id;
			PlayerId = playerId;
			ChampionId = championId;
			Timestamp = timestamp;
			Assists = assists;
			Deaths = deaths;
			Kills = kills;
			CsPerTenMin = csPerTenMin;
			KdaRatio = kdaRatio;
			KillParticipation = killParticipation;
			Win = win;
			Match = match;
			Team = team;
			Opponent = opponent;
			Game = game;
		}
	}
}