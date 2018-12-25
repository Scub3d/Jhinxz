using System.Collections;
using System.Collections.Generic;
using Jhinxz.Chompers;
using UnityEngine;

namespace Jhinxz.Jinx {
	public class Test : MonoBehaviour {
		private void Start() {
			StartCoroutine(GetVideos());
			//StartCoroutine(GetLeagueById());
			//StartCoroutine(GetLeagueBySlug());
		}
		
		IEnumerator GetVideos() {
			CoroutineWithData cd = new CoroutineWithData(this, Video.getVideos());
			yield return cd.coroutine;
			List<Video> videos = (List<Video>)cd.result;
	
			foreach (Video video in videos) {
				Debug.Log(video.Locale);
			}
			Debug.Log("=============================");
		}
		
		IEnumerator GetLeagueById() {
			CoroutineWithData cd = new CoroutineWithData(this, League.League.getLeague(2));
			yield return cd.coroutine;
			// Need to determine how to format this data before this can be completed
			Debug.Log("=============================");
		}
		
		IEnumerator GetLeagueBySlug() {
			CoroutineWithData cd = new CoroutineWithData(this, League.League.getLeague("worlds"));
			yield return cd.coroutine;
			// Need to determine how to format this data before this can be completed
			Debug.Log("=============================");
		}
	}
}