using System.Collections.Generic;
// ReSharper disable All

namespace Jhinxz.Jinx.Game {
	public class Event {
		public long Timestamp { get; set; }
		public int TeamId { get; set; }
		public int ParticipantId { get; set; }
		public int ItemId { get; set; }
		public int SkillSlot { get; set; }
		public int CreatorId { get; set; }
		public string WardType { get; set; }
		public int KillerId { get; set; }
		public int VictimId { get; set; }
		public int XPos { get; set; }
		public int YPos { get; set; }
		public string Type { get; set; }
		public string LevelUpType { get; set; }
		public string AfterId { get; set; }
		public string BeforeId { get; set; }
		public string BuildingType { get; set; }
		public string LaneType { get; set; }
		public string TowerType { get; set; }
		public string MonsterType { get; set; }
		public List<int> AssistingParticipants { get; set; }

		public Event(long timestamp, int teamId, int participantId, int itemId, int skillSlot, int creatorId, string wardType, int killerId, int victimId, int xPos, int yPos, string type, string levelUpType, string afterId, string beforeId, string buildingType, string laneType, string towerType, string monsterType, List<int> assistingParticipants) {
			this.Timestamp = timestamp;
			this.TeamId = teamId;
			this.ParticipantId = participantId;
			this.ItemId = itemId;
			this.SkillSlot = skillSlot;
			this.CreatorId = creatorId;
			this.WardType = wardType;
			this.KillerId = killerId;
			this.VictimId = victimId;
			this.XPos = xPos;
			this.YPos = yPos;
			this.Type = type;
			this.LevelUpType = levelUpType;
			this.AfterId = afterId;
			this.BeforeId = beforeId;
			this.BuildingType = buildingType;
			this.LaneType = laneType;
			this.TowerType = towerType;
			this.MonsterType = monsterType;
			this.AssistingParticipants = assistingParticipants;
		}
	}
}