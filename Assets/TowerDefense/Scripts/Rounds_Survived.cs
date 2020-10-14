﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Rounds_Survived : MonoBehaviour {

	public Text roundsText;

	void OnEnable()
	{
		StartCoroutine (Animate_Text ());
	}

	IEnumerator Animate_Text()
	{
		roundsText.text = "0";
		int round = 0;

		yield return new WaitForSeconds (0.7f);

		while (round < PlayerStats.Rounds) 
		{
			round++;
			roundsText.text = round.ToString ();

			yield return new WaitForSeconds (0.05f);
		}
	}
}
