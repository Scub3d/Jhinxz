using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using Jhinxz.Chompers;
using SimpleJSON;
using UnityEngine;
using UnityEngine.Networking;
// ReSharper disable All

namespace Jhinxz.Jhin.ProfileIcon {
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

		private static List<ProfileIcon> parseProfileIconsJSON(JSONNode json) {
			List<ProfileIcon> profileIcons = new List<ProfileIcon>();
			foreach (JSONNode profileIconJSON in json) {
				profileIcons.Add(parseProfileIconJSON(profileIconJSON));
			}

			return profileIcons;
		}
		
		public static IEnumerator getProfileIcons(string patchNumber, string languageCode) {
			using (UnityWebRequest www = UnityWebRequest.Get("https://ddragon.leagueoflegends.com/cdn/" + patchNumber + "/data/" + languageCode + "/profileicon.json")) {
				yield return www.Send();
				if (www.isNetworkError || www.isHttpError) {
					Debug.Log(www.error);
					yield return null;
				} else {
					JSONNode profileIconsJSON = JSON.Parse(www.downloadHandler.text)["data"];
					List<ProfileIcon> profileIcons = parseProfileIconsJSON(profileIconsJSON);
					yield return profileIcons;                       
				}
			}
		}
		
	}
}