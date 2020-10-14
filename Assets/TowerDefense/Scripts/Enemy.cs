using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour {

    public float startSpeed = 10f;
    [HideInInspector]
    public float speed;

    public float startHealth = 100;
	private float Health;
    public int worth = 50;
    public GameObject DeathFX;

	[Header("Unity Stuff")]
	public Image healthBar;
    //
	private bool isDead = false;
    private void Start()
    {
        speed = startSpeed;
		Health = startHealth;
    }

    public void TakeDamage(float amount)
    {
        Health -= amount;

		healthBar.fillAmount = Health / startHealth;
        if(Health <= 0 && !isDead)
        {
            Die();
        }
    }

    public void Slow (float pct)
    {
        speed = startSpeed * (1f - pct);
    }
    void Die()
    {
		isDead = true;
        PlayerStats.Money += worth;
		WaveSpawner.EnemiesAlive--;
		Debug.Log ("Enemies Alive:" + WaveSpawner.EnemiesAlive);
        GameObject Effect = (GameObject)Instantiate(DeathFX, transform.position, Quaternion.identity);
        Destroy(Effect, 5f); 
        Destroy(gameObject);
    }
    

   
}
