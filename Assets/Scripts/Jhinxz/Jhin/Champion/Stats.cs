// ReSharper disable All

using SimpleJSON;

namespace Jhinxz.Jhin.Champion {
	public class Stats {
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
		
		public Stats(float hp, float hpPerLevel, float mp, float mpPerLevel, float moveSpeed, float armor, float armorPerLevel, float spellblock, float spellblockPerLevel, float attackRange, float hpRegen, float hpRegenPerLevel, float mpRegen, float mpRegenPerLevel, float crit, float critPerLevel, float attackDamage, float attackDamagePerLevel, float attackSpeedPerLevel) {
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
		
		public static Stats parseStatsJSON(JSONNode statsJSON) {
			return new Stats(statsJSON["hp"], statsJSON["hpperlevel"], statsJSON["mp"], statsJSON["mpperlevel"], 
				statsJSON["movespeed"], statsJSON["armor"], statsJSON["armorperlevel"], statsJSON["spellblock"],
				statsJSON["spellblockperlevel"], statsJSON["attackrange"], statsJSON["hpregen"], statsJSON["hpregenperlevel"],
				statsJSON["mpregen"], statsJSON["mpregenperlevel"], statsJSON["crit"], statsJSON["critperlevel"], 
				statsJSON["attackdamage"], statsJSON["attackdamageperlevel"], statsJSON["attackspeedperlevel"]);
		}
	}
}