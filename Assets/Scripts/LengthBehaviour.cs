using UnityEngine;
using System.Collections;

public class LengthBehaviour : MonoBehaviour
{

		protected Ray pr_ray;
		protected RaycastHit pr_rayHit = new RaycastHit ();

		// Use this for initialization
		void Start ()
		{
				pr_ray = new Ray (transform.position, Vector3.left);
		}
	
		// Update is called once per frame
		public void recalculate ()
		{
				if (Physics.Raycast (pr_ray, out pr_rayHit, 10)) {
						transform.localScale = new Vector3 (pr_rayHit.distance, 1, 1);
				}
		}
}
