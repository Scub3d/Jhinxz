// ReSharper disable All

using System.Collections;
using System.Collections.Generic;
using SimpleJSON;
using UnityEngine;
using UnityEngine.Networking;

namespace Jhinxz.Jinx {
	public class HtmlBlock {
		public string ContentType { get; set; }
		public string Locale { get; set; }
		public string Content { get; set; }
		public string CompositeId { get; set; }
		
		public HtmlBlock(string contentType, string locale, string content, string compositeId) {
			ContentType = contentType;
			Locale = locale;
			Content = content;
			CompositeId = compositeId;
		}

		public static HtmlBlock parseHtmlBlockJSON(JSONNode json) {
			return new HtmlBlock(json["contentType"], json["locale"], json["content"], json["compositeId"]);
		}

		public static List<HtmlBlock> parseHtmlBlocksJSON(JSONArray json) {
			List<HtmlBlock> htmlBlocks = new List<HtmlBlock>();
			foreach (JSONNode htmlBlockJSON in json) {
				htmlBlocks.Add(parseHtmlBlockJSON(htmlBlockJSON));
			}

			return htmlBlocks;
		}
		
		
		public static IEnumerator getHtmlBlocks() {
			using (UnityWebRequest www = UnityWebRequest.Get("https://api.lolesports.com/api/v1/htmlBlocks")) {
				yield return www.Send();
				if (www.isNetworkError || www.isHttpError) {
					Debug.Log(www.error);
					yield return null;
				} else {
					yield return parseHtmlBlocksJSON(JSON.Parse(www.downloadHandler.text)["htmlBlocks"].AsArray);                       
				}
			}
		}
		
		public static IEnumerator getHtmlBlocks(int from) {
			using (UnityWebRequest www = UnityWebRequest.Get("https://api.lolesports.com/api/v1/htmlBlocks?from=" + from)) {
				yield return www.Send();
				if (www.isNetworkError || www.isHttpError) {
					Debug.Log(www.error);
					yield return null;
				} else {
					yield return parseHtmlBlocksJSON(JSON.Parse(www.downloadHandler.text)["htmlBlocks"].AsArray);                       
				}
			}
		}
		
		public static IEnumerator getHtmlBlocks(string locale) {
			using (UnityWebRequest www = UnityWebRequest.Get("https://api.lolesports.com/api/v1/htmlBlocks?locale=" + locale)) {
				yield return www.Send();
				if (www.isNetworkError || www.isHttpError) {
					Debug.Log(www.error);
					yield return null;
				} else {
					yield return parseHtmlBlocksJSON(JSON.Parse(www.downloadHandler.text)["htmlBlocks"].AsArray);                       
				}
			}
		}
	}
}