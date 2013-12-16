using UnityEngine;
using System.Collections;

public class PlayerSpawning : MonoBehaviour
{
		public GameObject lastCheckpoint;

		public void Respawn ()
		{
				transform.position = lastCheckpoint.transform.position;
		}

		public void replaceSpawn (GameObject a_spawn)
		{
				lastCheckpoint = a_spawn;
		}
}
