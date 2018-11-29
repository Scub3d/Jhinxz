using System.Collections.Generic;
using SimpleJSON;

// ReSharper disable All

namespace Jhinx.Jinx.Tournament {	
	public class Standings {
		public List<List<Input>> Result { get; set; }
		public long Timestamp { get; set; }
		public string Source { get; set; }
		public string Note { get; set; }
		public List<History> History { get; set; }
		public bool Closed { get; set; }
		
		public Standings(List<List<Input>> result, long timestamp, string source, string note, List<History> history, bool closed) {
			Result = result;
			Timestamp = timestamp;
			Source = source;
			Note = note;
			History = history;
			Closed = closed;
		}

		public static Standings parseStandingsJSON(JSONNode json) {
			List<List<Input>> results = Jinx.Tournament.Input.parseInputsDoubleArrayJSON(json["result"].AsArray);
			List<History> history = null;//Jhinx.Jinx.Tournament.History.parseHistoriesJSON(json["hisotry"]);
			return new Standings(results, json["timestamp"], json["source"], json["note"], history, json["closed"]);
		}
	}
}