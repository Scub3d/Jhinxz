// ReSharper disable All

using SimpleJSON;

namespace Jhinx.Jinx.Game {
	public class Player {
		public string SummonerName { get; set; }
		public int ProfileIcon { get; set; }
		
		public Player(string summonerName, int profileIcon) {
			SummonerName = summonerName;
			ProfileIcon = profileIcon;
		}

		public static Player parsePlayerJSON(JSONNode json) {
			return new Player(json["summonerName"], json["profileIcon"]);
		}
	}
}