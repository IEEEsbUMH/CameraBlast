//Code written by Héctor Barreras Almarcha aka Dechcaudron

using UnityEngine;
using System.Collections;

public class ExternalForces : MonoBehaviour
{
		public GameObject currentPlatform;
		public float CurrentSpeed {
				get {
						return pr_currentSpeed;
				}
		}

		protected float pr_currentSpeed;//Used in case the platform changes direction during a jump, for example

		// Update is called once per frame
		void FixedUpdate ()
		{
	
		}

		void OnControllerColliderHit (ControllerColliderHit a_hit)
		{
				if (a_hit.gameObject.tag == Tags.MOVING_PLATFORM) {
						currentPlatform = a_hit.gameObject;
						pr_currentSpeed = currentPlatform.GetComponent<MovingPlatformBehaviour> ().currentSpeed;
				}

				if (a_hit.gameObject.tag == Tags.STILL_PLATFORM) {
						currentPlatform = a_hit.gameObject;
						pr_currentSpeed = 0;
				}
		}


		public void clearCurrentSpeed ()
		{
				pr_currentSpeed = 0;
		}
}
