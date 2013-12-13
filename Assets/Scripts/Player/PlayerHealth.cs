using UnityEngine;
using System.Collections;

public class PlayerHealth : MonoBehaviour
{
		public int MaxHealth;
		public int TimeToStartHealing;
		public float HealingSpeed;
		public int MinY;

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

		void Die ()
		{
				pr_health = 0;
				print ("You Died");
		}
}
