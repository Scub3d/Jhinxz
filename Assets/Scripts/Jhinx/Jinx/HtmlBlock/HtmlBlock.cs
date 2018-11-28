// ReSharper disable All

using System.Collections.Generic;
using SimpleJSON;

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

		public static HtmlBlock parseHtmlBlockJSON(JSONNode json) {
			return new HtmlBlock(json["contentType"], json["locale"], json["content"], json["compositeId"]);
		}

		public static List<HtmlBlock> parseHtmlBlocksJSON(JSONArray json) {
			List<HtmlBlock> htmlBlocks = new List<HtmlBlock>();
			foreach (JSONNode htmlBlockJSON in json) {
				htmlBlocks.Add(parseHtmlBlockJSON(htmlBlockJSON));
			}

			return htmlBlocks;
		}
	}
}