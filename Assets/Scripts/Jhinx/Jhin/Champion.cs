using System.Collections;
using System.Collections.Generic;
using Jhinx.Chompers;
using SimpleJSON;
using UnityEngine;
using UnityEngine.Networking;

// ReSharper disable All

namespace Jhinx.Jhin {
	public class Champion {
		public string Id { get; set; }
		public string Key { get; set; }
		public string Name { get; set; }
		public string Title { get; set; }
		public Image Image { get; set; }
		public List<ChampionSkin> Skins { get; set; }
		public string Lore { get; set; }
		public string Blurb { get; set; }
		public List<string> AllyTips { get; set; }
		public List<string> EnemyTips { get; set; }
		public ChampionInfo Info { get; set; }
		public List<string> Tags { get; set; }
		public string ParType { get; set; }
		public ChampionStats Stats { get; set; }
		public List<ChampionSpell> Spells { get; set; }
		public ChampionPassive Passive { get; set; }
		public ChampionRecommended Recommended { get; set; }

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
			
			List<ChampionSpellVar> vars = new List<ChampionSpellVar>();
			foreach (JSONNode varJSON in spellJSON["vars"]) {
				vars.Add(new ChampionSpellVar(varJSON["link"], varJSON["coeff"], varJSON["key"]));
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

	public struct ChampionSkin {
		public string Id { get; set; }
		public int Num { get; set; }
		public string Name { get; set; }
		public bool Chromas { get; set; }
		
		public ChampionSkin(string id, int num, string name, bool chromas) {
			Id = id;
			Num = num;
			Name = name;
			Chromas = chromas;
		}
	}

	public struct ChampionInfo {
		public int Attack { get; set; }
		public int Defense { get; set; }
		public int Magic { get; set; }
		public int Difficulty { get; set; }

		public ChampionInfo(int attack, int defense, int magic, int difficulty) {
			Attack = attack;
			Defense = defense;
			Magic = magic;
			Difficulty = difficulty;
		}
	}
	
	public struct ChampionStats {
		public float Hp { get; set; }
		public float HpPerLevel { get; set; }
		public float Mp { get; set; }
		public float MpPerLevel { get; set; }
		public float MoveSpeed { get; set; }
		public float Armor { get; set; }
		public float ArmorPerLevel { get; set; }
		public float Spellblock { get; set; }
		public float SpellblockPerLevel { get; set; }
		public float AttackRange { get; set; }
		public float HpRegen { get; set; }
		public float HpRegenPerLevel { get; set; }
		public float MpRegen { get; set; }
		public float MpRegenPerLevel { get; set; }
		public float Crit { get; set; }
		public float CritPerLevel { get; set; }
		public float AttackDamage { get; set; }
		public float AttackDamagePerLevel { get; set; }
		public float AttackSpeedPerLevel { get; set; }
		
		public ChampionStats(float hp, float hpPerLevel, float mp, float mpPerLevel, float moveSpeed, float armor, float armorPerLevel, float spellblock, float spellblockPerLevel, float attackRange, float hpRegen, float hpRegenPerLevel, float mpRegen, float mpRegenPerLevel, float crit, float critPerLevel, float attackDamage, float attackDamagePerLevel, float attackSpeedPerLevel) {
			Hp = hp;
			HpPerLevel = hpPerLevel;
			Mp = mp;
			MpPerLevel = mpPerLevel;
			MoveSpeed = moveSpeed;
			Armor = armor;
			ArmorPerLevel = armorPerLevel;
			Spellblock = spellblock;
			SpellblockPerLevel = spellblockPerLevel;
			AttackRange = attackRange;
			HpRegen = hpRegen;
			HpRegenPerLevel = hpRegenPerLevel;
			MpRegen = mpRegen;
			MpRegenPerLevel = mpRegenPerLevel;
			Crit = crit;
			CritPerLevel = critPerLevel;
			AttackDamage = attackDamage;
			AttackDamagePerLevel = attackDamagePerLevel;
			AttackSpeedPerLevel = attackSpeedPerLevel;
		}
	}

	public struct ChampionSpell {
		public string Id { get; set; }
		public string Name { get; set; }
		public string Description { get; set; }
		public string Tooltip { get; set; }
		public ChampionSpellLevelTip LevelTip { get; set; }
		public int MaxRank { get; set; }
		public List<int> Cooldown { get; set; }
		public string CooldownBurn { get; set; }
		public List<int> Cost { get; set; }
		public string CostBurn { get; set; }
		public string DataValues { get; set; } // Always null?
		public List<List<float>> Effect { get; set; }
		public List<string> EffectBurn { get; set; }
		public List<ChampionSpellVar> Vars { get; set; }
		public string CostType { get; set; }
		public string MaxAmmo { get; set; }
		public List<int> Range { get; set; }
		public string RangeBurn { get; set; }
		public Image Image { get; set; }
		public string Resource { get; set; }

		public ChampionSpell(string id, string name, string description, string tooltip, ChampionSpellLevelTip levelTip, int maxRank, List<int> cooldown, string cooldownBurn, List<int> cost, string costBurn, string dataValues, List<List<float>> effect, List<string> effectBurn, List<ChampionSpellVar> vars, string costType, string maxAmmo, List<int> range, string rangeBurn, Image image, string resource) {
			Id = id;
			Name = name;
			Description = description;
			Tooltip = tooltip;
			LevelTip = levelTip;
			MaxRank = maxRank;
			Cooldown = cooldown;
			CooldownBurn = cooldownBurn;
			Cost = cost;
			CostBurn = costBurn;
			DataValues = dataValues;
			Effect = effect;
			EffectBurn = effectBurn;
			Vars = vars;
			CostType = costType;
			MaxAmmo = maxAmmo;
			Range = range;
			RangeBurn = rangeBurn;
			Image = image;
			Resource = resource;
		}
	}
	
	public struct ChampionSpellLevelTip {
		public List<string> Label { get; set; }
		public List<string> Effect { get; set; }
		
		public ChampionSpellLevelTip(List<string> label, List<string> effect) {
			Label = label;
			Effect = effect;
		}
	}

	public struct ChampionSpellVar {
		public string Link { get; set; }
		public float Coeff { get; set; }
		public string Key { get; set; }
		
		public ChampionSpellVar(string link, float coeff, string key) {
			Link = link;
			Coeff = coeff;
			Key = key;
		}
	}
	
	public struct ChampionPassive {
		public string Name { get; set; }
		public string Description { get; set; }
		public Image Image { get; set; }
		
		public ChampionPassive(string name, string description, Image image) {
			Name = name;
			Description = description;
			Image = image;
		}
	}

	public struct ChampionRecommended {
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
		public List<ChampionRecommendedBlock> Blocks { get; set; }
		
		public ChampionRecommended(string champion, string title, string map, string mode, string type, string customTag, int sortRank, bool extensionPage, bool useObviousCheckmark, string customPanel, List<ChampionRecommendedBlock> blocks) {
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

	public struct ChampionRecommendedBlock {
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
		public List<ChampionRecommendedBlockItem> Items { get; set; }
		
		public ChampionRecommendedBlock(string type, bool recMath, bool recSteps, int minSummonerLevel, int maxSummonerLevel, string showIfSummonerSpell, string hideIfSummonerSpell, string appendAferSection, List<string> visibleWithAllOf, List<string> hiddenWithAnyOf, List<ChampionRecommendedBlockItem> items) {
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

	public struct ChampionRecommendedBlockItem {
		public string Id { get; set; }
		public int Count { get; set; }
		public bool HideCount { get; set; }
		
		public ChampionRecommendedBlockItem(string id, int count, bool hideCount) {
			Id = id;
			Count = count;
			HideCount = hideCount;
		}
	}
}