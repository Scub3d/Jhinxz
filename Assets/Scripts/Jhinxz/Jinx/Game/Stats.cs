// ReSharper disable All

using SimpleJSON;

namespace Jhinxz.Jinx.Game {
	public class Stats {
		public int ParticipantId { get; set; }
		public bool Win { get; set; }
		public int Item0 { get; set; }
		public int Item1 { get; set; }
		public int Item2 { get; set; }
		public int Item3 { get; set; }
		public int Item4 { get; set; }
		public int Item5 { get; set; }
		public int Item6 { get; set; }
		public int Kills { get; set; }
		public int Deaths { get; set; }
		public int Assists { get; set; }
		public int LargestKillingSpree { get; set; }
		public int LargestMultiKill { get; set; }
		public int KillingSprees { get; set; }
		public int LongestTimeSpentLiving { get; set; }
		public int DoubleKills { get; set; }
		public int TripleKills { get; set; }
		public int QuadraKills { get; set; }
		public int PentaKills { get; set; }
		public int UnrealKills { get; set; }
		public int TotalDamageDealt { get; set; }
		public int MagicDamageDealt { get; set; }
		public int PhysicalDamageDealt { get; set; }
		public int TrueDamageDealt { get; set; }
		public int LargestCriticalStrike { get; set; }
		public int TotalDamageDealtToChampions { get; set; }
		public int MagicDamageDealtToChampions { get; set; }
		public int PhysicalDamageDealtToChampions { get; set; }
		public int TrueDamageDealtToChampions { get; set; }
		public int TotalHeal { get; set; }
		public int TotalUnitsHealed { get; set; }
		public int DamageSelfMitigated { get; set; }
		public int DamageDealtToObjectives { get; set; }
		public int DamageDealtToTurrets { get; set; }
		public int VisionScore { get; set; }
		public int TimeCCingOthers { get; set; }
		public int TotalDamageTaken { get; set; }
		public int MagicalDamageTaken { get; set; }
		public int PhysicalDamageTaken { get; set; }
		public int TrueDamageTaken { get; set; }
		public int GoldEarned { get; set; }
		public int GoldSpent { get; set; }
		public int TurretKills { get; set; }
		public int InhibitorKills { get; set; }
		public int TotalMinionsKilled { get; set; }
		public int NeutralMinionsKilled { get; set; }
		public int NeutralMinionsKilledTeamJungle { get; set; }
		public int NeutralMinionsKilledEnemyJungle { get; set; }
		public int TotalTimeCrowdControlDealt { get; set; }
		public int ChampLevel { get; set; }
		public int VisionWardsBoughtInGame { get; set; }
		public int SightWardsBoughtInGame { get; set; }
		public int WardsPlaced { get; set; }
		public int WardsKilled { get; set; }
		public bool FirstBloodKill { get; set; }
		public bool FirstBloodAssist { get; set; }
		public bool FirstTowerKill { get; set; }
		public bool FirstTowerAssist { get; set; }
		public bool FirstInhibitorKill { get; set; }
		public bool FirstInhibitorAssist { get; set; }
		public int CombatPlayerScore { get; set; }
		public int ObjectivePlayerScore { get; set; }
		public int TotalPlayerScore { get; set; }
		public int TotalScoreRank { get; set; }
		public int PlayerScore0 { get; set; }
		public int PlayerScore1 { get; set; }
		public int PlayerScore2 { get; set; }
		public int PlayerScore3 { get; set; }
		public int PlayerScore4 { get; set; }
		public int PlayerScore5 { get; set; }
		public int PlayerScore6 { get; set; }
		public int PlayerScore7 { get; set; }
		public int PlayerScore8 { get; set; }
		public int PlayerScore9 { get; set; }
		public int Perk0 { get; set; }
		public int Perk0Var1 { get; set; }
		public int Perk0Var2 { get; set; }
		public int Perk0Var3 { get; set; }
		public int Perk1 { get; set; }
		public int Perk1Var1 { get; set; }
		public int Perk1Var2 { get; set; }
		public int Perk1Var3 { get; set; }
		public int Perk2 { get; set; }
		public int Perk2Var1 { get; set; }
		public int Perk2Var2 { get; set; }
		public int Perk2Var3 { get; set; }
		public int Perk3 { get; set; }
		public int Perk3Var1 { get; set; }
		public int Perk3Var2 { get; set; }
		public int Perk3Var3 { get; set; }
		public int Perk4 { get; set; }
		public int Perk4Var1 { get; set; }
		public int Perk4Var2 { get; set; }
		public int Perk4Var3 { get; set; }
		public int Perk5 { get; set; }
		public int Perk5Var1 { get; set; }
		public int Perk5Var2 { get; set; }
		public int Perk5Var3 { get; set; }
		public int PerkPrimaryStyle { get; set; }
		public int PerkSubStyle { get; set; }
		
