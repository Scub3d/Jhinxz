namespace Jhinx.Jinx.Article {
	public class Variants {
		public string ArticleThumbnail { get; set; }
		public string ArticleImage { get; set; }
		public string Marquee { get; set; }
		public string Hero { get; set; }
		
		public Variants(string articleThumbnail, string articleImage, string marquee, string hero) {
			ArticleThumbnail = articleThumbnail;
			ArticleImage = articleImage;
			Marquee = marquee;
			Hero = hero;
		}
	}
}