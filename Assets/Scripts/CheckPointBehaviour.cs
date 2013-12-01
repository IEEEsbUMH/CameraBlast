using UnityEngine;
using System.Collections;

public class CheckPointBehaviour : MonoBehaviour
{
		public float gravityMultiplierAfterUsing;
		public Color startColorAfterUsing;

		void OnTriggerEnter (Collider a_collider)
		{
				//Is it the player?
				if (a_collider.gameObject.tag == Tags.PLAYER) {
						a_collider.gameObject.GetComponent<PlayerSpawning> ().replaceSpawn (transform.gameObject);

						//particleSystem.gravityModifier = gravityMultiplierAfterUsing;
						//particleSystem.startColor = startColorAfterUsing;
						particleSystem.loop = false;
				}
		}
}