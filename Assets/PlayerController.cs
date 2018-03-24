using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

public Text timerText;
private int time = 180;
	void Start () 
	{	
		StartCoroutine("Countdown");
		timerText.CrossFadeColor(Color.red, 180, false, false);
	}
	

	void Update () 
	{
		if(time < 0)
		{
			StopCoroutine("Countdown");
			GameOver();
		}
		else
		{
			timerText.text = "Time left : " + (time/60)+":"+(time%60 < 10 ? "0" : "")+ (time%60).ToString();
		}
	}

	IEnumerator Countdown()
	{
		while(true)
		{
			yield return new WaitForSeconds(1);
			time--;
		}
	}

	void GameOver()
	{
		timerText.text = "Game Over";
	}
}
