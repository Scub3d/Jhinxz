// ReSharper disable All

using System.Collections.Generic;
using SimpleJSON;

namespace Jhinx.Jinx.League {
	public class HighlanderRecord {
		public int Wins { get; set; }
		public int Losses { get; set; }
		public int Ties { get; set; }
		public int Score { get; set; }
		public string Roster { get; set; }
		public string Tournament { get; set; }
		public string Bracket { get; set; }
		public string Id { get; set; }
        
		public HighlanderRecord(int wins, int losses, int ties, int score, string roster, string tournament, string bracket, string id) {
			Wins = wins;
			Losses = losses;
			Ties = ties;
			Score = score;
			Roster = roster;
			Tournament = tournament;
			Bracket = bracket;
			Id = id;
		}

		public static HighlanderRecord parseHighlandRecordJSON(JSONNode json) {
			return new HighlanderRecord(json["wins"], json["losses"], json["ties"], json["score"], json["roster"],
				json["tournament"], json["bracket"], json["id"]);
		}

		public static List<HighlanderRecord> parseHighlandRecords(JSONArray json) {
			List<HighlanderRecord> highlandRecords = new List<HighlanderRecord>();
			foreach (JSONNode highlandRecordJSON in json) {
				highlandRecords.Add(parseHighlandRecordJSON(highlandRecordJSON));
			}

			return highlandRecords;
		}
	}
}