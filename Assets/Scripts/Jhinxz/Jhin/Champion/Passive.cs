using Jhinxz.Chompers;
using SimpleJSON;

// ReSharper disable All

namespace Jhinxz.Jhin.Champion {
	public class Passive {
		public string Name { get; set; }
		public string Description { get; set; }
		public Image Image { get; set; }
		
		public Passive(string name, string description, Image image) {
			Name = name;
			Description = description;
			Image = image;
		}

		public static Passive parsePassiveJSON(JSONNode json) {
			return new Passive(json["name"], json["description"], Image.ParseImageJson(json["image"]));
		}
	}
}