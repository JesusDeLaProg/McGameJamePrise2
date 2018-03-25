using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Survival : MonoBehaviour {

	bool Active = true;
	int TimeLeft = 30;
	int TimeAdded = 15;
	int NbGreenDoors = 0;
	Example GameLoopSurvival;

	Text TimeAddedText;

	private Timer timer;

	void Start()
	{
		timer = GameObject.FindGameObjectWithTag("Timer").GetComponent<Timer>();
		TimeAddedText = GetComponent<Text>();
	}

	void Update () {
		//To finish
		if(NbGreenDoors != Example.lesPoints)
		{
			NbGreenDoors = Example.lesPoints;
			var t = TimeAdded - Mathf.Min(10,NbGreenDoors - 1);
			timer.time += t;
			TimeAddedText.text = "+"+t.ToString();
			TimeAddedText.CrossFadeAlpha(1,0.01f,false);
			TimeAddedText.CrossFadeAlpha(0,3,false);

		}
	}
}
