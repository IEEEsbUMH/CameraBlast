using UnityEngine;
using System.Collections;

public class CheckPointBehaviour : MonoBehaviour
{
	
		void OnTriggerEnter (Collider a_collider)
		{
				//Is it the player?
				print (0);
				if (a_collider.gameObject.tag == Tags.PLAYER) {
						a_collider.gameObject.GetComponent<PlayerSpawning> ().replaceSpawn (transform.gameObject);
				}
		}
}