using System.Collections;
using System.Collections.Generic;
using Jhinx.Chompers;
using Jhinx.Jhin;
using Jhinx.Jhin.Champion;
using Jhinx.Jhin.Map;
using Jhinx.Jhin.Mastery;
using Jhinx.Jhin.MissionAsset;
using Jhinx.Jhin.ProfileIcon;
using Jhinx.Jhin.RuneReforged;
using Jhinx.Jhin.Sticker;
using Jhinx.Jinx;
using UnityEngine;
using Item = Jhinx.Jhin.Item.Item;
using Rune = Jhinx.Jhin.Rune.Rune;

// ReSharper disable All

public class Test : MonoBehaviour {
	
	// 1) Uncomment
	// 2) ???
	// 3) $$$
	private void Start() {
		//StartCoroutine(GetRunes());
		//StartCoroutine(GetItems());
		//StartCoroutine(GetMasteries());
		//StartCoroutine(GetRunesReforged());
		//StartCoroutine(GetSummoners());
		//StartCoroutine(GetStickers());
		//StartCoroutine(GetMaps());
		//StartCoroutine(GetMissionAssets());
		//StartCoroutine(GetProfileIcons());
		StartCoroutine(GetChampions());
		//StartCoroutine(GetChampion("Aatrox"));	
	}

	IEnumerator GetRunes() {
		CoroutineWithData cd = new CoroutineWithData(this, Rune.getRunes("6.24.1", "en_US"));
		yield return cd.coroutine;
		List<Rune> runes = (List<Rune>)cd.result;

		foreach (Rune rune in runes) {
			Debug.Log(rune.Name);
		}
		Debug.Log("=============================");
	}
	
	IEnumerator GetItems() {
		CoroutineWithData cd = new CoroutineWithData(this, Item.getItems("8.22.1", "en_US"));
		yield return cd.coroutine;
		List<Item> items = (List<Item>)cd.result;

		foreach (Item item in items) {
			Debug.Log(item.Name);
		}
		Debug.Log("=============================");
	}
	
	IEnumerator GetMasteries() {
		CoroutineWithData cd = new CoroutineWithData(this, Masteries.getMasteries("5.18.1", "en_US"));
		yield return cd.coroutine;
		Masteries masteries = (Masteries)cd.result;

		foreach (Mastery mastery in masteries._Masteries) {
			Debug.Log(mastery.Name);
		}
		Debug.Log("=============================");
	}
	
	IEnumerator GetRunesReforged() {
		CoroutineWithData cd = new CoroutineWithData(this, RuneReforged.getRunesReforged("8.23.1", "en_US"));
		yield return cd.coroutine;
		List<RuneReforged> runesReforged = (List<RuneReforged>)cd.result;

		foreach (RuneReforged rune in runesReforged) {
			Debug.Log(rune.Name);
		}
		Debug.Log("=============================");
	}
	
	IEnumerator GetSummoners() {
		CoroutineWithData cd = new CoroutineWithData(this, SummonerSpell.getSummonerSpells("7.20.1", "en_US"));
		yield return cd.coroutine;
		List<SummonerSpell> summonerSpells = (List<SummonerSpell>)cd.result;

		foreach (SummonerSpell summonerSpell in summonerSpells) {
			Debug.Log(summonerSpell.Name);
		}
		Debug.Log("=============================");
	}
	
	IEnumerator GetStickers() {
		CoroutineWithData cd = new CoroutineWithData(this, Sticker.getStickers("7.20.1", "en_US"));
		yield return cd.coroutine;
		List<Sticker> stickers = (List<Sticker>)cd.result;

		foreach (Sticker sticker in stickers) {
			Debug.Log(sticker.Id);
		}
		Debug.Log("=============================");
	}
	
	IEnumerator GetMaps() {
		CoroutineWithData cd = new CoroutineWithData(this, Map.getMaps("7.20.1", "en_US"));
		yield return cd.coroutine;
		List<Map> maps = (List<Map>)cd.result;

		foreach (Map map in maps) {
			Debug.Log(map.MapName);
		}
		Debug.Log("=============================");
	}

	IEnumerator GetMissionAssets() {
		CoroutineWithData cd = new CoroutineWithData(this, MissionAsset.getMissionAssets("8.23.1", "en_US"));
		yield return cd.coroutine;
		List<MissionAsset> missionAssets = (List<MissionAsset>)cd.result;
		Debug.Log(missionAssets);

		foreach (MissionAsset missionAsset in missionAssets) {
			Debug.Log(missionAsset.Id);
		}
		Debug.Log("=============================");
	}
	
	IEnumerator GetProfileIcons() {
		CoroutineWithData cd = new CoroutineWithData(this, ProfileIcon.getProfileIcons("7.20.1", "en_US"));
		yield return cd.coroutine;
		List<ProfileIcon> profileIcons = (List<ProfileIcon>)cd.result;

		foreach (ProfileIcon profileIcon in profileIcons) {
			Debug.Log(profileIcon.Id);
		}
		Debug.Log("=============================");
	}
	
	IEnumerator GetChampions() {
		CoroutineWithData cd = new CoroutineWithData(this, Champion.getChampions("8.1.1", "en_US"));
		yield return cd.coroutine;
		List<Champion> champions = (List<Champion>)cd.result;

		foreach (Champion champion in champions) {
			Debug.Log(champion.Name);
		}
		Debug.Log("=============================");
	}
	
	IEnumerator GetChampion(string championId) {
		CoroutineWithData cd = new CoroutineWithData(this, Champion.getChampion("8.1.1", "en_US", championId));
		yield return cd.coroutine;
		Champion champion = (Champion)cd.result;
		Debug.Log(champion.Id);	
		Debug.Log("=============================");
	}
  
}
