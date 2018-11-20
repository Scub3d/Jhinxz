using System.Collections.Generic;

namespace Jhinx {
	namespace Jinx {
		public class Match {
			public string Id { get; }
			public string Name { get; }
			public string TournamentId { get; }
			public List<Video> Videos { get; }
			public List<MatchTeam> Teams { get; }
			public List<MatchGame> Games { get; }

			public Match(string id, string name, string tournamentId, List<Video> videos, List<MatchTeam> teams,
				List<MatchGame> games) {
				this.Id = id;
				this.Name = name;
				this.TournamentId = tournamentId;
				this.Videos = videos;
				this.Teams = teams;
				this.Games = games;
			}
		}

		public struct MatchTeam {
			public int Id { get; }
			public string Name { get; }
			public List<MatchTeamPlayer> Starters { get; }
			public List<MatchTeamPlayer> Subs { get; }

			public MatchTeam(int id, string name, List<MatchTeamPlayer> starters, List<MatchTeamPlayer> subs) {
				this.Id = id;
				this.Name = name;
				this.Starters = starters;
				this.Subs = subs;
			}
		}

		public struct MatchTeamPlayer {
			public int Id { get; }
			public string Name { get; }
			public string Role { get; }

			public MatchTeamPlayer(int id, string name, string role) {
				this.Id = id;
				this.Name = name;
				this.Role = role;
			}
		}

		public struct MatchGame {
			public string Id { get; }
			public string Name { get; }
			public string GeneratedName { get; }

			public MatchGame(string id, string name, string generatedName) {
				this.Id = id;
				this.Name = name;
				this.GeneratedName = generatedName;
			}
		}
	}
}