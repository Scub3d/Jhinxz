using System.Collections.Generic;
// ReSharper disable All

namespace Jhinx.Jinx.Player {
	public class Player {
		public int Id { get; set; }
		public string Slug { get; set; }
		public string Name { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string RoleSlug { get; set; }
		public string PhotoUrl { get; set; }
		public string Hometown { get; set; }
		public string Region { get; set; }
		public string Birthdate { get; set; }
		public string CreatedAt { get; set; }
		public string UpdatedAt { get; set; }
		public Dictionary<string, string> Bios { get; set; }
		public Dictionary<string, string> ForeignIds { get; set; }
		// public .... SocialNetworks { get; set; }
		// public List<> Champions { get; set; }
		public List<int> StarterOnTeams { get; set; }
		public List<int> SubOnTeams { get; set; }
		public List<int> Teams { get; set; }
		
		public PhotoInformation PhotoInformation { get; set; }
		// public List<> ScheduleItems { get; set; }
		public string PlayerStatsSummary { get; set; }
		public List<string> PlayerStatsHistory { get; set; }
		
		// Bonus Checkmark // TODO: Fix this cluster cuss
		public List<Tournament> Tournaments { get; set; }
		public List<ScheduleItem> ScheduleItems { get; set; }
		public List<Team> _Teams { get; set; }
		public List<StatsSummary> PlayerStatsSummaries { get; set; }
		public List<StatsHistory> PlayerStatsHistories { get; set; }


	}
	
	public struct PlayerTournamentStats {
		private int assists, cs, deaths, gamesPlayed, kills, minutesPlayed, kdaRatioRank, killParticipationRank;
		private float csPerMinute, csPerTenMinutes, kdaRatio, killparticipation;
		private string tournamentId, position, name, playerSlug, team, teamSlug;
		private List<PlayerTournamentStatsMostPlayedChampion> mostPlayedChampions;
	}
	
	public struct PlayerTeam {
		private int id;
		private string acronym, name;
	}
	
	public struct PlayerTournamentStatsMostPlayedChampion {
		private int championId, losses, total, wins;
		private float kdaRatio;
	}
}