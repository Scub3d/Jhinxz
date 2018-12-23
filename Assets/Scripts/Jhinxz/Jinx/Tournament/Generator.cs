// ReSharper disable All

using SimpleJSON;

namespace Jhinxz.Jinx.Tournament {
	public class Generator {
		public string Identifier { get; set; }
		
		public Generator(string identifier) {
			Identifier = identifier;
		}

		public static Generator parseGeneratorJSON(JSONNode json) {
			return new Generator(json["identifier"]);
		}
	}
}