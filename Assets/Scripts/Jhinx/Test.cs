using System.Collections;
using System.Collections.Generic;
using Jhinx.Chompers;
using Jhinx.Jhin;
using Jhinx.Jhin.Rune;
using Jhinx.Jinx;
using UnityEngine;
// ReSharper disable All

public class Test : MonoBehaviour {
    IEnumerator Start() {
        CoroutineWithData cd = new CoroutineWithData(this, Rune.getRunes("6.24.1", "en_US"));
        yield return cd.coroutine;
		List<Rune> runes = (List<Rune>)cd.result;

	    foreach (Rune rune in runes) {
		    Debug.Log(rune.Name);
	    }
    }
  
}
