using System.Collections.Generic;
// ReSharper disable All

namespace Jhinx.Jinx {
	public class Game {
		public string Id { get; }
		public string Name { get; }
		public string Patch { get; }
		public string MatchId { get; }
		public int SeasonId { get; }
		public int GameDuration { get; }
		public int MapId { get; }
		public int FrameInterval { get; }
		public long GameCreation { get; }

		public List<GameTeam> Teams { get; }
		public List<GameParticipant> Participants { get; }

		public List<GameTimelineFrame> Frames { get; }

		public Game(string id, string name, string patch, string matchId, int seasonId, int gameDuration, int mapId, int frameInterval, long gameCreation, List<GameTeam> teams, List<GameParticipant> participants, List<GameTimelineFrame> frames) {
			this.Id = id;
			this.Name = name;
			this.Patch = patch;
			this.MatchId = matchId;
			this.SeasonId = seasonId;
			this.GameDuration = gameDuration;
			this.MapId = mapId;
			this.FrameInterval = frameInterval;
			this.GameCreation = gameCreation;
			this.Teams = teams;
			this.Participants = participants;
			this.Frames = frames;
		}
	}

	public struct GameTeam {
		public string Side { get; }
		public string Type { get; }
		public bool Win { get; }
		public bool FirstTower { get; }
		public bool FirstDragon { get; }
		public bool FirstBarron { get; }
		public bool FirstBlood { get; }
		public bool FirstRiftHerald { get; }
		public bool FirstInhibitor { get; }

		public int Id { get; }
		public int BaronKills { get; }
		public int DominionVictoryScore { get; }
		public int DragonKills { get; }
		public int InhibitorKills { get; }
		public int RiftHeraldKills { get; }
		public int TowerKills { get; }
		public int VilemawKills { get; }

		public List<GameTeamBan> Bans { get; }

		public GameTeam(string side, string type, bool win, bool firstTower, bool firstDragon, bool firstBarron, bool firstBlood, bool firstRiftHerald, bool firstInhibitor, int id, int baronKills, int dominionVictoryScore, int dragonKills, int inhibitorKills, int riftHeraldKills, int towerKills, int vilemawKills, List<GameTeamBan> bans) {
			this.Side = side;
			this.Type = type;
			this.Win = win;
			this.FirstTower = firstTower;
			this.FirstDragon = firstDragon;
			this.FirstBarron = firstBarron;
			this.FirstBlood = firstBlood;
			this.FirstRiftHerald = firstRiftHerald;
			this.FirstInhibitor = firstInhibitor;
			this.Id = id;
			this.BaronKills = baronKills;
			this.DominionVictoryScore = dominionVictoryScore;
			this.DragonKills = dragonKills;
			this.InhibitorKills = inhibitorKills;
			this.RiftHeraldKills = riftHeraldKills;
			this.TowerKills = towerKills;
			this.VilemawKills = vilemawKills;
			this.Bans = bans;
		}
	}

	public struct GameTeamBan {
		public int ChampionId { get; }
		public int PickTurn { get; }

		public GameTeamBan(int championId, int pickTurn) {
			this.ChampionId = championId;
			this.PickTurn = pickTurn;
		}
	}

	public struct GameParticipant {
		public int Id { get; }
		public int ChampionId { get; }
		public int ParticipantId { get; }
		public int Icon { get; }
		public int SummonerSpell1 { get; }
		public int SummonerSpell2 { get; }
		public int TeamId { get; }
		
		public string Lane { get; }
		public string Role { get; }
		public string SummonerName { get; }
		public List<GameParticipantMastery> Masteries { get; }
		public List<GameParticipantRune> Runes { get; }
		public GameParticipantStats ParticipantStats { get; }
		public GameParticipantTimeline Timeline { get; }

		public GameParticipant(int id, int championId, int participantId, int profileIcon, int summonerSpell1, int summonerSpell2, int teamId, string lane, string role, string summonerName, List<GameParticipantMastery> masteries, List<GameParticipantRune> runes, GameParticipantStats gameParticipantStats, GameParticipantTimeline timeline) {
			this.Id = id;
			this.ChampionId = championId;
			this.ParticipantId = participantId;
			this.Icon = profileIcon;
			this.SummonerSpell1 = summonerSpell1;
			this.SummonerSpell2 = summonerSpell2;
			this.TeamId = teamId;
			this.Lane = lane;
			this.Role = role;
			this.SummonerName = summonerName;
			this.Masteries = masteries;
			this.Runes = runes;
			this.ParticipantStats = gameParticipantStats;
			this.Timeline = timeline;
		}
	}

