using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using Jhinx.Chompers;
using SimpleJSON;
using UnityEngine;
using UnityEngine.Networking;

namespace Jhinx.Jhin {
	[SuppressMessage("ReSharper", "MemberCanBePrivate.Global")]
	[SuppressMessage("ReSharper", "SuggestVarOrType_SimpleTypes")]
	[SuppressMessage("ReSharper", "SuggestVarOrType_Elsewhere")]
	public class ProfileIcon {
		public int Id { get; set; }
		public Image Image { get; set; }

		public ProfileIcon(int id, Image image) {
			Id = id;
			Image = image;
		}
		
		private static ProfileIcon parseProfileIconJSON(JSONNode profileIconJSON) {
			Image image = new Image(Chompers.Image.ParseImageJson(profileIconJSON["image"]));
			return new ProfileIcon(profileIconJSON["id"], image);
		}
		
		public static IEnumerator getProfileIcons(string patchNumber, string languageCode) {
			using (UnityWebRequest www = UnityWebRequest.Get("https://ddragon.leagueoflegends.com/cdn/" + patchNumber + "/data/" + languageCode + "/profileicon.json")) {
				yield return www.Send();
				if (www.isNetworkError || www.isHttpError) {
					Debug.Log(www.error);
					yield return null;
				} else {
					List<ProfileIcon> profileIcons = new List<ProfileIcon>();
					JSONNode profileIconsJSON = JSON.Parse(www.downloadHandler.text)["data"];
					foreach (JSONNode profileIconJSON in profileIconsJSON) {
						profileIcons.Add(parseProfileIconJSON(profileIconJSON));
					}
					yield return profileIcons;                       
				}
			}
		}
		
	}
}