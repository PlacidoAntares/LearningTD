using UnityEngine;
using UnityEngine.SceneManagement;
public class PauseMenu : MonoBehaviour {

	public GameObject UI;

	public string menuSceneName;
	public Scene_Fader scenefader;
	public string currentSceneName;

	void Update()
	{
		if (Input.GetKeyDown (KeyCode.Escape) || Input.GetKeyDown (KeyCode.P)) 
		{
			Toggle ();
		}
	}

	public void Retry(){

		Toggle ();
		scenefader.FadeTo (currentSceneName);

	}

	public void Menu()
	{
		Toggle ();
		scenefader.FadeTo(menuSceneName);
	}
	public void Toggle()
	{
		UI.SetActive (!UI.activeSelf);
		if (UI.activeSelf) {
			Time.timeScale = 0f;
		} 
		else 
		{
			Time.timeScale = 1f;
		}
	}
}
