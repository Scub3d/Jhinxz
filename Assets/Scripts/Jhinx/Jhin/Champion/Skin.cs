// ReSharper disable All

using System.Collections.Generic;
using SimpleJSON;

namespace Jhinx.Jhin.Champion {
	public class Skin {
		public string Id { get; set; }
		public int Num { get; set; }
		public string Name { get; set; }
		public bool Chromas { get; set; }
		
		public Skin(string id, int num, string name, bool chromas) {
			Id = id;
			Num = num;
			Name = name;
			Chromas = chromas;
		}

		public static Skin parsejson(JSONNode json) {
			return new Skin(json["id"], json["num"], json["name"], json["chromas"]);
		}

		public static List<Skin> parseSkinsJSON(JSONNode json) {
			List<Skin> skins = new List<Skin>();
			foreach (JSONNode skinJSON in json) {
				skins.Add(parsejson(json));
			}

			return skins;
		}
		
	}
}