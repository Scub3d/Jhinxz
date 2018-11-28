namespace Jhinx.Jinx.Article {
	public class Path {
		public string Canonical { get; set; }
		public List<string> Alternate { get; set; }
		
		public ArticlePath(string canonical, List<string> alternate) {
			Canonical = canonical;
			Alternate = alternate;
		}
	}
}