	public struct GameParticipantMastery {
		private int masteryId, rank;
	}
	
	public struct GameParticipantRune {
		private int runeId, rank;
	}

	public struct GameParticipantTimeline {
		public Dictionary<string, float> CreepsPerMinDeltas { get; }
		public Dictionary<string, float> CsDiffPerMinDeltas { get; }
		public Dictionary<string, float> DamageTakeDiffPerMineDeltas { get; }
		public Dictionary<string, float> DamageTakenPerMinDeltas { get; }
		public Dictionary<string, float> GoldPerMinDeltas { get; }
		public Dictionary<string, float> XpDiffPerMinDeltas { get; }
		public Dictionary<string, float> XpPerMinDeltas { get; }

		public GameParticipantTimeline(Dictionary<string, float> creepsPerMinDeltas, Dictionary<string, float> csDiffPerMinDeltas, Dictionary<string, float> damageTakeDiffPerMineDeltas, Dictionary<string, float> damageTakenPerMinDeltas, Dictionary<string, float> goldPerMinDeltas, Dictionary<string, float> xpDiffPerMinDeltas, Dictionary<string, float> xpPerMinDeltas) {
			this.CreepsPerMinDeltas = creepsPerMinDeltas;
			this.CsDiffPerMinDeltas = csDiffPerMinDeltas;
			this.DamageTakeDiffPerMineDeltas = damageTakeDiffPerMineDeltas;
			this.DamageTakenPerMinDeltas = damageTakenPerMinDeltas;
			this.GoldPerMinDeltas = goldPerMinDeltas;
			this.XpDiffPerMinDeltas = xpDiffPerMinDeltas;
			this.XpPerMinDeltas = xpPerMinDeltas;
		}
	}

	public struct GameParticipantStats {
		public int Assists { get; }
		public int ChampLevel { get; }
		public int CombatPlayerScore { get; }
		public int DamageDealtToObjectives { get; }
		public int DamageDealtToTurrets { get; }
		public int DamageSelfMitigated { get; }
		public int Deaths { get; }
		public int DoubleKills { get; }
		public bool FirstBloodAssist { get; }
		public bool FirstBloodKill { get; }
		public bool FirstInhibitorAssist { get; }
		public bool FirstInhibitorKill { get; }
		public bool FirstTowerAssist { get; }
		public bool FirstTowerKill { get; }
		public int GoldEarned { get; }
		public int GoldSpent { get; }
		public int InhibitorKills { get; }
		public int Item0 { get; }
		public int Item1 { get; }
		public int Item2 { get; }
		public int Item3 { get; }
		public int Item4 { get; }
		public int Item5 { get; }
		public int Item6 { get; }
		public int KillingSprees { get; }
		public int Kills { get; }
		public int LargestCriticalStrike { get; }
		public int LargestKillingSpree { get; }
		public int LargestMultiKill { get; }
		public int LongestTimeSpentLiving { get; }
		public int MagicDamageDealt { get; }
		public int MagicDamageDealtToChampions { get; }
		public int MagicalDamageTaken { get; }
		public int NeutralMinionsKilled { get; }
		public int NeutralMinionsKilledEnemyJungle { get; }
		public int NeutralMinionsKilledTeamJungle { get; }
		public int ObjectivePlayerScore { get; }
		public int PentaKills { get; }
		public int Perk0 { get; }
		public int Perk0Var1 { get; }
		public int Perk0Var2 { get; }
		public int Perk0Var3 { get; }
		public int Perk1 { get; }
		public int Perk1Var1 { get; }
		public int Perk1Var2 { get; }
		public int Perk1Var3 { get; }
		public int Perk2 { get; }
		public int Perk2Var1 { get; }
		public int Perk2Var2 { get; }
		public int Perk2Var3 { get; }
		public int Perk3 { get; }
		public int Perk3Var1 { get; }
		public int Perk3Var2 { get; }
		public int Perk3Var3 { get; }
		public int Perk4 { get; }
		public int Perk4Var1 { get; }
		public int Perk4Var2 { get; }
		public int Perk4Var3 { get; }
		public int Perk5 { get; }
		public int Perk5Var1 { get; }
		public int Perk5Var2 { get; }
		public int Perk5Var3 { get; }
		public int PerkPrimaryStyle { get; }
		public int PerkSubStyle { get; }
		public int PhysicalDamageDealt { get; }
		public int PhysicalDamageDealtToChampions { get; }
		public int PhysicalDamageTaken { get; }
		public int PlayerScore0 { get; }
		public int PlayerScore1 { get; }
		public int PlayerScore2 { get; }
		public int PlayerScore3 { get; }
		public int PlayerScore4 { get; }
		public int PlayerScore5 { get; }
		public int PlayerScore6 { get; }
		public int PlayerScore7 { get; }
		public int PlayerScore8 { get; }
		public int PlayerScore9 { get; }
		public int QuadraKills { get; }
		public int SightWardsBoughtInGame { get; }
		public int TimeCCingOthers { get; }
		public int TotalDamageDealt { get; }
		public int TotalDamageDealtToChampions { get; }
		public int TotalDamageTaken { get; }
		public int TotalHeal { get; }
		public int TotalMinionsKilled { get; }
		public int TotalPlayerScore { get; }
		public int TotalScoreRank { get; }
		public int TotalTimeCrowdControlDealt { get; }
		public int TotalUnitsHealed { get; }
		public int TripleKills { get; }
		public int TrueDamageDealt { get; }
		public int TrueDamageDealtToChampions { get; }
		public int TrueDamageTaken { get; }
		public int TurretKills { get; }
		public int UnrealKills { get; }
		public int VisionScore { get; }
		public int VisionWardsBoughtInGame { get; }
		public int WardsKilled { get; }
		public int WardsPlaced { get; }
		
