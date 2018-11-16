using System.Collections;
using System.Collections.Generic;
using Jhinx.Chompers;
using Jhinx.Jhin;
using Jhinx.Jinx;
using UnityEngine;

public class Test : MonoBehaviour {
    IEnumerator Start() {
        CoroutineWithData cd = new CoroutineWithData(this, Mastery.getMasteries("6.24.1", "en_US"));
        yield return cd.coroutine;
       _Masteries masteries = (_Masteries)cd.result;

	    foreach (Mastery mastery in masteries.Masteries) {
		    Debug.Log(mastery.Name);
	    }
    }
  
}
