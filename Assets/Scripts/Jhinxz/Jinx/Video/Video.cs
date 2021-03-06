using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using SimpleJSON;
using UnityEngine;
using UnityEngine.Networking;
// ReSharper disable All

namespace Jhinxz.Jinx {
	public class Video {
		public int Id { get; set; }
		public string Slug { get; set; }
		public string Label { get; set; }
		public string Locale { get; set; }
		public string Reference { get; set; }
        public string Source { get; set; }
		public string CreatedAt { get; set; }
		public string UpdatedAt { get; set; }
		public string Game { get; set; }

		public Video(int id, string slug, string label, string locale, string reference, string source, string createdAt, string updatedAt, string game) {
			Id = id;
			Slug = slug;
			Label = label;
			Locale = locale;
			Reference = reference;
			Source = source;
			CreatedAt = createdAt;
			UpdatedAt = updatedAt;
			Game = game;
		}
		
		public static Video parseVideoJSON(JSONNode videoJSON) {
			return new Video(videoJSON["id"], videoJSON["slug"], videoJSON["label"], videoJSON["locale"], videoJSON["reference"], videoJSON["source"], videoJSON["createdAt"], videoJSON["updatedAt"], videoJSON["game"]);
		}

		public static List<Video> parseVideosJSON(JSONArray json) {
			List<Video> videos = new List<Video>();
			foreach (JSONNode videoJSON in json) {
				videos.Add(parseVideoJSON(videoJSON));
			}
			
			return videos;
		}

		public static IEnumerator getVideos() {
			using (UnityWebRequest www = UnityWebRequest.Get("https://api.lolesports.com/api/v2/videos")) {
				yield return www.Send();
				if (www.isNetworkError || www.isHttpError) {
					Debug.Log(www.error);
					yield return null;
				} else {
					JSONNode videosJSON = JSON.Parse(www.downloadHandler.text)["videos"];
					List<Video> videos = parseVideosJSON(videosJSON.AsArray);
					yield return videos;                       
				}
			}
		}	
    }
}