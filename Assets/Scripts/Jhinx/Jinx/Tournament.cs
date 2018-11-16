using System.Collections.Generic;

namespace Jhinx {
	namespace Jinx {
		
		public class Tournament {
			public string Id { get; set; }
			public string Title { get; set; }
			public string Description { get; set; }
			public string StartDate { get; set; }
			public string EndDate { get; set; }
			public int LeagueId { get; set; }
			public bool Published { get; set; }
			public List<TournamentRoster> Rosters { get; set; }
			public List<TournamentBreakpoint> Breakpoints { get; set; }
			public List<TournamentBracket> Brackets { get; set; }
			public List<string> PlatformIds { get; set; }
			public List<string> GameIds { get; set; }
						
		}
	
		public struct TournamentRoster {
			public string Id { get; set; }
			public string Name { get; set; }
			public string TeamId { get; set; }
			public string PlayerId { get; set; }
	
		}
	
		public struct TournamentBreakpoint {
			public string Id { get; set; }
			public string Name { get; set; }
			public int Position { get; set; }
			public List<TournamentBreakpointInput> Inputs { get; set; }
			public TournamentBreakpointStanding Standings { get; set; }	
		}
	
		public struct TournamentBreakpointInput {
			public string Roster { get; set; }
			public string Bracket { get; set; }
			public int Standing { get; set; }
		}
		
		public struct TournamentBreakpointStanding {
			public List<TournamentBreakpointStandingResult> Results { get; set; }
			public long Timestamp { get; set; }
		}
	
		public struct TournamentBreakpointStandingResult {
			public string Roster { get; set; }
			public string Bracket { get; set; }
			public int Standing { get; set; }
		}	
		
		public struct TournamentBracket {
			public string Id { get; set; }
			public string Name { get; set; }
			public int Position { get; set; }
			public int GroupPosition { get; set; }
			public string GroupName { get; set; }
			public string State { get; set; }
			
			public TournamentBracketType BracketType { get; set; }
			//public TournamentMatchType MatchType { get; set; }
			//public TournamentGameMode GameMode { get; set; }
			
			public List<string> Input { get; set; }
	
			public List<TournamentMatch> Matches { get; set; }
			//public List<TournamentBracketStandings> Standings { get; set; }
	
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
}