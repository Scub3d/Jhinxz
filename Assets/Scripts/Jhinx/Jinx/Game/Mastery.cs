// ReSharper disable All
namespace Jhinx.Jinx.Game {
	public class Mastery {
		public int MasteryId { get; set; }
		public int Rank { get; set; }
		
		public Mastery(int masteryId, int rank) {
			MasteryId = masteryId;
			Rank = rank;
		}
	}
}