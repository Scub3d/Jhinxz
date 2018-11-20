// ReSharper disable All
namespace Jhinx.Jinx {
	public class HtmlBlock {
		public string ContentType { get; set; }
		public string Locale { get; set; }
		public string Content { get; set; }
		public string CompositeId { get; set; }
		
		public HtmlBlock(string contentType, string locale, string content, string compositeId) {
			ContentType = contentType;
			Locale = locale;
			Content = content;
			CompositeId = compositeId;
		}
	}
}