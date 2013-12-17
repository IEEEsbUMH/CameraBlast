using UnityEngine;
using System.Collections;

public class PickableUp : MonoBehaviour
{
		public int RotationSpeed;

		// Use this for initialization
		void Start ()
		{
	
		}
	
		// Update is called once per frame
		void FixedUpdate ()
		{
				transform.Rotate (0, RotationSpeed * Time.deltaTime, 0);
		}

		void OnTriggerEnter (Collider a_collider)
		{

		}
}