		public Stats(int participantId, bool win, int item0, int item1, int item2, int item3, int item4, int item5, int item6, int kills, int deaths, int assists, int largestKillingSpree, int largestMultiKill, int killingSprees, int longestTimeSpentLiving, int doubleKills, int tripleKills, int quadraKills, int pentaKills, int unrealKills, int totalDamageDealt, int magicDamageDealt, int physicalDamageDealt, int trueDamageDealt, int largestCriticalStrike, int totalDamageDealtToChampions, int magicDamageDealtToChampions, int physicalDamageDealtToChampions, int trueDamageDealtToChampions, int totalHeal, int totalUnitsHealed, int damageSelfMitigated, int damageDealtToObjectives, int damageDealtToTurrets, int visionScore, int timeCCingOthers, int totalDamageTaken, int magicalDamageTaken, int physicalDamageTaken, int trueDamageTaken, int goldEarned, int goldSpent, int turretKills, int inhibitorKills, int totalMinionsKilled, int neutralMinionsKilled, int neutralMinionsKilledTeamJungle, int neutralMinionsKilledEnemyJungle, int totalTimeCrowdControlDealt, int champLevel, int visionWardsBoughtInGame, int sightWardsBoughtInGame, int wardsPlaced, int wardsKilled, bool firstBloodKill, bool firstBloodAssist, bool firstTowerKill, bool firstTowerAssist, bool firstInhibitorKill, bool firstInhibitorAssist, int combatPlayerScore, int objectivePlayerScore, int totalPlayerScore, int totalScoreRank, int playerScore0, int playerScore1, int playerScore2, int playerScore3, int playerScore4, int playerScore5, int playerScore6, int playerScore7, int playerScore8, int playerScore9, int perk0, int perk0Var1, int perk0Var2, int perk0Var3, int perk1, int perk1Var1, int perk1Var2, int perk1Var3, int perk2, int perk2Var1, int perk2Var2, int perk2Var3, int perk3, int perk3Var1, int perk3Var2, int perk3Var3, int perk4, int perk4Var1, int perk4Var2, int perk4Var3, int perk5, int perk5Var1, int perk5Var2, int perk5Var3, int perkPrimaryStyle, int perkSubStyle) {
			ParticipantId = participantId;
			Win = win;
			Item0 = item0;
			Item1 = item1;
			Item2 = item2;
			Item3 = item3;
			Item4 = item4;
			Item5 = item5;
			Item6 = item6;
			Kills = kills;
			Deaths = deaths;
			Assists = assists;
			LargestKillingSpree = largestKillingSpree;
			LargestMultiKill = largestMultiKill;
			KillingSprees = killingSprees;
			LongestTimeSpentLiving = longestTimeSpentLiving;
			DoubleKills = doubleKills;
			TripleKills = tripleKills;
			QuadraKills = quadraKills;
			PentaKills = pentaKills;
			UnrealKills = unrealKills;
			TotalDamageDealt = totalDamageDealt;
			MagicDamageDealt = magicDamageDealt;
			PhysicalDamageDealt = physicalDamageDealt;
			TrueDamageDealt = trueDamageDealt;
			LargestCriticalStrike = largestCriticalStrike;
			TotalDamageDealtToChampions = totalDamageDealtToChampions;
			MagicDamageDealtToChampions = magicDamageDealtToChampions;
			PhysicalDamageDealtToChampions = physicalDamageDealtToChampions;
			TrueDamageDealtToChampions = trueDamageDealtToChampions;
			TotalHeal = totalHeal;
			TotalUnitsHealed = totalUnitsHealed;
			DamageSelfMitigated = damageSelfMitigated;
			DamageDealtToObjectives = damageDealtToObjectives;
			DamageDealtToTurrets = damageDealtToTurrets;
			VisionScore = visionScore;
			TimeCCingOthers = timeCCingOthers;
			TotalDamageTaken = totalDamageTaken;
			MagicalDamageTaken = magicalDamageTaken;
			PhysicalDamageTaken = physicalDamageTaken;
			TrueDamageTaken = trueDamageTaken;
			GoldEarned = goldEarned;
			GoldSpent = goldSpent;
			TurretKills = turretKills;
			InhibitorKills = inhibitorKills;
			TotalMinionsKilled = totalMinionsKilled;
			NeutralMinionsKilled = neutralMinionsKilled;
			NeutralMinionsKilledTeamJungle = neutralMinionsKilledTeamJungle;
			NeutralMinionsKilledEnemyJungle = neutralMinionsKilledEnemyJungle;
			TotalTimeCrowdControlDealt = totalTimeCrowdControlDealt;
			ChampLevel = champLevel;
			VisionWardsBoughtInGame = visionWardsBoughtInGame;
			SightWardsBoughtInGame = sightWardsBoughtInGame;
			WardsPlaced = wardsPlaced;
			WardsKilled = wardsKilled;
			FirstBloodKill = firstBloodKill;
			FirstBloodAssist = firstBloodAssist;
			FirstTowerKill = firstTowerKill;
			FirstTowerAssist = firstTowerAssist;
			FirstInhibitorKill = firstInhibitorKill;
			FirstInhibitorAssist = firstInhibitorAssist;
			CombatPlayerScore = combatPlayerScore;
			ObjectivePlayerScore = objectivePlayerScore;
			TotalPlayerScore = totalPlayerScore;
			TotalScoreRank = totalScoreRank;
			PlayerScore0 = playerScore0;
			PlayerScore1 = playerScore1;
			PlayerScore2 = playerScore2;
			PlayerScore3 = playerScore3;
			PlayerScore4 = playerScore4;
			PlayerScore5 = playerScore5;
			PlayerScore6 = playerScore6;
			PlayerScore7 = playerScore7;
			PlayerScore8 = playerScore8;
			PlayerScore9 = playerScore9;
			Perk0 = perk0;
			Perk0Var1 = perk0Var1;
			Perk0Var2 = perk0Var2;
			Perk0Var3 = perk0Var3;
			Perk1 = perk1;
			Perk1Var1 = perk1Var1;
			Perk1Var2 = perk1Var2;
			Perk1Var3 = perk1Var3;
			Perk2 = perk2;
			Perk2Var1 = perk2Var1;
			Perk2Var2 = perk2Var2;
			Perk2Var3 = perk2Var3;
			Perk3 = perk3;
			Perk3Var1 = perk3Var1;
			Perk3Var2 = perk3Var2;
			Perk3Var3 = perk3Var3;
			Perk4 = perk4;
			Perk4Var1 = perk4Var1;
			Perk4Var2 = perk4Var2;
			Perk4Var3 = perk4Var3;
			Perk5 = perk5;
			Perk5Var1 = perk5Var1;
			Perk5Var2 = perk5Var2;
			Perk5Var3 = perk5Var3;
			PerkPrimaryStyle = perkPrimaryStyle;
			PerkSubStyle = perkSubStyle;
		}

