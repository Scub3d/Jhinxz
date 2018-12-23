// ReSharper disable All

using System.Collections.Generic;

namespace Jhinxz.Jinx.Tournament {	
	public class Match {
		public string Id { get; set; }
		public string Name { get; set; }
		public int Position { get; set; }
		public string State { get; set; }
		public int GroupPosition { get; set; }
		public MatchType MatchType { get; set; }
		public Input Input { get; set; }
		public List<Game> Games { get; set; }
		public Standings Standings { get; set; } // different
		
		public bool TieBreaker { get; set; }
		public string RemadeGames { get; set; } // Empty
		public Roles Roles { get; set; }
		//public Scoring Scoring { get; set; }
		public Dictionary<string, int> Scores { get; set; }
		
		
		
		
	}
}