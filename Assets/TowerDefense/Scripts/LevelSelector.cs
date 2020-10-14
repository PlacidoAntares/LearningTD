﻿using UnityEngine;
using UnityEngine.UI;

public class LevelSelector : MonoBehaviour {

	public Scene_Fader fader;

	public Button[] levelButtons;

	void Start()
	{
		int levelReached = PlayerPrefs.GetInt("levelReached",1);
		for (int i = 0; i < levelButtons.Length; i++) 
		{
			if(i + 1 > levelReached)
			levelButtons [i].interactable = false;
		}
			
	}
	public void Select(string LevelName)
	{
		fader.FadeTo (LevelName);
	}

	public void Quit()
	{
		Debug.Log("Exiting Application");
		Application.Quit();
	}
}
