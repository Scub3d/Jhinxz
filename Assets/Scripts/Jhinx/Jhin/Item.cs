using System.Collections;
using System.Collections.Generic;
using Jhinx.Chompers;
using SimpleJSON;
using UnityEngine;
using UnityEngine.Networking;

// ReSharper disable All

namespace Jhinx.Jhin {
	public class Item {
		public int Id { get; set; }
		public string Name { get; set; }
		public string Description { get; set; }
		public string Collaq { get; set; }
		public string Plaintext { get; set; }
		public string Group { get; set; }
		public bool Consumed { get; set; }
		public int Stacks { get; set; }
		public int Depth { get; set; }
		public bool ConsumeOnFull { get; set; }
		public int SpecialRecipe { get; set; }
		public bool InStore { get; set; }
		public bool HideFromAll { get; set; }
		public string RequiredChampion { get; set; }
		public string RequiredAlly { get; set; }
		public List<string> From { get; set; }
		public List<string> Into { get; set; }
		public Image Image { get; set; }
		public Gold Gold { get; set; }
		public List<string> Tags { get; set; }
		public Dictionary<string, bool> Maps { get; set; }
		public Dictionary<string, int> Stats { get; set; }
		
		public Item(int id, string name, string description, string collaq, string plaintext, string group, bool consumed, int stacks, int depth, bool consumeOnFull, int specialRecipe, bool inStore, bool hideFromAll, string requiredChampion, string requiredAlly, List<string> from, List<string> into, Image image, Gold gold, List<string> tags, Dictionary<string, bool> maps, Dictionary<string, int> stats) {
			Id = id;
			Name = name;
			Description = description;
			Collaq = collaq;
			Plaintext = plaintext;
			Group = group;
			Consumed = consumed;
			Stacks = stacks;
			Depth = depth;
			ConsumeOnFull = consumeOnFull;
			SpecialRecipe = specialRecipe;
			InStore = inStore;
			HideFromAll = hideFromAll;
			RequiredChampion = requiredChampion;
			RequiredAlly = requiredAlly;
			From = from;
			Into = into;
			Image = image;
			Gold = gold;
			Tags = tags;
			Maps = maps;
			Stats = stats;
		}
		
		
		private static Item parseItemJSON(JSONNode itemJSON) {
			List<string> from = new List<string>();
			foreach (JSONString fromId in itemJSON["from"]) {
				from.Add(fromId.Value);
			}
			
			List<string> into = new List<string>();
			foreach (JSONString intoId in itemJSON["into"]) {
				into.Add(intoId.Value);
			}
			
			Image image = new Image(Chompers.Image.ParseImageJson(itemJSON["image"]));
			Gold gold = new Gold(itemJSON["gold"]["base"], itemJSON["gold"]["purchasable"], itemJSON["gold"]["total"], itemJSON["gold"]["sell"]);
			
			List<string> tags = new List<string>();
			foreach (JSONString tag in itemJSON["tags"]) {
				tags.Add(tag.Value);
			}
			
			Dictionary<string, bool> maps = new Dictionary<string, bool>();
			foreach (string key in itemJSON["maps"].Keys) {
				maps.Add(key, itemJSON["maps"][key]);
			}
			
			Dictionary<string, int> stats = new Dictionary<string, int>();
			foreach (string key in itemJSON["stats"].Keys) {
				stats.Add(key, itemJSON["stats"][key]);
			}

			return new Item(itemJSON["id"], itemJSON["name"], itemJSON["description"], itemJSON["collaq"], itemJSON["plaintext"],
				itemJSON["group"], itemJSON["consumed"], itemJSON["stacks"], itemJSON["depth"], itemJSON["consumeOnFull"],
				itemJSON["specialRecipe"], itemJSON["inStore"], itemJSON["hideFromAll"], itemJSON["requiredChampion"], itemJSON["requiredAlly"], from, into,
				image, gold, tags, maps, stats);
		}
		
		public static IEnumerator getMaps(string patchNumber, string languageCode) {
			using (UnityWebRequest www = UnityWebRequest.Get("https://ddragon.leagueoflegends.com/cdn/" + patchNumber + "/data/" + languageCode + "/item.json")) {
				yield return www.Send();
				if (www.isNetworkError || www.isHttpError) {
					Debug.Log(www.error);
					yield return null;
				} else {
					List<Item> items = new List<Item>();
					JSONNode itemsJSON = JSON.Parse(www.downloadHandler.text)["data"];
					foreach (JSONNode itemJSON in itemsJSON) {
						items.Add(parseItemJSON(itemJSON));
					}
					yield return items;                       
				}
			}
		}		
	}

	public struct Gold {
		public int Base { get; set; }
		public bool Purchasable { get; set; }
		public int Total { get; set; }
		public int Sell { get; set; }
		
		public Gold(int @base, bool purchasable, int total, int sell) {
			Base = @base;
			Purchasable = purchasable;
			Total = total;
			Sell = sell;
		}
	}
}