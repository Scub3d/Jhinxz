using System.Collections;
using System.Collections.Generic;
using SimpleJSON;
using UnityEngine;
using UnityEngine.Networking;

// ReSharper disable All

namespace Jhinx.Jinx.Game {
	public class GameStats {
		public long Id { get; set; }
		public string PlatformId { get; set; }
		public long GameCreation { get; set; }
		public int GameDuration { get; set; }
		public int QueueId { get; set; }
		public int MapId { get; set; }
		public int SeasonId { get; set; }
		public string GameVersion { get; set; }
		public string GameMode { get; set; }
		public string GameType { get; set; }
		public List<Team> Teams { get; set; }
		public List<Participant> Participants { get; set; }
		public List<ParticipantIdentity> ParticipantIdentitieses { get; set; }
		
		public GameStats(long id, string platformId, long gameCreation, int gameDuration, int queueId, int mapId, int seasonId, string gameVersion, string gameMode, string gameType, List<Team> teams, List<Participant> participants, List<ParticipantIdentity> participantIdentitieses) {
			Id = id;
			PlatformId = platformId;
			GameCreation = gameCreation;
			GameDuration = gameDuration;
			QueueId = queueId;
			MapId = mapId;
			SeasonId = seasonId;
			GameVersion = gameVersion;
			GameMode = gameMode;
			GameType = gameType;
			Teams = teams;
			Participants = participants;
			ParticipantIdentitieses = participantIdentitieses;
		}
		
		private static GameStats parseGameStatsJSON(JSONNode json) {
			List<Team> teams = Team.parseTeamsJSON(json["teams"]);
			List<Participant> participants = Participant.parseParticipantsJSON(json["participants"]);
			List<ParticipantIdentity> participantIdentities = ParticipantIdentity.parseParticipantIdentitiesJSON(json["participantIdentities"]);
			return new GameStats(json["id"], json["platformId"], json["gameCreation"], json["gameDuration"], json["queueId"], json["mapId"], json["seasonId"], json["gameVersion"], json["gameMode"], json["gameType"], teams, participants, participantIdentities);
		}
		
		public static IEnumerator getGameStats(string gameRealm, string gameId, string gameHash) {
			using (UnityWebRequest www = UnityWebRequest.Get("")) {
				yield return www.SendWebRequest();
				if (www.isNetworkError || www.isHttpError) {
					Debug.Log(www.error);
					yield return null;
				} else {
					JSONNode gameStatsJSON = JSON.Parse(www.downloadHandler.text);
					GameStats gameStats = parseGameStatsJSON(gameStatsJSON);
					yield return gameStats;                       
				}
			}
		}		
	}
}