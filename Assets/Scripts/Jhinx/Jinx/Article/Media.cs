namespace Jhinx.Jinx.Article {
	public class Media {
		public List<string> Video { get; set; }
		public ArticleMediaImage Image { get; set; }
		public List<string> Marquee { get; set; }
		
		public Media(List<string> video, ArticleMediaImage image, List<string> marquee) {
			Video = video;
			Image = image;
			Marquee = marquee;
		}
	}
}