using System.Collections;
using System.Collections.Generic;
using SimpleJSON;
using UnityEngine;
using UnityEngine.Networking;
// ReSharper disable All

namespace Jhinxz.Jhin.RuneReforged {
	public class RuneReforged {
		public int Id { get; set; }
		public string Key { get; set; }
		public string Icon { get; set; }
		public string Name { get; set; }
		public List<List<Rune>> Slots { get; set; }	
		
		public RuneReforged(int id, string key, string icon, string name, List<List<Rune>> slots) {
			Id = id;
			Key = key;
			Icon = icon;
			Name = name;
			Slots = slots;
		}
		
		private static RuneReforged parseRuneReforgedJSON(JSONNode json) {
			List<List<Rune>> slots = new List<List<Rune>>();
			foreach (JSONNode runesArray in json["slots"]) {
				slots.Add(Rune.parseRunesJSON(runesArray["runes"].AsArray));
			}
			
			return new RuneReforged(json["id"], json["key"], json["icon"], json["name"], slots);
		}

		public static List<RuneReforged> parseRunesReforgedJSON(JSONNode json) {
			List<RuneReforged> runesReforged = new List<RuneReforged>();
			foreach (JSONNode runeReforgedJSON in json.Keys) {
				runesReforged.Add(parseRuneReforgedJSON(runeReforgedJSON));
			}

			return runesReforged;
		}

		public static IEnumerator getRunesReforged(string patchNumber, string languageCode) {
			using (UnityWebRequest www = UnityWebRequest.Get("https://ddragon.leagueoflegends.com/cdn/" + patchNumber + "/data/" + languageCode + "/runesReforged.json")) {
				yield return www.Send();
				if (www.isNetworkError || www.isHttpError) {
					Debug.Log(www.error);
					yield return null;
				} else {
					JSONNode runesReforgedJSON = JSON.Parse(www.downloadHandler.text);
					List<RuneReforged> runesReforged = parseRunesReforgedJSON(runesReforgedJSON["data"]);
					yield return runesReforged;
				}
			}
		}
	}

}