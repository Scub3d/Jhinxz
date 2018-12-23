using System.Collections.Generic;
using SimpleJSON;

// ReSharper disable All

namespace Jhinxz.Jhin.Champion {
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

		public static Block parseBlockJSON(JSONNode json) {
			List<Item> items = Item.parseItemsJSON(json["items"]);
								
			return new Block(json["type"], json["recMath"], json["recSteps"], json["minSummonerLevel"], 
				json["maxSummonerLevel"], json["showIfSummonerSpell"], json["hideIfSummonerSpell"], json["appendAfterSection"], 
				Chompers.Chompers.parseStringArrayJSON(json["visibileWithAllOf"].AsArray),  
				Chompers.Chompers.parseStringArrayJSON(json["hiddenWithAny"].AsArray), items);
		}

		public static List<Block> parseBlocksJSON(JSONNode json) {
			List<Block> blocks = new List<Block>();
			foreach (JSONNode blockJSON in json) {
				blocks.Add(parseBlockJSON(blockJSON));
			}

			return blocks;
		}
	}
}