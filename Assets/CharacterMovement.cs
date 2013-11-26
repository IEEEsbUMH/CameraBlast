using UnityEngine;
using System.Collections;

public class CharacterMovement : MonoBehaviour
{

		public bool controlIsActive;
		public GameObject POV;
		public int mouseSensitivity;
		public float movementSpeed;
		protected Vector3 pr_movementDirection;
		protected Vector3 pr_cameraDirection;
		protected Vector3 pr_rightDirection;

		protected CharacterController pr_controller;


		// Use this for initialization
		void Start ()
		{
				pr_controller = GetComponent<CharacterController> ();
		}
	
		// Update is called once per frame
		void FixedUpdate ()
		{
				pr_movementDirection = new Vector3 ();
				processInput ();
				processMovement ();
		}

		void processInput ()
		{
				//Camera
				POV.transform.Rotate (Input.GetAxis ("Mouse Y") * mouseSensitivity * -1, 0, 0);
				transform.Rotate (0, Input.GetAxis ("Mouse X") * mouseSensitivity, 0);
				pr_cameraDirection = new Vector3 (Mathf.Sin (transform.rotation.y * Mathf.Deg2Rad), 0, Mathf.Cos (transform.rotation.y * Mathf.Deg2Rad));
				pr_rightDirection = Vector3.Cross (pr_cameraDirection, Vector3.up);
				

				//Player movement
				pr_movementDirection.x = Input.GetAxis ("Horizontal");
				pr_movementDirection.z = Input.GetAxis ("Vertical");
				//pr_movementDirection.Normalize ();
				pr_movementDirection *= movementSpeed;
		}

		void processMovement ()
		{
				/*pr_controller.Move (new Vector3 (pr_movementDirection.z * Mathf.Cos (Vector3.Angle (pr_cameraDirection, Vector3.right) * Mathf.Deg2Rad) + pr_movementDirection.x * Mathf.Cos (Vector3.Angle (pr_rightDirection, Vector3.right) * Mathf.Deg2Rad), 0,
		                                 pr_movementDirection.z * Mathf.Cos (Vector3.Angle (pr_cameraDirection, Vector3.forward) * Mathf.Deg2Rad) + pr_movementDirection.x * Mathf.Cos (Vector3.Angle (pr_rightDirection, Vector3.forward) * Mathf.Deg2Rad)));*/
				pr_controller.Move (transform.right * pr_movementDirection.x + transform.forward * pr_movementDirection.z);
		}
}
