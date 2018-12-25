using System.Collections;
using SimpleJSON;
using UnityEngine;
using UnityEngine.Networking;
// ReSharper disable All

namespace Jhinxz.Willump {
	public class Stream {
		// Put data structure thoughts here
		// Will do this when the NA LCS resumes
		
		// Gets the token needed to access the websocket
		public static IEnumerator getStreamToken() {
			using (UnityWebRequest www = UnityWebRequest.Get("https://api.lolesports.com/api/issueToken")) {
				yield return www.Send();
				if (www.isNetworkError || www.isHttpError) {
					Debug.Log(www.error);
					yield return null;
				} else {
					JSONNode tokenJSON = JSON.Parse(www.downloadHandler.text);
					yield return tokenJSON["token"].Value;
				}
			}
		}
	}
}