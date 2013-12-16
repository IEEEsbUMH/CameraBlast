using UnityEngine;
using System.Collections;

public class PlayerHealth : MonoBehaviour
{
		public int MaxHealth;
		public int TimeToStartHealing;
		public float HealingSpeed;
		public int MinY;
		public GameObject DamageLayer;
		public GameObject DeathGUIText;
		public GameObject DeathNumberGUIText;
		public int CountUntilRespawn;

		protected float pr_health;
		protected int pr_sinceLastBullet;
		protected int pr_currentRespawnCount;
		protected int pr_deaths; //Number of times the player has died

		// Use this for initialization
		void Start ()
		{
				pr_health = MaxHealth;
				pr_sinceLastBullet = 0;
				pr_currentRespawnCount = 0;
				pr_deaths = 0;
				DeathGUIText.SetActive (false);
				updateNumberOfDeaths ();
		}
	
		public void TakeBullet ()
		{
				if (pr_health > 0) {
						pr_health--;
						pr_sinceLastBullet = 0;
				}
				
		}

		void FixedUpdate ()
		{
				if (pr_health <= 0 || transform.position.y <= MinY) {
						Die ();
				}

				if (pr_health == 0) {
						if (pr_currentRespawnCount++ == CountUntilRespawn) {
								Revive ();
						}
						return;
				}
				
				pr_sinceLastBullet++;
				if (pr_sinceLastBullet >= TimeToStartHealing && pr_health < MaxHealth) {
						pr_health += HealingSpeed;

						if (pr_health > MaxHealth) {
								pr_health = MaxHealth;
						}
				}
		}

		void Update ()
		{
				if (pr_health < MaxHealth) {
						DamageLayer.SetActive (true);
						DamageLayer.GetComponent<GUITexture> ().color = new Color (1, 0, 0, (MaxHealth - pr_health) / MaxHealth);
				} else {
						DamageLayer.SetActive (false);
				}
		}

		void Die ()
		{
				pr_health = 0;
				DeathGUIText.SetActive (true);
				gameObject.GetComponent<ExternalForces> ().currentPlatform = null;	
		}

		void Revive ()
		{
				pr_currentRespawnCount = 0;
				pr_health = MaxHealth;
				GetComponent<PlayerSpawning> ().Respawn ();
				DeathGUIText.SetActive (false);
				pr_deaths++;
				updateNumberOfDeaths ();
		}

		void updateNumberOfDeaths ()
		{
				DeathNumberGUIText.guiText.text = "Muertes: " + pr_deaths.ToString ();
		}
}