		public GameParticipantStats(int assists, int champLevel, int combatPlayerScore, int damageDealtToObjectives, int damageDealtToTurrets, int damageSelfMitigated, int deaths, int doubleKills, bool firstBloodAssist, bool firstBloodKill, bool firstInhibitorAssist, bool firstInhibitorKill, bool firstTowerAssist, bool firstTowerKill, int goldEarned, int goldSpent, int inhibitorKills, int item0, int item1, int item2, int item3, int item4, int item5, int item6, int killingSprees, int kills, int largestCriticalStrike, int largestKillingSpree, int largestMultiKill, int longestTimeSpentLiving, int magicDamageDealt, int magicDamageDealtToChampions, int magicalDamageTaken, int neutralMinionsKilled, int neutralMinionsKilledEnemyJungle, int neutralMinionsKilledTeamJungle, int objectivePlayerScore, int pentaKills, int perk0, int perk0Var1, int perk0Var2, int perk0Var3, int perk1, int perk1Var1, int perk1Var2, int perk1Var3, int perk2, int perk2Var1, int perk2Var2, int perk2Var3, int perk3, int perk3Var1, int perk3Var2, int perk3Var3, int perk4, int perk4Var1, int perk4Var2, int perk4Var3, int perk5, int perk5Var1, int perk5Var2, int perk5Var3, int perkPrimaryStyle, int perkSubStyle, int physicalDamageDealt, int physicalDamageDealtToChampions, int physicalDamageTaken, int playerScore0, int playerScore1, int playerScore2, int playerScore3, int playerScore4, int playerScore5, int playerScore6, int playerScore7, int playerScore8, int playerScore9, int quadraKills, int sightWardsBoughtInGame, int timeCCingOthers, int totalDamageDealt, int totalDamageDealtToChampions, int totalDamageTaken, int totalHeal, int totalMinionsKilled, int totalPlayerScore, int totalScoreRank, int totalTimeCrowdControlDealt, int totalUnitsHealed, int tripleKills, int trueDamageDealt, int trueDamageDealtToChampions, int trueDamageTaken, int turretKills, int unrealKills, int visionScore, int visionWardsBoughtInGame, int wardsKilled, int wardsPlaced) {
			Assists = assists;
			ChampLevel = champLevel;
			CombatPlayerScore = combatPlayerScore;
			DamageDealtToObjectives = damageDealtToObjectives;
			DamageDealtToTurrets = damageDealtToTurrets;
			DamageSelfMitigated = damageSelfMitigated;
			Deaths = deaths;
			DoubleKills = doubleKills;
			FirstBloodAssist = firstBloodAssist;
			FirstBloodKill = firstBloodKill;
			FirstInhibitorAssist = firstInhibitorAssist;
			FirstInhibitorKill = firstInhibitorKill;
			FirstTowerAssist = firstTowerAssist;
			FirstTowerKill = firstTowerKill;
			GoldEarned = goldEarned;
			GoldSpent = goldSpent;
			InhibitorKills = inhibitorKills;
			Item0 = item0;
			Item1 = item1;
			Item2 = item2;
			Item3 = item3;
			Item4 = item4;
			Item5 = item5;
			Item6 = item6;
			KillingSprees = killingSprees;
			Kills = kills;
			LargestCriticalStrike = largestCriticalStrike;
			LargestKillingSpree = largestKillingSpree;
			LargestMultiKill = largestMultiKill;
			LongestTimeSpentLiving = longestTimeSpentLiving;
			MagicDamageDealt = magicDamageDealt;
			MagicDamageDealtToChampions = magicDamageDealtToChampions;
			MagicalDamageTaken = magicalDamageTaken;
			NeutralMinionsKilled = neutralMinionsKilled;
			NeutralMinionsKilledEnemyJungle = neutralMinionsKilledEnemyJungle;
			NeutralMinionsKilledTeamJungle = neutralMinionsKilledTeamJungle;
			ObjectivePlayerScore = objectivePlayerScore;
			PentaKills = pentaKills;
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
			PhysicalDamageDealt = physicalDamageDealt;
			PhysicalDamageDealtToChampions = physicalDamageDealtToChampions;
			PhysicalDamageTaken = physicalDamageTaken;
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
			QuadraKills = quadraKills;
			SightWardsBoughtInGame = sightWardsBoughtInGame;
			TimeCCingOthers = timeCCingOthers;
			TotalDamageDealt = totalDamageDealt;
			TotalDamageDealtToChampions = totalDamageDealtToChampions;
			TotalDamageTaken = totalDamageTaken;
			TotalHeal = totalHeal;
			TotalMinionsKilled = totalMinionsKilled;
			TotalPlayerScore = totalPlayerScore;
			TotalScoreRank = totalScoreRank;
			TotalTimeCrowdControlDealt = totalTimeCrowdControlDealt;
			TotalUnitsHealed = totalUnitsHealed;
			TripleKills = tripleKills;
			TrueDamageDealt = trueDamageDealt;
			TrueDamageDealtToChampions = trueDamageDealtToChampions;
			TrueDamageTaken = trueDamageTaken;
			TurretKills = turretKills;
			UnrealKills = unrealKills;
			VisionScore = visionScore;
			VisionWardsBoughtInGame = visionWardsBoughtInGame;
			WardsKilled = wardsKilled;
			WardsPlaced = wardsPlaced;
		}
	}

