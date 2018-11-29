using System.Collections;
using System.Collections.Generic;
using Jhinx.Chompers;
using SimpleJSON;
using UnityEngine;
using UnityEngine.Networking;

// ReSharper disable All

namespace Jhinx.Jhin.MissionAsset {
	public class MissionAsset {
		public string MissionId { get; set; }
		public int Id { get; set; }
		public Image Image { get; set; }
		
		public MissionAsset(string missionId, int id, Image image) {
			MissionId = missionId;
			Id = id;
			Image = image;
		}
		
		private static MissionAsset parseMissionAssetJSON(JSONNode missionAssetJSON, string eventId) {
			Image image = new Image(Chompers.Image.ParseImageJson(missionAssetJSON["image"]));
			return new MissionAsset(eventId, missionAssetJSON["id"], image);
		}

		private static List<MissionAsset> parseMissionAssetsJSON(JSONNode json) {
			List<MissionAsset> missionAssets = new List<MissionAsset>();
			foreach (string eventId in json.Keys) {
				missionAssets.Add(parseMissionAssetJSON(json["data"][eventId], eventId));
			}

			return missionAssets;
		}
		
		public static IEnumerator getMissionAssets(string patchNumber, string languageCode) {
			using (UnityWebRequest www = UnityWebRequest.Get("https://ddragon.leagueoflegends.com/cdn/" + patchNumber + "/data/" + languageCode + "/mission-assets.json")) {
				yield return www.Send();
				if (www.isNetworkError || www.isHttpError) {
					Debug.Log(www.error);
					yield return null;
				} else {
					JSONNode missionAssetsJSON = JSON.Parse(www.downloadHandler.text)["data"];					
					yield return parseMissionAssetsJSON(missionAssetsJSON);                       
				}
			}
		}
	}
}