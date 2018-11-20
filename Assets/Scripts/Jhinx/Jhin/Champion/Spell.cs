using System.Collections.Generic;
using Jhinx.Chompers;
// ReSharper disable All

namespace Jhinx.Jhin.Champion {
	public class Spell {
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
		public List<Chompers.Chompers.Var> Vars { get; set; }
		public string CostType { get; set; }
		public string MaxAmmo { get; set; }
		public List<int> Range { get; set; }
		public string RangeBurn { get; set; }
		public Image Image { get; set; }
		public string Resource { get; set; }

		public Spell(string id, string name, string description, string tooltip, ChampionSpellLevelTip levelTip, int maxRank, List<int> cooldown, string cooldownBurn, List<int> cost, string costBurn, string dataValues, List<List<float>> effect, List<string> effectBurn, List<Chompers.Chompers.Var> vars, string costType, string maxAmmo, List<int> range, string rangeBurn, Image image, string resource) {
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
}