		public static Stats parseStatsJSON(JSONNode json) {
			return new Stats(json["participantId"], json["win"], json["item0"], json["item1"], json["item2"],
				json["item3"], json["item4"], json["item5"], json["item6"], json["kills"], json["deaths"],
				json["assists"], json["largestKillingSpree"], json["largestMultiKill"], json["killingSprees"],
				json["longestTimeSpentLiving"], json["doubleKills"], json["tripleKills"], json["quadraKills"],
				json["pentaKills"], json["unrealKills"], json["totalDamageDealt"], json["magicDamageDealt"],
				json["physicalDamageDealt"], json["trueDamageDealt"], json["largestCriticalStrike"],
				json["totalDamageDealtToChampions"], json["magicDamageDealtToChampions"],
				json["physicalDamageDealtToChampions"], json["trueDamageDealtToChampions"], json["totalHeal"],
				json["totalUnitsHealed"], json["damageSelfMitigated"], json["damageDealtToObjectives"],
				json["damageDealtToTurrets"], json["visionScore"], json["timeCCingOthers"], json["totalDamageTaken"],
				json["magicalDamageTaken"], json["physicalDamageTaken"], json["trueDamageTaken"], json["goldEarned"],
				json["goldSpent"], json["turretKills"], json["inhibitorKills"], json["totalMinionsKilled"],
				json["neutralMinionsKilled"], json["neutralMinionsKilledTeamJungle"],
				json["neutralMinionsKilledEnemyJungle"], json["totalTimeCrowdControlDealt"], json["champLevel"],
				json["visionWardsBoughtInGame"], json["sightWardsBoughtInGame"], json["wardsPlaced"],
				json["wardsKilled"], json["firstBloodKill"], json["firstBloodAssist"], json["firstTowerKill"],
				json["firstTowerAssist"], json["firstInhibitorKill"], json["firstInhibitorAssist"],
				json["combatPlayerScore"], json["objectivePlayerScore"], json["totalPlayerScore"],
				json["totalScoreRank"], json["playerScore0"], json["playerScore1"], json["playerScore2"],
				json["playerScore3"], json["playerScore4"], json["playerScore5"], json["playerScore6"],
				json["playerScore7"], json["playerScore8"], json["playerScore9"], json["perk0"], json["perk0Var1"],
				json["perk0Var2"], json["perk0Var3"], json["perk1"], json["perk1Var1"], json["perk1Var2"],
				json["perk1Var3"], json["perk2"], json["perk2Var1"], json["perk2Var2"], json["perk2Var3"],
				json["perk3"], json["perk3Var1"], json["perk3Var2"], json["perk3Var3"], json["perk4"],
				json["perk4Var1"], json["perk4Var2"], json["perk4Var3"], json["perk5"], json["perk5Var1"],
				json["perk5Var2"], json["perk5Var3"], json["perkPrimaryStyle"], json["perkSubStyle"]);
		}
	}
}