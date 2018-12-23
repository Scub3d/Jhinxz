using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using Jhinxz.Chompers;
using SimpleJSON;
using UnityEngine;
using UnityEngine.Networking;
// ReSharper disable All

namespace Jhinxz.Jhin.Map {
	public class Map {
		public int MapName { get; set; }
		public int MapId { get; set; }
		public Image Image { get; set; }
		
		public Map(int mapName, int mapId, Image image) {
			MapName = mapName;
			MapId = mapId;
			Image = image;
		}
		
		private static Map parseMapJSON(JSONNode mapJSON) {
			Image image = new Image(Chompers.Image.ParseImageJson(mapJSON["image"]));
			return new Map(mapJSON["MapName"], mapJSON["MapId"], image);
		}
		
		public static IEnumerator getMaps(string patchNumber, string languageCode) {
			using (UnityWebRequest www = UnityWebRequest.Get("https://ddragon.leagueoflegends.com/cdn/" + patchNumber + "/data/" + languageCode + "/map.json")) {
				yield return www.Send();
				if (www.isNetworkError || www.isHttpError) {
					Debug.Log(www.error);
					yield return null;
				} else {
					List<Map> maps = new List<Map>();
					JSONNode mapsJSON = JSON.Parse(www.downloadHandler.text)["data"];
					foreach (JSONNode mapJSON in mapsJSON) {
						maps.Add(parseMapJSON(mapJSON));
					}
					yield return maps;                       
				}
			}
		}
		
	}
}