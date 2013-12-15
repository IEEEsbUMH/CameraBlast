using UnityEngine;
using System.Collections;

public class PlayerHealth : MonoBehaviour
{
		public int MaxHealth;
		public int TimeToStartHealing;
		public float HealingSpeed;
		public int MinY;
		public GameObject DamageLayer;

		protected float pr_health;
		protected int pr_sinceLastBullet;

		// Use this for initialization
		void Start ()
		{
				pr_health = MaxHealth;
				pr_sinceLastBullet = 0;
		}
	
		void TakeBullet ()
		{
				pr_sinceLastBullet = 0;
		}

		void FixedUpdate ()
		{
				if (pr_health <= 0 || transform.position.y <= MinY) {
						Die ();
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
				if (pr_health != MaxHealth) {
						DamageLayer.SetActive (true);
						DamageLayer.GetComponent<GUITexture> ().color = new Color (1, 0, 0, (MaxHealth - pr_health) / MaxHealth);
						print ("weee");
				} else {
						//DamageLayer.SetActive (false);
				}
		}

		void Die ()
		{
				pr_health = 0;
				//print ("You Died");
		}
}
