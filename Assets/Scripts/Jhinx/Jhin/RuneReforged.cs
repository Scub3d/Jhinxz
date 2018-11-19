using System.Collections;
using System.Collections.Generic;
using SimpleJSON;
using UnityEngine;
using UnityEngine.Networking;
// ReSharper disable All

namespace Jhinx.Jhin {
	public class RuneReforged {
		public int Id { get; set; }
		public string Key { get; set; }
		public string Icon { get; set; }
		public string Name { get; set; }
		public List<List<RuneReforgedRune>> Slots { get; set; }	
		
		public RuneReforged(int id, string key, string icon, string name, List<List<RuneReforgedRune>> slots) {
			Id = id;
			Key = key;
			Icon = icon;
			Name = name;
			Slots = slots;
		}
		
		private static RuneReforged parseRuneReforgedJSON(JSONNode runeReforgedJSON) {
			List<List<RuneReforgedRune>> slots = new List<List<RuneReforgedRune>>();
			foreach (JSONNode runesArray in runeReforgedJSON["slots"]) {
				List<RuneReforgedRune> runes = new List<RuneReforgedRune>();
				foreach (JSONNode runeJSON in runesArray["runes"]) {
					runes.Add(new RuneReforgedRune(runeJSON["id"], runeJSON["key"], runeJSON["icon"], runeJSON["name"], runeJSON["shortDesc"], runeJSON["longDesc"]));
				}
				slots.Add(runes);
			}
			
			return new RuneReforged(runeReforgedJSON["id"], runeReforgedJSON["key"], runeReforgedJSON["icon"], 
				runeReforgedJSON["name"], slots);
		}

		public static IEnumerator getRunesReforged(string patchNumber, string languageCode) {
			using (UnityWebRequest www = UnityWebRequest.Get("https://ddragon.leagueoflegends.com/cdn/" + patchNumber + "/data/" + languageCode + "/runesReforged.json")) {
				yield return www.Send();
				if (www.isNetworkError || www.isHttpError) {
					Debug.Log(www.error);
					yield return null;
				} else {
					JSONNode runesReforgedJSON = JSON.Parse(www.downloadHandler.text);

					List<RuneReforged> runesReforged = new List<RuneReforged>();
					foreach (JSONNode runeReforgedJSON in runesReforgedJSON["data"].Keys) {
						runesReforged.Add(parseRuneReforgedJSON(runeReforgedJSON));
					}

					yield return runesReforged;
				}
			}
		}
	}

	public struct RuneReforgedRune {
		public int Id { get; set; }
		public string Key { get; set; }
		public string Icon { get; set; }
		public string Name { get; set; }
		public string ShortDesc { get; set; }
		public string LongDesc { get; set; }
		
		public RuneReforgedRune(int id, string key, string icon, string name, string shortDesc, string longDesc) {
			Id = id;
			Key = key;
			Icon = icon;
			Name = name;
			ShortDesc = shortDesc;
			LongDesc = longDesc;
		}
	}
}