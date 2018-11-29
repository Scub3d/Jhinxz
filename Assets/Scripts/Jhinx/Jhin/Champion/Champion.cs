using System.Collections;
using System.Collections.Generic;
using Jhinx.Chompers;
using SimpleJSON;
using UnityEngine;
using UnityEngine.Networking;

// ReSharper disable All

namespace Jhinx.Jhin.Champion {
	public class Champion {
		public string Id { get; set; }
		public string Key { get; set; }
		public string Name { get; set; }
		public string Title { get; set; }
		public Image Image { get; set; }
		public List<Skin> Skins { get; set; }
		public string Lore { get; set; }
		public string Blurb { get; set; }
		public List<string> AllyTips { get; set; }
		public List<string> EnemyTips { get; set; }
		public Info Info { get; set; }
		public List<string> Tags { get; set; }
		public string ParType { get; set; }
		public Stats Stats { get; set; }
		public List<Spell> Spells { get; set; }
		public Passive Passive { get; set; }
		public Recommended Recommended { get; set; }

		public Champion(string id, string key, string name, string title, Image image, List<Skin> skins, string lore, string blurb, List<string> allyTips, List<string> enemyTips, Info info, List<string> tags, string parType, Stats stats, List<Spell> spells, Passive passive, Recommended recommended) {
			Id = id;
			Key = key;
			Name = name;
			Title = title;
			Image = image;
			Skins = skins;
			Lore = lore;
			Blurb = blurb;
			AllyTips = allyTips;
			EnemyTips = enemyTips;
			Info = info;
			Tags = tags;
			ParType = parType;
			Stats = stats;
			Spells = spells;
			Passive = passive;
			Recommended = recommended;
		}

		public Champion(string id, string key, string name, string title, string blurb, Info info, Image image, List<string> tags, string parType, Stats stats) {
			Id = id;
			Key = key;
			Name = name;
			Title = title;
			Blurb = blurb;
			Info = info;
			Image = image;
			Tags = tags;
			ParType = parType;
			Stats = stats;
		}

		private static Champion parseChampionJSON(JSONNode championJSON) {
			Image image = Image.ParseImageJson(championJSON["image"]);

			List<Skin> skins = Skin.parseSkinsJSON(championJSON["skins"]);
			List<string> allyTips = Chompers.Chompers.parseStringArrayJSON(championJSON["allyTips"].AsArray);
			List<string> enemyTips = Chompers.Chompers.parseStringArrayJSON(championJSON["enemyTips"].AsArray);
			Info info = Info.parseInfoJSON(championJSON["info"]);
			List<string> tags = Chompers.Chompers.parseStringArrayJSON(championJSON["tags"].AsArray);
			Stats stats = Stats.parseStatsJSON(championJSON["stats"]);
			List<Spell> spells = Spell.parseSpellsJSON(championJSON["spells"]);
			Passive passive = Passive.parsePassiveJSON(championJSON["passive"]);
			Recommended recommended = Recommended.parseRecommendedJSON(championJSON["recommended"]);
			
			return new Champion(championJSON["id"], championJSON["key"], championJSON["name"], championJSON["title"], 
				image, skins, championJSON["lore"], championJSON["blurb"], allyTips, enemyTips, info, tags, 
				championJSON["partype"], stats, spells, passive, recommended);
		}
		
		private static Champion parseMinimalChampionJSON(JSONNode championJSON) {
			Info info = Info.parseInfoJSON(championJSON["info"]);
			Image image = Image.ParseImageJson(championJSON["image"]);
			return new Champion(championJSON["id"], championJSON["key"], championJSON["name"], championJSON["title"], 
				championJSON["blurb"], info, image, Chompers.Chompers.parseStringArrayJSON(championJSON["tags"].AsArray), 
				championJSON["partype"], Stats.parseStatsJSON(championJSON["stats"]));
		}		
		
		public static IEnumerator getChampionsSummary(string patchNumber, string languageCode) {
			using (UnityWebRequest www = UnityWebRequest.Get("https://ddragon.leagueoflegends.com/cdn/" + patchNumber + "/data/" + languageCode + "/champion.json")) {
				yield return www.Send();
				if (www.isNetworkError || www.isHttpError) {
					Debug.Log(www.error);
					yield return null;
				} else {
					List<Champion> champions = new List<Champion>();
					JSONNode championsJSON = JSON.Parse(www.downloadHandler.text)["data"];
					foreach (JSONNode championJSON in championsJSON) {
						champions.Add(parseMinimalChampionJSON(championJSON));
					}
					yield return champions;                       
				}
			}
		}		
		
		public static IEnumerator getChampions(string patchNumber, string languageCode) {
			using (UnityWebRequest www = UnityWebRequest.Get("https://ddragon.leagueoflegends.com/cdn/" + patchNumber + "/data/" + languageCode + "/championFull.json")) {
				yield return www.Send();
				if (www.isNetworkError || www.isHttpError) {
					Debug.Log(www.error);
					yield return null;
				} else {
					List<Champion> champions = new List<Champion>();
					JSONNode championsJSON = JSON.Parse(www.downloadHandler.text)["data"];
					foreach (JSONNode championJSON in championsJSON) {
						champions.Add(parseChampionJSON(championJSON));
					}
					yield return champions;                       
				}
			}
		}
		
		public static IEnumerator getChampion(string patchNumber, string languageCode, string championId) {
			using (UnityWebRequest www = UnityWebRequest.Get("https://ddragon.leagueoflegends.com/cdn/" + patchNumber + "/data/" + languageCode + "/champion/" + championId + ".json")) {
				yield return www.Send();
				if (www.isNetworkError || www.isHttpError) {
					Debug.Log(www.error);
					yield return null;
				} else {
					JSONNode championJSON = JSON.Parse(www.downloadHandler.text)["data"];
					Debug.Log(championJSON[championId]);
					yield return parseChampionJSON(championJSON[championId]);                       
				}
			}
		}		
	}

}