	public struct GameTimelineFrame {
		public long Timestamp { get; }
		public List<GameTimelineFrameEvent> Events { get; }
		public List<GameTimelineFrameParticipantFrame> ParticipantFrames { get; }

		public GameTimelineFrame(long timestamp, List<GameTimelineFrameEvent> events, List<GameTimelineFrameParticipantFrame> participantFrames) {
			this.Timestamp = timestamp;
			this.Events = events;
			this.ParticipantFrames = participantFrames;
		}
	}

	public struct GameTimelineFrameEvent {
		public long Timestamp { get; }
		public int TeamId { get; }
		public int ParticipantId { get; }
		public int ItemId { get; }
		public int SkillSlot { get; }
		public int CreatorId { get; }
		public string WardType { get; }
		public int KillerId { get; }
		public int VictimId { get; }
		public int XPos { get; }
		public int YPos { get; }
		public string Type { get; }
		public string LevelUpType { get; }
		public string AfterId { get; }
		public string BeforeId { get; }
		public string BuildingType { get; }
		public string LaneType { get; }
		public string TowerType { get; }
		public string MonsterType { get; }
		public List<int> AssistingParticipants { get; }

		public GameTimelineFrameEvent(long timestamp, int teamId, int participantId, int itemId, int skillSlot, int creatorId, string wardType, int killerId, int victimId, int xPos, int yPos, string type, string levelUpType, string afterId, string beforeId, string buildingType, string laneType, string towerType, string monsterType, List<int> assistingParticipants) {
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
	
	public struct GameTimelineFrameParticipantFrame {
		public int ParticipantId { get; }
		public int Level { get; }
		public int MinionsKilled { get; }
		public int JungleMinionsKilled { get; }
		public int DominionScore { get; }
		public int CurrentGold { get; }
		public int TeamScore { get; }
		public int TotalGold { get; }
		public int Xp { get; }
		public int XPos { get; }
		public int YPos { get; }

		public GameTimelineFrameParticipantFrame(int participantId, int level, int minionsKilled, int jungleMinionsKilled, int dominionScore, int currentGold, int teamScore, int totalGold, int xp, int xPos, int yPos) {
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