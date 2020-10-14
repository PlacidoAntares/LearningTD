using System.Collections;
using UnityEngine;
using UnityEngine.UI;
public class WaveSpawner : MonoBehaviour {


	public static int EnemiesAlive = 0;
	public Wave[] waves;

    public Transform spawnPoint;
    public float timeBetweenWaves = 5f;
	public float countdown; //X seconds before the next wave


    public Text waveCounterText;

	public GameManager gameManager;

    private int waveIndex = 0;

	void Start()
	{
		EnemiesAlive = 0;
	}
    void Update()
    {
		if (EnemiesAlive > 0) {
			return;

		}

		if (waveIndex == waves.Length)
		{
			gameManager.WinLevel ();
			this.enabled = false;
		}

        if(countdown <= 0f)
        {
            StartCoroutine(SpawnWave());
            countdown = timeBetweenWaves;
			return;
        }
        countdown -= Time.deltaTime;
        countdown = Mathf.Clamp(countdown, 0f, Mathf.Infinity);

        waveCounterText.text = "Wave Timer: " + string.Format("{0:00:00}",countdown);
    }
    IEnumerator SpawnWave()
    {
        
        PlayerStats.Rounds++;

		Wave wave = waves [waveIndex];

		//EnemiesAlive = wave.count;
        for (int i = 0; i < wave.count; i++)
        {
			SpawnEnemy(wave.enemy);
			yield return new WaitForSeconds(1f / wave.rate);
        }
		waveIndex++;

    }
	void SpawnEnemy(GameObject enemy)
    {
        Instantiate(enemy, spawnPoint.position, spawnPoint.rotation);
		EnemiesAlive++;
		Debug.Log (EnemiesAlive);
	}
}
