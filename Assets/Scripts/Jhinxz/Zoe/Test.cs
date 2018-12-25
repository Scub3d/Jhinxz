using System.Collections;
using Jhinxz.Chompers;
using Jhinxz.Jinx;
using UnityEngine;

namespace Jhinxz.Zoe {
	public class Test : MonoBehaviour {
		private void Start() {
			StartCoroutine(GetFantasyStats());
		}
		
		IEnumerator GetFantasyStats() {
			CoroutineWithData cd = new CoroutineWithData(this, Fantasy.Fantasy.getFantasyStats("na", "en-US", 1));
			yield return cd.coroutine;
			Fantasy.Fantasy fantasyStats = (Fantasy.Fantasy)cd.result;
		
			Debug.Log(fantasyStats.SeasonName);
			Debug.Log("=============================");
		}
	}
}