// ReSharper disable All
namespace Jhinx.Jinx.Game {
	public class ParticipantFrame {
		public int ParticipantId { get; set; }
		public int Level { get; set; }
		public int MinionsKilled { get; set; }
		public int JungleMinionsKilled { get; set; }
		public int DominionScore { get; set; }
		public int CurrentGold { get; set; }
		public int TeamScore { get; set; }
		public int TotalGold { get; set; }
		public int Xp { get; set; }
		public int XPos { get; set; }
		public int YPos { get; set; }

		public ParticipantFrame(int participantId, int level, int minionsKilled, int jungleMinionsKilled, int dominionScore, int currentGold, int teamScore, int totalGold, int xp, int xPos, int yPos) {
			this.ParticipantId = participantId;
			this.Level = level;
			this.MinionsKilled = minionsKilled;
			this.JungleMinionsKilled = jungleMinionsKilled;
			this.DominionScore = dominionScore;
			this.CurrentGold = currentGold;
			this.TeamScore = teamScore;
			this.TotalGold = totalGold;
			this.Xp = xp;
			this.XPos = xPos;
			this.YPos = yPos;
		}
	}
}