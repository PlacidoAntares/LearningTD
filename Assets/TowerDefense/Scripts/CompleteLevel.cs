using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CompleteLevel : MonoBehaviour {

	public string nextLevel = "LevelO2";
	public int levelToUnlock = 2;

	public string MenuSceneName = "MainMenu";
	public Scene_Fader sceneFader;

	public void Continue()
	{
		PlayerPrefs.SetInt ("levelReached", levelToUnlock);
		sceneFader.FadeTo (nextLevel);
	}
	public void Menu()
	{
		sceneFader.FadeTo (MenuSceneName);
	}


}
