using System.Collections;
using System.Collections.Generic;
using SimpleJSON;
using UnityEngine;
using UnityEngine.Networking;
// ReSharper disable All

namespace Jhinxz.Chompers {
	public class Chompers {
		public static string DATA_DRAGON_BASE_URL = "https://ddragon.leagueoflegends.com";
		
		public static IEnumerator getVersions() {
			using (UnityWebRequest www = UnityWebRequest.Get("https://ddragon.leagueoflegends.com/api/versions.json")) {
				yield return www.Send();
				if (www.isNetworkError || www.isHttpError) {
					Debug.Log(www.error);
					yield return null;
				} else {
					JSONArray versionsJSON = JSON.Parse(www.downloadHandler.text).AsArray;

					List<string> versions = new List<string>();

					foreach (JSONString version in versionsJSON) {
						versions.Add(version);
					}

					yield return versions;
				}
			}
		}
		
		public static IEnumerator getLanguageCodes() {
			using (UnityWebRequest www = UnityWebRequest.Get("http://ddragon.leagueoflegends.com/cdn/languages.json")) {
				yield return www.Send();
				if (www.isNetworkError || www.isHttpError) {
					Debug.Log(www.error);
					yield return null;
				} else {
					JSONArray languagesJSON = JSON.Parse(www.downloadHandler.text).AsArray;
					List<string> languages = new List<string>();

					foreach (JSONString language in languagesJSON) {
						languages.Add(language);
					}

					yield return languages;
				}
			}
		}
		
		public static IEnumerator getLanguageItems(string version, string languageCode) {
			using (UnityWebRequest www = UnityWebRequest.Get("http://ddragon.leagueoflegends.com/cdn/" + version + "/data/" + languageCode + "/languages.json")) {
				yield return www.Send();
				if (www.isNetworkError || www.isHttpError) {
					Debug.Log(www.error);
					yield return null;
				} else {
					JSONNode languageItemsJSON = JSON.Parse(www.downloadHandler.text)["data"];
					Dictionary<string, string> languageItems = new Dictionary<string, string>();

					foreach (JSONString languageItem in languageItemsJSON) {
						languageItems.Add(languageItem, languageItemsJSON[languageItem.Value]);
					}

					yield return languageItems;
				}
			}
		}


		public struct Realm {
			public N n { get; set; }
			public string v { get; set; }
			public string l { get; set; }
			public string cdn { get; set; }
			public string dd { get; set; }
			public string lg { get; set; }
			public string css { get; set; }
			public int profileIconMax { get; set; }

			public struct N {
				public string item { get; set; }
				public string rune { get; set; }
				public string mastery { get; set; }
				public string summoner { get; set; }
				public string champion { get; set; }
				public string profileIcon { get; set; }
				public string map { get; set; }
				public string language { get; set; }
				public string sticker { get; set; }
			}
		}
		
		public struct Var {
			public string Link { get; set; }
			public float Coeff { get; set; }
			public string Key { get; set; }
		
			public Var(string link, float coeff, string key) {
				Link = link;
				Coeff = coeff;
				Key = key;
			}
		}
		
		public static IEnumerator getLanguageRealmInfo(string realm) {
			using (UnityWebRequest www = UnityWebRequest.Get("https://ddragon.leagueoflegends.com/realms/" + realm + ".json")) {
				yield return www.Send();
				if (www.isNetworkError || www.isHttpError) {
					Debug.Log(www.error);
					yield return null;
				} else {
					JSONNode realmInfoJSON = JSON.Parse(www.downloadHandler.text);
					
					// Convert
					// ex: https://ddragon.leagueoflegends.com/realms/na.json
					
					yield return realmInfoJSON;
				}
			}
		}
		
		public static IEnumerator getStreamToken() {
			using (UnityWebRequest www = UnityWebRequest.Get("https://api.lolesports.com/api/issueToken")) {
				yield return www.Send();
				if (www.isNetworkError || www.isHttpError) {
					Debug.Log(www.error);
					yield return null;
				} else {
					JSONNode tokenJSON = JSON.Parse(www.downloadHandler.text);
					yield return tokenJSON["token"];
				}
			}
		}
		
		public static string GenerateChampionSquareImageURL(string version, string championId) {
			return DATA_DRAGON_BASE_URL + "/cdn/" + version + "/img/champion/" + championId + ".png";
		}

		public static string GenerateChampionLoadingImageURL(string championId, int skinNum) {
			return DATA_DRAGON_BASE_URL + "/cdn/img/champion/loading/" + championId + "_" + skinNum + ".jpg";
		}
		
