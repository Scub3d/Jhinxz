using System.Collections.Generic;

namespace Jhinx {
    public class Tournament {
	    public string Id { get; set; }
	    public string Title { get; set; }
	    public string Description { get; set; }
	    public string StartDate { get; set; }
	    public string EndDate { get; set; }
	    public int LeagueId { get; set; }
	    public bool Published { get; set; }
        private List<Roster> Rosters { get; set; }
        private List<Breakpoint> Breakpoints { get; set; }
        private List<Bracket> Brackets { get; set; }
        private List<string> PlatformIds { get; set; }
	    private List<string> GameIds { get; set; }
        
	}

	public struct Roster {
		public string Id { get; set; }
		public string Name { get; set; }
		public string TeamId { get; set; }
		public string PlayerId { get; set; }

	}

	public struct Breakpoint {
		public string Id { get; set; }
		public string Name { get; set; }
		public int Position { get; set; }
		public List<BreakpointInput> Inputs { get; set; }
		public BreakpointStanding Standings { get; set; }
		

	}

	public struct BreakpointInput {
		public string Roster { get; set; }
		public string Bracket { get; set; }
		public int Standing { get; set; }
	}
	
	public struct BreakpointStanding {
		public List<BreakpointStandingResult> Results { get; set; }
		public long Timestamp { get; set; }
	}

	public struct BreakpointStandingResult {
		public string Roster { get; set; }
		public string Bracket { get; set; }
		public int Standing { get; set; }
	}

	
    
	
    public struct Bracket {
        public string Id { get; set; }
        public string Name { get; set; }
	    public int Position { get; set; }
	    public int GroupPosition { get; set; }
	    public string GroupName { get; set; }
	    public string State { get; set; }
        
        public BracketType BracketType { get; set; }
	    public MatchType MatchType { get; set; }
	    public GameMode GameMode { get; set; }
	    
	    public List<string> Input { get; set; }

        public List<TournamentMatch> Matches { get; set; }
	    public List<BracketStandings> Standings { get; set; }

    }

	public struct TournamentMatch {
		public string Id { get; set; }
		public string Name { get; set; }
		public int Position { get; set; }
		public string State { get; set; }
		public int GroupPosition { get; set; }
		public GameMode GameMode { get; set; }
		public List<string> Input { get; set; }
		public List<TournamentMatchGame> Games { get; set; }
		public MatchStandings Standings { get; set; }
		public MatchScoring Scoring { get; set; }
		public MatchScores Scorese { get; set; }
	}

	
	
	
	
}