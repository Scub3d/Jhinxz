// ReSharper disable All
namespace Jhinx.Jhin.Champion {
	public class Info {
		public int Attack { get; set; }
		public int Defense { get; set; }
		public int Magic { get; set; }
		public int Difficulty { get; set; }

		public Info(int attack, int defense, int magic, int difficulty) {
			Attack = attack;
			Defense = defense;
			Magic = magic;
			Difficulty = difficulty;
		}
	}
}