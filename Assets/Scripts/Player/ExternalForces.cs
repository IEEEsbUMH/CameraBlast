using UnityEngine;
using System.Collections;

public class ExternalForces : MonoBehaviour
{
		public GameObject currentPlatform;

		// Update is called once per frame
		void FixedUpdate ()
		{
				if (currentPlatform != null) {
						transform.Translate (currentPlatform.GetComponent<MovingPlatformBehaviour> ().currentSpeed, 0, 0, Space.World);
				}
		}

		void OnControllerColliderHit (ControllerColliderHit a_hit)
		{
				if (a_hit.gameObject.tag == Tags.MOVING_PLATFORM) {
						currentPlatform = a_hit.gameObject;
						print ("New currentplatform");
				}
		}
}
