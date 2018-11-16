using System.Collections;
using System.Collections.Generic;
using Jhinx.Jhin;
using SimpleJSON;
using UnityEngine;
using UnityEngine.Networking;

namespace Jhinx.Chompers {
	public class Fetcher {
		public static IEnumerator getDataDragonData(System.Action<JSONNode> callback, string patchNumber, string languageCode, string dataType) {
			using (UnityWebRequest www = UnityWebRequest.Get("https://ddragon.leagueoflegends.com/cdn/" + patchNumber + "/data/" + languageCode + "/" + dataType + ".json")) {
				yield return www.Send();
				if (www.isNetworkError || www.isHttpError) {
					Debug.Log(www.error);
					callback(null);
				} else {
					JSONNode json = JSON.Parse(www.downloadHandler.text);
					callback(json);
				}
			}
		}
	}
}