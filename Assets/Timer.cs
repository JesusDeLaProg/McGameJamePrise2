using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour {

public Text timerText;
public int time = 180;

public bool IsItTimeToStop = false;
	void Start () 
	{	
		timerText = GetComponent<Text>();
		StartCoroutine("Countdown");
		timerText.CrossFadeColor(Color.red, time, false, false);
	}
	

	private void OnGUI()
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
			if(IsItTimeToStop == false)
			{
				yield return new WaitForSeconds(1);
				time--;
			}
			else{
				yield return new WaitUntil(()=>IsItTimeToStop == false);
			}
		}
	}

	void GameOver()
	{
		timerText.text = "Game Over";
		//TODO Call end correct end screen
	}

	// Send true if you want the time to stop. Sending false will active it again.
	void TimeToStop(bool Condition) 
	{
		if(Condition)
		{
			IsItTimeToStop = true;
		}
		else {
			IsItTimeToStop =  false;
		}
	}
}
