using System.Collections.Generic;
using SimpleJSON;
// ReSharper disable All

namespace Jhinxz.Zoe.Fantasy {
	public class FlavorTextEntry {
		public string LanguageCode { get; set; }
		public string FlavorText { get; set; }

		public FlavorTextEntry(string languageCode, string flavorText) {
			LanguageCode = languageCode;
			FlavorText = flavorText;
		}
		
		public static FlavorTextEntry parseFlavorTextEntryJSON(JSONNode json) {
			return new FlavorTextEntry(json["languageCode"], json["flavorText"]);
		}
		
		public static List<FlavorTextEntry> parseFlavorTextEntriesJSON(JSONArray json) {
			List<FlavorTextEntry> flavorTextEntries = new List<FlavorTextEntry>();
			foreach (JSONNode flavorTextEntryJSON in json) {
				flavorTextEntries.Add(parseFlavorTextEntryJSON(flavorTextEntryJSON));
			}
			
			return flavorTextEntries;
		}
	}
}