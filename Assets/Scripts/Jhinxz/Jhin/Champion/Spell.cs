using System.Collections.Generic;
using System.Linq;
using Jhinxz.Chompers;
using SimpleJSON;

// ReSharper disable All

namespace Jhinxz.Jhin.Champion {
	public class Spell {
		public string Id { get; set; }
		public string Name { get; set; }
		public string Description { get; set; }
		public string Tooltip { get; set; }
		public LevelTip LevelTip { get; set; }
		public int MaxRank { get; set; }
		public List<int> Cooldown { get; set; }
		public string CooldownBurn { get; set; }
		public List<int> Cost { get; set; }
		public string CostBurn { get; set; }
		public string DataValues { get; set; } // Always null?
		public List<List<float>> Effect { get; set; }
		public List<string> EffectBurn { get; set; }
		public List<Chompers.Chompers.Var> Vars { get; set; }
		public string CostType { get; set; }
		public string MaxAmmo { get; set; }
		public List<int> Range { get; set; }
		public string RangeBurn { get; set; }
		public Image Image { get; set; }
		public string Resource { get; set; }

		public Spell(string id, string name, string description, string tooltip, LevelTip levelTip, int maxRank, List<int> cooldown, string cooldownBurn, List<int> cost, string costBurn, string dataValues, List<List<float>> effect, List<string> effectBurn, List<Chompers.Chompers.Var> vars, string costType, string maxAmmo, List<int> range, string rangeBurn, Image image, string resource) {
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
		
		public static Spell parseSpellJSON(JSONNode spellJSON) {
			LevelTip levelTip = LevelTip.parseLevelTipJSON(spellJSON["leveltip"]);
			
			// TODO: Fix below
			List<List<float>> effect = new List<List<float>>();
			for (int i = 0; i < effect.Count; i++) {
				effect.Add(Chompers.Chompers.parseFloatArrayJSON(spellJSON["effect"][i].AsArray));
			}

			List<Chompers.Chompers.Var> vars = new List<Chompers.Chompers.Var>();
			foreach (JSONNode varJSON in spellJSON["vars"]) {
				vars.Add(new Chompers.Chompers.Var(varJSON["link"], varJSON["coeff"], varJSON["key"]));
			}
			// TODO: Fix above
			
			Image image = Image.ParseImageJson(spellJSON["image"]);
			
			return new Spell(spellJSON["id"], spellJSON["name"], spellJSON["description"], spellJSON["tooltip"], 
				levelTip, spellJSON["maxRank"], Chompers.Chompers.parseIntArrayJSON(spellJSON["cooldown"].AsArray), spellJSON["cooldwonBurn"], 
				Chompers.Chompers.parseIntArrayJSON(spellJSON["cost"].AsArray), spellJSON["costBurn"], spellJSON["dataValues"], effect,
				Chompers.Chompers.parseStringArrayJSON(spellJSON["effectBurn"].AsArray), vars, spellJSON["costType"], spellJSON["maxAmmo"], 
				Chompers.Chompers.parseIntArrayJSON(spellJSON["range"].AsArray), spellJSON["rangeBurn"], image, spellJSON["resource"]);
		}

		public static List<Spell> parseSpellsJSON(JSONNode json) {
			List<Spell> spells = new List<Spell>();
			foreach (JSONNode spellJSON in json) {
				spells.Add(parseSpellJSON(spellJSON));
			}

			return spells;
		}
		
	}
}