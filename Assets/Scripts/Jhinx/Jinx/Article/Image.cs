using SimpleJSON;

namespace Jhinx.Jinx.Article {
	public class Image {
		public string Type { get; set; }
		public string Original { get; set; }
		public Variants Variants { get; set; }
		
		public Image(string type, string original, Variants variants) {
			Type = type;
			Original = original;
			Variants = variants;
		}

		public static Image parseImageJSON(JSONNode json) {
			return new Image(null, null, null);
		}
	}
}