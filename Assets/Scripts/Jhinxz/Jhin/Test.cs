using System.Collections;
using System.Collections.Generic;
using Jhinxz.Chompers;
using UnityEngine;
// ReSharper disable All


namespace Jhinxz.Jhin {
	public class Test : MonoBehaviour {
		private void Start() {
			StartCoroutine(GetRunes());
			StartCoroutine(GetItems());
			StartCoroutine(GetMasteries());
			StartCoroutine(GetRunesReforged());
			StartCoroutine(GetSummoners());
			StartCoroutine(GetStickers());
			StartCoroutine(GetMaps());
			StartCoroutine(GetMissionAssets());
			StartCoroutine(GetProfileIcons());
			StartCoroutine(GetChampions());
			StartCoroutine(GetChampion("Aatrox"));	
		}
	
		IEnumerator GetRunes() {
			CoroutineWithData cd = new CoroutineWithData(this, Rune.Rune.getRunes("6.24.1", "en_US"));
			yield return cd.coroutine;
			List<Rune.Rune> runes = (List<Rune.Rune>)cd.result;
	
			foreach (Rune.Rune rune in runes) {
				Debug.Log(rune.Name);
			}
			Debug.Log("=============================");
		}
		
		IEnumerator GetItems() {
			CoroutineWithData cd = new CoroutineWithData(this, Item.Item.getItems("8.22.1", "en_US"));
			yield return cd.coroutine;
			List<Item.Item> items = (List<Item.Item>)cd.result;
	
			foreach (Item.Item item in items) {
				Debug.Log(item.Name);
			}
			Debug.Log("=============================");
		}
		
		IEnumerator GetMasteries() {
			CoroutineWithData cd = new CoroutineWithData(this, Mastery.Masteries.getMasteries("5.18.1", "en_US"));
			yield return cd.coroutine;
			Mastery.Masteries masteries = (Mastery.Masteries)cd.result;
	
			foreach (Mastery.Mastery mastery in masteries._Masteries) {
				Debug.Log(mastery.Name);
			}
			Debug.Log("=============================");
		}
		
		IEnumerator GetRunesReforged() {
			CoroutineWithData cd = new CoroutineWithData(this, RuneReforged.RuneReforged.getRunesReforged("8.23.1", "en_US"));
			yield return cd.coroutine;
			List<RuneReforged.RuneReforged> runesReforged = (List<RuneReforged.RuneReforged>)cd.result;
	
			foreach (RuneReforged.RuneReforged rune in runesReforged) {
				Debug.Log(rune.Name);
			}
			Debug.Log("=============================");
		}
		
		IEnumerator GetSummoners() {
			CoroutineWithData cd = new CoroutineWithData(this, SummonerSpell.SummonerSpell.getSummonerSpells("7.20.1", "en_US"));
			yield return cd.coroutine;
			List<SummonerSpell.SummonerSpell> summonerSpells = (List<SummonerSpell.SummonerSpell>)cd.result;
	
			foreach (SummonerSpell.SummonerSpell summonerSpell in summonerSpells) {
				Debug.Log(summonerSpell.Name);
			}
			Debug.Log("=============================");
		}
		
		IEnumerator GetStickers() {
			CoroutineWithData cd = new CoroutineWithData(this, Sticker.Sticker.getStickers("7.20.1", "en_US"));
			yield return cd.coroutine;
			List<Sticker.Sticker> stickers = (List<Sticker.Sticker>)cd.result;
	
			foreach (Sticker.Sticker sticker in stickers) {
				Debug.Log(sticker.Image.Full);
			}
			Debug.Log("=============================");
		}
		
		IEnumerator GetMaps() {
			CoroutineWithData cd = new CoroutineWithData(this, Map.Map.getMaps("7.20.1", "en_US"));
			yield return cd.coroutine;
			List<Map.Map> maps = (List<Map.Map>)cd.result;
	
			foreach (Map.Map map in maps) {
				Debug.Log(map.MapName);
			}
			Debug.Log("=============================");
		}
	
		IEnumerator GetMissionAssets() {
			CoroutineWithData cd = new CoroutineWithData(this, MissionAsset.MissionAsset.getMissionAssets("8.23.1", "en_US"));
			yield return cd.coroutine;
			List<MissionAsset.MissionAsset> missionAssets = (List<MissionAsset.MissionAsset>)cd.result;
			Debug.Log(missionAssets);
	
			foreach (MissionAsset.MissionAsset missionAsset in missionAssets) {
				Debug.Log(missionAsset.MissionId);
			}
			Debug.Log("=============================");
		}
		
		IEnumerator GetProfileIcons() {
			CoroutineWithData cd = new CoroutineWithData(this, ProfileIcon.ProfileIcon.getProfileIcons("7.20.1", "en_US"));
			yield return cd.coroutine;
			List<ProfileIcon.ProfileIcon> profileIcons = (List<ProfileIcon.ProfileIcon>)cd.result;
	
			foreach (ProfileIcon.ProfileIcon profileIcon in profileIcons) {
				Debug.Log(profileIcon.Id);
			}
			Debug.Log("=============================");
		}
		
		IEnumerator GetChampions() {
			CoroutineWithData cd = new CoroutineWithData(this, Champion.Champion.getChampions("8.1.1", "en_US"));
			yield return cd.coroutine;
			List<Champion.Champion> champions = (List<Champion.Champion>)cd.result;
	
			foreach (Champion.Champion champion in champions) {
				Debug.Log(champion.Name);
			}
			Debug.Log("=============================");
		}
		
		IEnumerator GetChampion(string championId) {
			CoroutineWithData cd = new CoroutineWithData(this, Champion.Champion.getChampion("8.1.1", "en_US", championId));
			yield return cd.coroutine;
			Champion.Champion champion = (Champion.Champion)cd.result;
			Debug.Log(champion.Id);	
			Debug.Log("=============================");
		}
	}
}