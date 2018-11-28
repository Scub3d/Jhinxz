namespace Jhinx.Jinx.Article {
	public class Image {
		public string Type { get; set; }
		public string Original { get; set; }
		public Variants Variants { get; set; }
		
		public Image(string type, string original, ArticleMediaImageVariants variants) {
			Type = type;
			Original = original;
			Variants = variants;
		}
	}
}