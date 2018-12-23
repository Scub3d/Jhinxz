using System.Collections;
using System.Collections.Generic;
using Jhinxz.Chompers;
using SimpleJSON;
using UnityEngine;
using UnityEngine.Networking;

// ReSharper disable All

namespace Jhinxz.Jhin {
	public class SummonerSpell {
		public string Id { get; set; }
		public string Name { get; set; }
		public string Description { get; set; }
		public string Tooltip { get; set; }
		public int MaxRank { get; set; }
		public List<int> Cooldown { get; set; }
		public string CooldownBurn { get; set; }
		public List<int> Cost { get; set; }
		public string CostBurn { get; set; }
		public string DataValues { get; set; } // Always null?
		public List<List<float>> Effect { get; set; }
		public List<string> EffectBurn { get; set; }
		public List<Chompers.Chompers.Var> Vars { get; set; }
		public string Key { get; set; }
		public List<string> Modes { get; set; }
		public string CostType { get; set; }
		public string MaxAmmo { get; set; }
		public List<int> Range { get; set; }
		public string RangeBurn { get; set; }
		public Image Image { get; set; }
		public string Resource { get; set; }
		
		public SummonerSpell(string id, string name, string description, string tooltip, int maxRank, List<int> cooldown, string cooldownBurn, List<int> cost, string costBurn, string dataValues, List<List<float>> effect, List<string> effectBurn, List<Chompers.Chompers.Var> vars, string key, List<string> modes, string costType, string maxAmmo, List<int> range, string rangeBurn, Image image, string resource) {
			Id = id;
			Name = name;
			Description = description;
			Tooltip = tooltip;
			MaxRank = maxRank;
			Cooldown = cooldown;
			CooldownBurn = cooldownBurn;
			Cost = cost;
			CostBurn = costBurn;
			DataValues = dataValues;
			Effect = effect;
			EffectBurn = effectBurn;
			Vars = vars;
			Key = key;
			Modes = modes;
			CostType = costType;
			MaxAmmo = maxAmmo;
			Range = range;
			RangeBurn = rangeBurn;
			Image = image;
			Resource = resource;
		}
		
		private static SummonerSpell parseSummonerSpellJSON(JSONNode json) {
			Chompers.Image image = Image.ParseImageJson(json["image"]);
			
			// TODO: Fix below
			List<List<float>> effect = new List<List<float>>();
			for (int i = 0; i < json["effect"].Count; i++) {
				effect.Add(Chompers.Chompers.parseFloatArrayJSON((json["effect"].AsArray)[i].AsArray));
			}
			
			List<Chompers.Chompers.Var> vars = new List<Chompers.Chompers.Var>();
			foreach (JSONNode varJSON in json["vars"]) {
				vars.Add(new Chompers.Chompers.Var(varJSON["link"], varJSON["coeff"], varJSON["key"]));
			}
			// TODO: Fix above
			
			return new SummonerSpell(json["id"], json["name"], json["description"],
				json["tooltip"], json["maxrank"], Chompers.Chompers.parseIntArrayJSON(json["cooldown"].AsArray), 
				json["cooldownBurn"], Chompers.Chompers.parseIntArrayJSON(json["cost"].AsArray), 
				json["costBurn"], json["dataValues"], effect, 
				Chompers.Chompers.parseStringArrayJSON(json["effectBurn"].AsArray), vars, json["key"], 
				Chompers.Chompers.parseStringArrayJSON(json["modes"].AsArray), json["costType"], 
				json["maxAmmo"], Chompers.Chompers.parseIntArrayJSON(json["range"].AsArray), 
				json["rangeBurn"], image, json["resource"]);
		}

		private static List<SummonerSpell> parseSummonerSpellsJSON(JSONNode json) {
			List<SummonerSpell> summonerSpells = new List<SummonerSpell>();
			foreach (JSONNode summonerSpellJSON in json) {
				summonerSpells.Add(parseSummonerSpellJSON(summonerSpellJSON));
			}

			return summonerSpells;
		}

		public static IEnumerator getSummonerSpells(string patchNumber, string languageCode) {
			using (UnityWebRequest www = UnityWebRequest.Get("https://ddragon.leagueoflegends.com/cdn/" + patchNumber + "/data/" + languageCode + "/summoner.json")) {
				yield return www.Send();
				if (www.isNetworkError || www.isHttpError) {
					Debug.Log(www.error);
					yield return null;
				} else {
					JSONNode summonerSpellsJSON = JSON.Parse(www.downloadHandler.text);
					List<SummonerSpell> summonerSpells = parseSummonerSpellsJSON(summonerSpellsJSON["data"]);
					yield return summonerSpells;
				}
			}
		}
	}
}
