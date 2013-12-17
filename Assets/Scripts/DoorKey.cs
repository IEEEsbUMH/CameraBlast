//Coded by Miguel Catalan
using UnityEngine;
using System.Collections;

public class DoorKey : MonoBehaviour
{

		public GameObject[] Cameras;
		public GameObject LeftDoor;
		public GameObject RightDoor;

		protected bool open = false;

		// Update is called once per frame
		void Update ()
		{
				if (!Checker () && !open) {
						OpenDoor ();
				}
		}

		void OpenDoor ()
		{
				LeftDoor.transform.Translate (transform.right * 0.8f, Space.World);
				RightDoor.transform.Translate (transform.right * -1 * 0.8f, Space.World);
				open = true;
		}

		private bool Checker ()
		{
				for (int i =0; i<Cameras.Length; i++) {
						bool isAlive = Cameras [i].GetComponent<TakeDamage> ().Alive;
						if (isAlive) {
								return true;
						}
				}
				return false;
		}
}
