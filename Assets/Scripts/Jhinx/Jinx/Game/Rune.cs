// ReSharper disable All
namespace Jhinx.Jinx.Game {
	public class Rune {
		public int RuneId { get; set; }
		public int Rank { get; set; }
		
		public Rune(int masteryId, int rank) {
			RuneId = masteryId;
			Rank = rank;
		}
	}
}