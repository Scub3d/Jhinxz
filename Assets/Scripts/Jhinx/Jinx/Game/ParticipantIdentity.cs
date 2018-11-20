// ReSharper disable All
namespace Jhinx.Jinx.Game {
	public class ParticipantIdentity {
		public int ParticipantId { get; set; }
		public Player Player { get; set; }
		
		public ParticipantIdentity(int participantId, Player player) {
			ParticipantId = participantId;
			Player = player;
		}
	}
}