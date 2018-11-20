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

		public Champion(string id, string key, string name, string title, Image image, List<ChampionSkin> skins, string lore, string blurb, List<string> allyTips, List<string> enemyTips, ChampionInfo info, List<string> tags, string parType, ChampionStats stats, List<ChampionSpell> spells, ChampionPassive passive, ChampionRecommended recommended) {
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

		public Champion(string id, string key, string name, string title, string blurb, ChampionInfo info, Image image, List<string> tags, string parType, ChampionStats stats) {
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
			
			List<ChampionSkin> skins = new List<ChampionSkin>();
			foreach (JSONNode skinJSON in championJSON["skins"]) {
				skins.Add(new ChampionSkin(skinJSON["id"], skinJSON["num"], skinJSON["name"], skinJSON["chromas"]));
			}

			List<string> allyTips = Chompers.Chompers.parseStringArrayJSON(championJSON["allyTips"].AsArray);
			List<string> enemyTips = Chompers.Chompers.parseStringArrayJSON(championJSON["enemyTips"].AsArray);
			ChampionInfo info = new ChampionInfo(championJSON["info"]["attack"], championJSON["info"]["defence"], 
				championJSON["info"]["magic"], championJSON["info"]["difficulty"]);

			List<string> tags = Chompers.Chompers.parseStringArrayJSON(championJSON["tags"].AsArray);

			ChampionStats stats = parseChampionStatsJSON(championJSON["stats"]);
			
			List<ChampionSpell> spells = new List<ChampionSpell>();
			foreach (JSONNode spellJSON in championJSON["spells"]) {
				spells.Add(parseChampionSpellJSON(spellJSON));
			}
			
			ChampionPassive passive = new ChampionPassive(championJSON["passive"]["name"], championJSON["passive"]["description"], 
				Image.ParseImageJson(championJSON["passive"]["image"]));
			
			
			List<ChampionRecommendedBlock> blocks = new List<ChampionRecommendedBlock>();
			foreach (JSONNode blockJSON in championJSON["recommended"]["blocks"]) {
				List<ChampionRecommendedBlockItem> items = new List<ChampionRecommendedBlockItem>();
				foreach (JSONNode itemJSON in blockJSON["items"]) {
					items.Add(new ChampionRecommendedBlockItem(itemJSON["id"], itemJSON["count"], itemJSON["hideCount"]));
				}
				
				blocks.Add(new ChampionRecommendedBlock(blockJSON["type"], blockJSON["recMath"], blockJSON["recSteps"], blockJSON["minSummonerLevel"], 
					blockJSON["maxSummonerLevel"], blockJSON["showIfSummonerSpell"], blockJSON["hideIfSummonerSpell"], blockJSON["appendAfterSection"], 
					Chompers.Chompers.parseStringArrayJSON(blockJSON["visibileWithAllOf"].AsArray),  
					Chompers.Chompers.parseStringArrayJSON(blockJSON["hiddenWithAny"].AsArray), items));
			}
			
			ChampionRecommended recommended = new ChampionRecommended(championJSON["recommended"]["champion"], 
				championJSON["recommended"]["title"], championJSON["recommended"]["map"], championJSON["recommended"]["mode"], 
				championJSON["recommended"]["type"], championJSON["recommended"]["customTag"], championJSON["recommended"]["sortrank"], 
				championJSON["recommended"]["extensionPage"], championJSON["recommended"]["useObviousCheckmark"], 
				championJSON["recommended"]["customPanel"], blocks);
			
			return new Champion(championJSON["id"], championJSON["key"], championJSON["name"], championJSON["title"], 
				image, skins, championJSON["lore"], championJSON["blurb"], allyTips, enemyTips, info, tags, 
				championJSON["partype"], stats, spells, passive, recommended);
		}
		
		private static Champion parseMinimalChampionJSON(JSONNode championJSON) {
			ChampionInfo info = new ChampionInfo(championJSON["info"]["attack"], championJSON["info"]["defence"], 
				championJSON["info"]["magic"], championJSON["info"]["difficulty"]);
			Image image = Image.ParseImageJson(championJSON["image"]);
			return new Champion(championJSON["id"], championJSON["key"], championJSON["name"], championJSON["title"], 
				championJSON["blurb"], info, image, Chompers.Chompers.parseStringArrayJSON(championJSON["tags"].AsArray), 
				championJSON["partype"], parseChampionStatsJSON(championJSON["stats"]));
		}		
		
		private static ChampionStats parseChampionStatsJSON(JSONNode statsJSON) {
			return new ChampionStats(statsJSON["hp"], statsJSON["hpperlevel"], statsJSON["mp"], statsJSON["mpperlevel"], 
				statsJSON["movespeed"], statsJSON["armor"], statsJSON["armorperlevel"], statsJSON["spellblock"],
				statsJSON["spellblockperlevel"], statsJSON["attackrange"], statsJSON["hpregen"], statsJSON["hpregenperlevel"],
				statsJSON["mpregen"], statsJSON["mpregenperlevel"], statsJSON["crit"], statsJSON["critperlevel"], 
				statsJSON["attackdamage"], statsJSON["attackdamageperlevel"], statsJSON["attackspeedperlevel"]);
		}

		private static ChampionSpell parseChampionSpellJSON(JSONNode spellJSON) {
			// Todo
			ChampionSpellLevelTip levelTip = new ChampionSpellLevelTip(Chompers.Chompers.parseStringArrayJSON(spellJSON["leveltip"]["label"].AsArray),
				Chompers.Chompers.parseStringArrayJSON(spellJSON["leveltip"]["effect"].AsArray));
			
			List<List<float>> effect = new List<List<float>>();
			foreach (JSONArray effectArray in spellJSON["effect"].AsArray) {
				effect.Add(Chompers.Chompers.parseFloatArrayJSON(effectArray));
			}
			
			List<Chompers.Chompers.Var> vars = new List<Chompers.Chompers.Var>();
			foreach (JSONNode varJSON in spellJSON["vars"]) {
				vars.Add(new Chompers.Chompers.Var(varJSON["link"], varJSON["coeff"], varJSON["key"]));
			}
			
			Image image = Image.ParseImageJson(spellJSON["image"]);
			
			return new ChampionSpell(spellJSON["id"], spellJSON["name"], spellJSON["description"], spellJSON["tooltip"], 
				levelTip, spellJSON["maxRank"], Chompers.Chompers.parseIntArrayJSON(spellJSON["cooldown"].AsArray), spellJSON["cooldwonBurn"], 
				Chompers.Chompers.parseIntArrayJSON(spellJSON["cost"].AsArray), spellJSON["costBurn"], spellJSON["dataValues"], effect,
				Chompers.Chompers.parseStringArrayJSON(spellJSON["effectBurn"].AsArray), vars, spellJSON["costType"], spellJSON["maxAmmo"], 
				Chompers.Chompers.parseIntArrayJSON(spellJSON["range"].AsArray), spellJSON["rangeBurn"], image, spellJSON["resource"]);
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
					yield return parseChampionJSON(championJSON);                       
				}
			}
		}		
	}

}