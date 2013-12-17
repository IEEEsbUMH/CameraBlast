using UnityEngine;
using System.Collections;

public class TakeDamage : MonoBehaviour
{
		public GameObject Sparks;
		public bool Alive;

		public void Die ()
		{
				gameObject.SetActive (false);
				Sparks.SetActive (true);
				CameraRotation.isInRange = false;
				Alive = false;
		}
}
