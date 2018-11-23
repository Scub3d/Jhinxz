// ReSharper disable All

using System.Collections.Generic;
using SimpleJSON;

namespace Jhinx.Jinx.Game {
	public class ParticipantIdentity {
		public int ParticipantId { get; set; }
		public Player Player { get; set; }
		
		public ParticipantIdentity(int participantId, Player player) {
			ParticipantId = participantId;
			Player = player;
		}

		public static ParticipantIdentity parseParticipantIdentityJSON(JSONNode json) {
			Player player = Player.parsePlayerJSON(json["player"]);
			return new ParticipantIdentity(json["participantId"], player);
		}

		public static List<ParticipantIdentity> parseParticipantIdentitiesJSON(JSONNode json) {
			List<ParticipantIdentity> participantIdentities = new List<ParticipantIdentity>();
			foreach (JSONNode participantIdentityJSON in json) {
				participantIdentities.Add(parseParticipantIdentityJSON(participantIdentityJSON));
			}

			return participantIdentities;
		}
	}
}