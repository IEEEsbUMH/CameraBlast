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
				POV.transform.Rotate (Input.GetAxis ("Mouse Y") * mouseSensitivity * Time.deltaTime * -1, 0, 0);
				
				transform.Rotate (0, Input.GetAxis ("Mouse X") * mouseSensitivity * Time.deltaTime, 0);
				pr_cameraDirection = POV.transform.forward;
				pr_rightDirection = Vector3.Cross (pr_cameraDirection, Vector3.up);
				

				//Player movement
				pr_movementDirection.x = Input.GetAxis ("Horizontal");
				pr_movementDirection.z = Input.GetAxis ("Vertical");
				//pr_movementDirection.Normalize ();
				pr_movementDirection *= movementSpeed * Time.deltaTime;
		}

		void processMovement ()
		{
				//Add gravity
				Vector3 t_gravityMovement = new Vector3 (0, (float)(pr_controller.velocity.y * Time.deltaTime + 0.5 * Physics.gravity.y * Time.deltaTime * Time.deltaTime), 0);
				
				if (pr_controller.isGrounded) {
						t_gravityMovement = new Vector3 ();
				}

				pr_controller.Move (transform.right * pr_movementDirection.x + transform.forward * pr_movementDirection.z + t_gravityMovement);
		}
}
