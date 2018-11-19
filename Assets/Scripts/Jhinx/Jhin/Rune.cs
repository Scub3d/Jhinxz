using System.Collections;
using System.Collections.Generic;
using Jhinx.Chompers;
using SimpleJSON;
using UnityEngine;
using UnityEngine.Networking;

// ReSharper disable All

namespace Jhinx.Jhin {
	public class Rune {
		public int Id { get; set; }
		public string Name { get; set; }
		public Image Image { get; set; }
		public string Tier { get; set; }
		public string Type { get; set; }
		public Dictionary<string, float> Stats { get; set; }
		public List<string> Tags { get; set; }
		public string Colloq { get; set; } // Always null?
		public string Plaintext { get; set; } // Always null?
		
		public Rune(int id, string name, Image image, string tier, string type, Dictionary<string, float> stats, List<string> tags, string colloq, string plaintext) {
			Id = id;
			Name = name;
			Image = image;
			Tier = tier;
			Type = type;
			Stats = stats;
			Tags = tags;
			Colloq = colloq;
			Plaintext = plaintext;
		}
		
		private static Rune parseRuneJSON(JSONNode runeJSON, int runeId) {
			Chompers.Image image = Image.ParseImageJson(runeJSON["image"]);
			
			return new Rune(runeId, runeJSON["name"], image, runeJSON["tier"], runeJSON["type"], 
				Chompers.Chompers.parseStatsDictionaryJSON(runeJSON["stats"]), 
				Chompers.Chompers.parseStringArrayJSON(runeJSON["tags"].AsArray), runeJSON["colloq"], runeJSON["plaintext"]);
		}

		public static IEnumerator getRunes(string patchNumber, string languageCode) {
			using (UnityWebRequest www = UnityWebRequest.Get("https://ddragon.leagueoflegends.com/cdn/" + patchNumber + "/data/" + languageCode + "/rune.json")) {
				yield return www.Send();
				if (www.isNetworkError || www.isHttpError) {
					Debug.Log(www.error);
					yield return null;
				} else {
					JSONNode runesJSON = JSON.Parse(www.downloadHandler.text);

					List<Rune> runes = new List<Rune>();
					foreach (string runeId in runesJSON["data"].Keys) {
						runes.Add(parseRuneJSON(runesJSON["data"][runeId], int.Parse(runeId)));
					}

					yield return runes;
				}
			}
		}
		
		// Todo .... what?
	}
}