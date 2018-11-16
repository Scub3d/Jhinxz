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
	public class Sticker {
		public int Id { get; set; }
		public Image Image { get; set; }

		public Sticker(int id, Image image) {
			Id = id;
			Image = image;
		}
		
		private static Sticker parseStickerJSON(JSONNode stickerJSON) {
			Image image = new Image(Chompers.Image.ParseImageJson(stickerJSON["image"]));
			return new Sticker(stickerJSON["id"], image);
		}

		public static IEnumerator getStickers(string patchNumber, string languageCode) {
			using (UnityWebRequest www = UnityWebRequest.Get("https://ddragon.leagueoflegends.com/cdn/" + patchNumber + "/data/" + languageCode + "/sticker.json")) {
				yield return www.Send();
				if (www.isNetworkError || www.isHttpError) {
					Debug.Log(www.error);
					yield return null;
				} else {
					List<Sticker> stickers = new List<Sticker>();
					JSONNode stickersJSON = JSON.Parse(www.downloadHandler.text)["data"];
					foreach (JSONNode stickerJSON in stickersJSON) {
						stickers.Add(parseStickerJSON(stickerJSON));
					}
					yield return stickers;                       
				}
			}
		}
		
	}
}