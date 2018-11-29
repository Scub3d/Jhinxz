using System.Collections.Generic;
// ReSharper disable All

namespace Jhinx.Jinx.Article {
	public class Media {
		public List<string> Video { get; set; }
		public Image Image { get; set; }
		public List<string> Marquee { get; set; }
		
		public Media(List<string> video, Image image, List<string> marquee) {
			Video = video;
			Image = image;
			Marquee = marquee;
		}
	}
}