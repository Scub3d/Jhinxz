// ReSharper disable All

using System.Collections.Generic;
using SimpleJSON;

namespace Jhinxz.Jhin.Champion {
	public class Item {
		public string Id { get; set; }
		public int Count { get; set; }
		public bool HideCount { get; set; }
		
		public Item(string id, int count, bool hideCount) {
			Id = id;
			Count = count;
			HideCount = hideCount;
		}

		public static Item parseItemJSON(JSONNode json) {
			return new Item(json["id"], json["count"], json["hideCount"]);
		}

		public static List<Item> parseItemsJSON(JSONNode json) {
			List<Item> items = new List<Item>();
			foreach (JSONNode itemJSON in json) {
				items.Add(parseItemJSON(itemJSON));
			}
			return items;
		}
	}
}