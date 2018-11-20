using System.Collections.Generic;
// ReSharper disable All

namespace Jhinx.Jhin.Champion {
	public class Block {
		public string Type { get; set; }
		public bool RecMath { get; set; }
		public bool RecSteps { get; set; }
		public int MinSummonerLevel { get; set; }
		public int MaxSummonerLevel { get; set; }
		public string ShowIfSummonerSpell { get; set; }
		public string HideIfSummonerSpell { get; set; }
		public string AppendAferSection { get; set; }
		public List<string> VisibleWithAllOf { get; set; }
		public List<string> HiddenWithAnyOf { get; set; }
		public List<Item> Items { get; set; }
		
		public Block(string type, bool recMath, bool recSteps, int minSummonerLevel, int maxSummonerLevel, string showIfSummonerSpell, string hideIfSummonerSpell, string appendAferSection, List<string> visibleWithAllOf, List<string> hiddenWithAnyOf, List<Item> items) {
			Type = type;
			RecMath = recMath;
			RecSteps = recSteps;
			MinSummonerLevel = minSummonerLevel;
			MaxSummonerLevel = maxSummonerLevel;
			ShowIfSummonerSpell = showIfSummonerSpell;
			HideIfSummonerSpell = hideIfSummonerSpell;
			AppendAferSection = appendAferSection;
			VisibleWithAllOf = visibleWithAllOf;
			HiddenWithAnyOf = hiddenWithAnyOf;
			Items = items;
		}
	}
}