		public static string GenerateChampionSplashImageURL(string championId, int skinNum) {
			return DATA_DRAGON_BASE_URL + "/cdn/img/champion/splash/" + championId + "_" + skinNum + ".jpg";
		}
		
		public static string GenerateChampionTileImageURL(string championId, int skinNum) {
			return  DATA_DRAGON_BASE_URL + "/cdn/img/champion/tiles/" + championId + "_" + skinNum + ".jpg";
		}
		
		public static string GenerateItemImageURL(string version, string fileName) {
			return  DATA_DRAGON_BASE_URL + "/cdn/" + version + "/img/item/" + fileName;
		}
		
		public static string GenerateMapImageURL(string version, string fileName) {
			return  DATA_DRAGON_BASE_URL + "/cdn/" + version + "/img/map/" + fileName;
		}

		public static string GenerateMissionImageURL(string version, string fileName) {
			return  DATA_DRAGON_BASE_URL + "/cdn/" + version + "/img/mission/" + fileName;
		}
		
		public static string GeneratePassiveImageURL(string version, string fileName) {
			return  DATA_DRAGON_BASE_URL + "/cdn/" + version + "/img/passive/" + fileName;
		}
		
		public static string GenerateProfileIconImageURL(string version, string fileName) {
			return  DATA_DRAGON_BASE_URL + "/cdn/" + version + "/img/profileicon/" + fileName;
		}
		
		public static string GenerateSpellImageURL(string version, string fileName) {
			return  DATA_DRAGON_BASE_URL + "/cdn/" + version + "/img/spell/" + fileName;
		}
		
		public static string GenerateRuneImageURL(string version, string fileName) {
			return  DATA_DRAGON_BASE_URL + "/cdn/" + version + "/img/rune/" + fileName;
		}
		
		public static string GenerateMasteryImageURL(string version, string fileName) {
			return  DATA_DRAGON_BASE_URL + "/cdn/" + version + "/img/mastery/" + fileName;
		}
		
		public static string GenerateSpriteURL(string version, string fileName) {
			return  DATA_DRAGON_BASE_URL + "/cdn/" + version + "/img/sprite/" + fileName;
		}	
		
		public static string GenerateSmallSpriteURL(string version, string fileName) {
			return  DATA_DRAGON_BASE_URL + "/cdn/" + version + "/img/sprite/small_" + fileName;
		}
		
		public static string GenerateTinySpriteURL(string version, string fileName) {
			return  DATA_DRAGON_BASE_URL + "/cdn/" + version + "/img/sprite/tiny_" + fileName;
		}
		
		public static string GenerateStickerImageURL(string version, string fileName) {
			return  DATA_DRAGON_BASE_URL + "/cdn/" + version + "/img/sticker/" + fileName;
		}

		public static string GenerateRunesReforgedImageURL(string fileName) {
			return  DATA_DRAGON_BASE_URL + "/cdn/img/" + fileName;
		}


		public static List<string> parseStringArrayJSON(JSONArray json) {
			if (json == null) {
				return null;
			}
			
			List<string> listToReturn = new List<string>();
			for (int i = 0; i < json.Count; i++) {
				listToReturn.Add(json[i].Value);
			}

			return listToReturn;
		}
		
		public static List<int> parseIntArrayJSON(JSONArray json) {
			List<int> listToReturn = new List<int>();
			foreach (JSONNumber value in json) {
				listToReturn.Add(value);
			}
			return listToReturn;
		}
		
		public static List<float> parseFloatArrayJSON(JSONArray json) {
			if (json == null) {
				return null;
			}
			
			List<float> listToReturn = new List<float>();
			for (int i = 0; i < json.Count; i++) {
				listToReturn.Add(json[i].AsFloat);
			}
			return listToReturn;
		}

		public static Dictionary<string, float> parseStringFloatDictionaryJSON(JSONNode json) {
			Dictionary<string, float> dictToReturn = new Dictionary<string, float>();
			foreach (string key in json.Keys) {
				dictToReturn.Add(key, json[key]);
			}

			return dictToReturn;
		}
		
		public static Dictionary<string, string> parseStringStringDictionaryJSON(JSONNode json) {
			Dictionary<string, string> dictToReturn = new Dictionary<string, string>();
			foreach (string key in json.Keys) {
				dictToReturn.Add(key, json[key]);
			}

			return dictToReturn;
		}
	}
}