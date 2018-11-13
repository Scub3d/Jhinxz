using System.Collections.Generic;

namespace APIv2 {
	public class Player {
		public int Id { get; }
		public string FirstName { get; }
		public string LastName { get; }
		public string Name { get; }
		public string PhotoUrl { get; }
		private string role, slug, region;
		public List<PlayerTournamentStats> TournamentStats { get; }
		public List<PlayerTeam> Teams { get; }

		public Player(int id, string firstName, string lastName, string name, string photoUrl, string role, string slug, string region, List<PlayerTournamentStats> tournamentStats, List<PlayerTeam> teams) {
			this.Id = id;
			this.FirstName = firstName;
			this.LastName = lastName;
			this.Name = name;
			PhotoUrl = photoUrl;
			this.role = role;
			this.slug = slug;
			this.region = region;
			this.TournamentStats = tournamentStats;
			this.Teams = teams;
		}
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