using UnityEngine;
using System.Collections;
using System;
using Jhinxz.Chompers;
using SimpleJSON;
// ReSharper disable All

namespace Jhinxz.Willump {
	public class Test : MonoBehaviour {
		private void Start() {
			StartCoroutine(BeginWebsocket());
		}

		IEnumerator BeginWebsocket() {
			CoroutineWithData cd = new CoroutineWithData(this, Stream.getStreamToken());
			yield return cd.coroutine;
			string token = (string)cd.result;

			WebSocket w = new WebSocket(new Uri("ws://livestats.proxy.lolesports.com/stats?jwt=" + token));
			yield return StartCoroutine(w.Connect());
			while (true) {
				string reply = w.RecvString();
				if (reply != null) {
					Debug.Log("Received: " + reply);
					JSONNode liveDataJSON = JSON.Parse(reply);
					// Process data
					// Do what you want here
				}
				if (w.error != null) {
					Debug.LogError("Error: " + w.error);
					break;
				}
				yield return 0;
			}
			w.Close();
		}
	}
}