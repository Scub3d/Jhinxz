using System.Collections.Generic;
// ReSharper disable All

namespace Jhinx.Jhin.Champion {
	public class Recommended {
		public string Champion { get; set; }
		public string Title { get; set; }
		public string Map { get; set; }
		public string Mode { get; set; }
		public string Type { get; set; }
		public string CustomTag { get; set; }
		public int SortRank { get; set; }
		public bool ExtensionPage { get; set; }
		public bool UseObviousCheckmark { get; set; }
		public string CustomPanel { get; set; } // null?
		public List<Block> Blocks { get; set; }
		
		public Recommended(string champion, string title, string map, string mode, string type, string customTag, int sortRank, bool extensionPage, bool useObviousCheckmark, string customPanel, List<Block> blocks) {
			Champion = champion;
			Title = title;
			Map = map;
			Mode = mode;
			Type = type;
			CustomTag = customTag;
			SortRank = sortRank;
			ExtensionPage = extensionPage;
			UseObviousCheckmark = useObviousCheckmark;
			CustomPanel = customPanel;
			Blocks = blocks;
		}
	}
}