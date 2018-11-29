// ReSharper disable All

using System.Collections.Generic;
using SimpleJSON;

// Use this for input, results, etc
namespace Jhinx.Jinx.Tournament {	
	public class Input {
		public string Roster { get; set; }
		public string Bracket { get; set; }
		public int Standing { get; set; }
		
		public Input(string roster, string bracket, int standing) {
			Roster = roster;
			Bracket = bracket;
			Standing = standing;
		}

		public static Input parseInputJSON(JSONNode json) {
			return new Input(json["roster"], json["bracket"], json["standing"]);
		}

		public static List<Input> parseInputsArrayJSON(JSONArray json) {
			List<Input> inputs = new List<Input>();
			foreach (JSONNode inputJSON in json) {
				inputs.Add(parseInputJSON(inputJSON));
			}
			
			return inputs;
		}
		
		public static List<List<Input>> parseInputsDoubleArrayJSON(JSONArray json) {
			List<List<Input>> inputs = new List<List<Input>>();
			foreach (JSONArray subArray in json) {
				List<Input> inputsArray = new List<Input>();
				foreach (JSONNode inputJSON in subArray) {
					inputsArray.Add(parseInputJSON(inputJSON));
				}
				inputs.Add(inputsArray);
			}

			return inputs;
		}
	}
}