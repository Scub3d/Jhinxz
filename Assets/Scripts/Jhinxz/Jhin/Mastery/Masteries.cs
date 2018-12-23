using System.Collections;
using System.Collections.Generic;
using SimpleJSON;
using UnityEngine;
using UnityEngine.Networking;

// ReSharper disable All

// TODO: This is all a bit fucky
namespace Jhinxz.Jhin.Mastery {
	public class Masteries {
		public List<Mastery> _Masteries { get; set; }
		public Tree Tree { get; set; }
		
		public Masteries(List<Mastery> masteries, Tree tree) {
			_Masteries = masteries;
			Tree = tree;
		}
		
		public static IEnumerator getMasteries(string patchNumber, string languageCode) {
			using (UnityWebRequest www = UnityWebRequest.Get("https://ddragon.leagueoflegends.com/cdn/" + patchNumber + "/data/" + languageCode + "/mastery.json")) {
				yield return www.Send();
				if (www.isNetworkError || www.isHttpError) {
					Debug.Log(www.error);
					yield return null;
				} else {
					JSONNode masteriesJSON = JSON.Parse(www.downloadHandler.text);
					Tree tree = Tree.parseTreeJSON(masteriesJSON["tree"]);
					List<Mastery> masteries = Mastery.parseMasteriesJSON(masteriesJSON["data"]);
					yield return new Masteries(masteries, tree);                       
				}
			}
		}
	}
}