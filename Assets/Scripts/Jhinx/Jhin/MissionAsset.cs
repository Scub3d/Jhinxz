using System.Collections;
using System.Collections.Generic;
using Jhinx.Chompers;
using SimpleJSON;
using UnityEngine;
using UnityEngine.Networking;

// ReSharper disable All

namespace Jhinx.Jhin {
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
		
		public static IEnumerator getMaps(string patchNumber, string languageCode) {
			using (UnityWebRequest www = UnityWebRequest.Get("https://ddragon.leagueoflegends.com/cdn/" + patchNumber + "/data/" + languageCode + "/mission-asset.json")) {
				yield return www.Send();
				if (www.isNetworkError || www.isHttpError) {
					Debug.Log(www.error);
					yield return null;
				} else {
					List<MissionAsset> missionAssets = new List<MissionAsset>();
					JSONNode missionAssetsJSON = JSON.Parse(www.downloadHandler.text)["data"];
					foreach (string eventId in missionAssetsJSON.Keys) {
						missionAssets.Add(parseMissionAssetJSON(missionAssetsJSON["data"][eventId], eventId));
					}
					yield return missionAssets;                       
				}
			}
		}
	}
}