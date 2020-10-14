using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverScript : MonoBehaviour {

    public Text roundsText;
	public string menuSceneName;
	public Scene_Fader scenefader;

    void OnEnable()
    {
        roundsText.text = PlayerStats.Rounds.ToString();     
    }

    public void Retry()
    {
		scenefader.FadeTo(SceneManager.GetActiveScene().name);
    }

    public void Menu ()
    {
		scenefader.FadeTo (menuSceneName);
    }
}
