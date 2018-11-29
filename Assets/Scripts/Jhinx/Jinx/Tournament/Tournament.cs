using System.Collections.Generic;
using SimpleJSON;

// ReSharper disable All

namespace Jhinx.Jinx.Tournament {	
	public class Tournament {
		public string Id { get; set; }
		public string Title { get; set; }
		public string Description { get; set; }
		public Roles Roles { get; set; }
		public string Queues { get; set; } // Always null??
		public List<Roster> Rosters { get; set; }
		public bool Published { get; set; }	
		public List<Breakpoint> Breakpoints { get; set; }
		public List<Bracket> Brackets { get; set; }
		public List<string> LiveMatches { get; set; }
		public string StartDate { get; set; }
		public string EndDate { get; set; }
		public List<string> PlatformIds { get; set; }
		public string LeagueId { get; set; }
		public List<string> GameIds { get; set; }
		public string League { get; set; }
					
		public Tournament(string id, string title, string description, Roles roles, string queues, List<Roster> rosters, bool published, List<Breakpoint> breakpoints, List<Bracket> brackets, List<string> liveMatches, string startDate, string endDate, List<string> platformIds, string leagueId, List<string> gameIds, string league) {
			Id = id;
			Title = title;
			Description = description;
			Roles = roles;
			Queues = queues;
			Rosters = rosters;
			Published = published;
			Breakpoints = breakpoints;
			Brackets = brackets;
			LiveMatches = liveMatches;
			StartDate = startDate;
			EndDate = endDate;
			PlatformIds = platformIds;
			LeagueId = leagueId;
			GameIds = gameIds;
			League = league;
		}

		public static Tournament parseTournamentJSON(JSONNode json) {
			Roles roles = Roles.parseRolesJSON(json["roles"]);
			List<Roster> rosters = Roster.parseRostersJSON(json["rosters"].AsArray);
			List<Breakpoint> breakpoints = null;//Breakpoint.parseBreakpointsJSON(json["breakpoints"].AsArray);
			List<Bracket> brackets = null;// Bracket.parseBracketsJSON(json["brackets"].AsArray);
			List<string> liveMatches = null;
			List<string> platformIds = Chompers.Chompers.parseStringArrayJSON(json["platformIds"].AsArray);
			List<string> gameIds = Chompers.Chompers.parseStringArrayJSON(json["gameIds"].AsArray);

			return new Tournament(json["id"], json["title"], json["description"], roles, json["queues"], rosters,
				json["published"], breakpoints, brackets, liveMatches, json["startDate"], json["endDate"], platformIds,
				json["leagueId"], gameIds, json["league"]);
		}
	}


	public struct TournamentBracketType {
		public string Indentifier { get; set; }
		//public 
	}

	public struct TournamentMatch {
		public string Id { get; set; }
		public string Name { get; set; }
		public int Position { get; set; }
		public string State { get; set; }
		public int GroupPosition { get; set; }
		//public TournamentGameMode GameMode { get; set; }
		public List<string> Input { get; set; }
		//public List<TournamentMatchGame> Games { get; set; }
		//public TournamentMatchStandings Standings { get; set; }
		//public TournamentMatchScoring Scoring { get; set; }
		//public TournamentMatchScores Scorese { get; set; }
	}




}
