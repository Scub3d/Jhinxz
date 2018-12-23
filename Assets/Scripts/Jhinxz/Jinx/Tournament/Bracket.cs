using System.Collections.Generic;

namespace Jhinxz.Jinx.Tournament {	
	public class Bracket {
		public string Id { get; set; }
		public string Name { get; set; }
		public int Position { get; set; }
		public int GroupPosition { get; set; }
		public string GroupName { get; set; }
		public bool CanManufacture { get; set; }
		public string State { get; set; }
		public BracketType BracketType { get; set; }
		public MatchType MatchType { get; set; }
		//public GameMode GameMode { get; set; }
		public List<string> Input { get; set; }

		public List<Match> Matches { get; set; }
		public List<Standings> Standings { get; set; }
		//public InheritableMatchScoringStrategy InheritableMatchScoringStrategy { get; set; }
		
		public Roles Roles { get; set; }
		//public Scoring Scoring { get; set; }
		public Dictionary<string, int> Scores { get; set; }
		//public MatchScoring MatchScoring { get; set; }
		public Dictionary<string, int> MatchScores { get; set; }

		
		
		
		
	}
}