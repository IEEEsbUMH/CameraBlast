using UnityEngine;
using System.Collections;

public class PlayerSpawning : MonoBehaviour
{

		public GameObject lastCheckpoint;

		void Respawn ()
		{

		}

		public void replaceSpawn (GameObject a_spawn)
		{
				lastCheckpoint = a_spawn;
		}
}
