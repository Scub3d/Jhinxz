using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using Jhinx.Chompers;
using SimpleJSON;
using UnityEngine;
using UnityEngine.Networking;
// ReSharper disable All

namespace Jhinx.Jhin.Sticker {
	public class Sticker {
		public int Id { get; set; }
		public Image Image { get; set; }

		public Sticker(int id, Image image) {
			Id = id;
			Image = image;
		}
		
		private static Sticker parseStickerJSON(JSONNode json) {
			Image image = new Image(Chompers.Image.ParseImageJson(json["image"]));
			return new Sticker(json["id"], image);
		}

		private static List<Sticker> parseStickersJSON(JSONNode json) {
			List<Sticker> stickers = new List<Sticker>();
			foreach (JSONNode stickerJSON in json) {
				stickers.Add(parseStickerJSON(stickerJSON));
			}

			return stickers;
		}

		public static IEnumerator getStickers(string patchNumber, string languageCode) {
			using (UnityWebRequest www = UnityWebRequest.Get("https://ddragon.leagueoflegends.com/cdn/" + patchNumber + "/data/" + languageCode + "/sticker.json")) {
				yield return www.Send();
				if (www.isNetworkError || www.isHttpError) {
					Debug.Log(www.error);
					yield return null;
				} else {
					JSONNode stickersJSON = JSON.Parse(www.downloadHandler.text)["data"];
					List<Sticker> stickers = parseStickersJSON(stickersJSON);
					yield return stickers;                       
				}
			}
		}
		
	}
}