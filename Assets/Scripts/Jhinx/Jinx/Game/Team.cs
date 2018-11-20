using System.Collections.Generic;
// ReSharper disable All

namespace Jhinx.Jinx.Game {
	public class Team {
		public string Side { get; set; }
		public string Type { get; set; }
		public bool Win { get; set; }
		public bool FirstTower { get; set; }
		public bool FirstDragon { get; set; }
		public bool FirstBarron { get; set; }
		public bool FirstBlood { get; set; }
		public bool FirstRiftHerald { get; set; }
		public bool FirstInhibitor { get; set; }

		public int Id { get; set; }
		public int BaronKills { get; set; }
		public int DominionVictoryScore { get; set; }
		public int DragonKills { get; set; }
		public int InhibitorKills { get; set; }
		public int RiftHeraldKills { get; set; }
		public int TowerKills { get; set; }
		public int VilemawKills { get; set; }

		public List<Ban> Bans { get; set; }

		public Team(string side, string type, bool win, bool firstTower, bool firstDragon, bool firstBarron, bool firstBlood, bool firstRiftHerald, bool firstInhibitor, int id, int baronKills, int dominionVictoryScore, int dragonKills, int inhibitorKills, int riftHeraldKills, int towerKills, int vilemawKills, List<Ban> bans) {
			Side = side;
			Type = type;
			Win = win;
			FirstTower = firstTower;
			FirstDragon = firstDragon;
			FirstBarron = firstBarron;
			FirstBlood = firstBlood;
			FirstRiftHerald = firstRiftHerald;
			FirstInhibitor = firstInhibitor;
			Id = id;
			BaronKills = baronKills;
			DominionVictoryScore = dominionVictoryScore;
			DragonKills = dragonKills;
			InhibitorKills = inhibitorKills;
			RiftHeraldKills = riftHeraldKills;
			TowerKills = towerKills;
			VilemawKills = vilemawKills;
			Bans = bans;
		}
	}
}