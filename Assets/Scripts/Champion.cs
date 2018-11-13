using System.Collections.Generic;

namespace APIv2 {
	public class Champion {
		private List<string> allyTips, enemyTips, tags;
		private string name, blurb, lore;
		public string ImageUrl { get; }
		private string parType, title;
		private int id, attack, defense, difficulty, magic;
		private ChampionStats stats;
		private List<ChampionSkin> skins;
		private List<ChampionSpell> spells;
		private ChampionPassive passive;
		// id <==> key
		public Champion(List<string> allyTips, List<string> enemyTips, List<string> tags, string name, string blurb, string lore, string imageUrl, string parType, string title, int id, int attack, int defense, int difficulty, int magic, ChampionStats stats, List<ChampionSkin> skins, List<ChampionSpell> spells, ChampionPassive passive) {
			this.allyTips = allyTips;
			this.enemyTips = enemyTips;
			this.tags = tags;
			this.name = name;
			this.blurb = blurb;
			this.lore = lore;
			this.ImageUrl = imageUrl;
			this.parType = parType;
			this.title = title;
			this.id = id;
			this.attack = attack;
			this.defense = defense;
			this.difficulty = difficulty;
			this.magic = magic;
			this.stats = stats;
			this.skins = skins;
			this.spells = spells;
			this.passive = passive;
		}
	}

	public struct ChampionSkin {
		private int id, num;
		private string loadingImageURL, splashImageURL, name;
		private bool hasChromas;
	}

	public struct ChampionPassive {
		private string name, description, imageURL;
	}

	public struct ChampionSpell {
		private string name,
			rangeBurn,
			description,
			costBurn,
			cooldownBurn,
			costType,
			id,
			imageURL,
			levelTipLabel,
			tooltip;
		private int maxAmmo, maxRank;
	}

	public struct ChampionStats {
		private float armor,
			armorPerLevel,
			attackDamage,
			attackDamagePerLevel,
			attackRange,
			attackSpeedPerLevel,
			crit,
			critPerLevel,
			hp,
			hpPerLevel,
			hpRegen,
			hpRegenPerLevel,
			moveSpeed,
			mp,
			mpPerLevel,
			mpRegen,
			mpRegenPerLevel,
			spellBlock,
			spellBlockPerLevel;
	}
}