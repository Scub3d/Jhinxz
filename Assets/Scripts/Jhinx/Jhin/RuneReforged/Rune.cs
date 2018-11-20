// ReSharper disable All

using System.Collections.Generic;
using SimpleJSON;

namespace Jhinx.Jhin.RuneReforged {
	public class Rune {
		public int Id { get; set; }
		public string Key { get; set; }
		public string Icon { get; set; }
		public string Name { get; set; }
		public string ShortDesc { get; set; }
		public string LongDesc { get; set; }
		
		public Rune(int id, string key, string icon, string name, string shortDesc, string longDesc) {
			Id = id;
			Key = key;
			Icon = icon;
			Name = name;
			ShortDesc = shortDesc;
			LongDesc = longDesc;
		}

		public static Rune parseRuneJSON(JSONNode json) {
			return new Rune(json["id"], json["key"], json["icon"], json["name"], json["shortDesc"], json["longDesc"]);
		}

		public static List<Rune> parseRunesJSON(JSONArray json) {
			List<Rune> runes = new List<Rune>();
			foreach (JSONNode runeJSON in json) {
				runes.Add(parseRuneJSON(runeJSON));
			}

			return runes;
		}
	}
}