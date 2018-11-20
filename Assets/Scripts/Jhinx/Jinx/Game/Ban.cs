// ReSharper disable All
namespace Jhinx.Jinx.Game {
	public class Ban {
		public int ChampionId { get; set; }
		public int PickTurn { get; set; }

		public Ban(int championId, int pickTurn) {
			ChampionId = championId;
			PickTurn = pickTurn;
		}
	}
}