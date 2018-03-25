using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Surival : MonoBehaviour {


	int TimeLeft = 120;
	Example GameLoopSurvival;
	void Start () {
		GameLoopSurvival =  GameObject.FindGameObjectWithTag("Player").GetComponent<Example>();
	}

	void Update () {
		//To finish

		
	}
}
