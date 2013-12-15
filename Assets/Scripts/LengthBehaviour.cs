using UnityEngine;
using System.Collections;

public class LengthBehaviour : MonoBehaviour
{

		protected Ray pr_ray;
		protected RaycastHit pr_rayHit = new RaycastHit ();

		// Use this for initialization
		void Start ()
		{
				
		}
	
		// Update is called once per frame
		public void recalculate ()
		{
				pr_ray = new Ray (transform.position, transform.right * -1);
				if (Physics.Raycast (pr_ray, out pr_rayHit)) {
						transform.localScale = new Vector3 (pr_rayHit.distance, 1, 1);
				}

				if (pr_rayHit.collider.gameObject.tag == Tags.PLAYER) {
						pr_rayHit.collider.gameObject.GetComponent<PlayerHealth> ().TakeBullet ();
				}
		}
}
