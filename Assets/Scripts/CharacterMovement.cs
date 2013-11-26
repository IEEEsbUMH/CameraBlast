using UnityEngine;
using System.Collections;

public class CharacterMovement : MonoBehaviour
{

		public bool controlIsActive;
		public GameObject POV;
		public int mouseSensitivity;
		public float movementSpeed;
		public int minHeadAngle;
		public int maxHeadAngle;
		protected Vector3 pr_movementDirection;
		protected Vector3 pr_cameraDirection;

		protected CharacterController pr_controller;

		protected float pr_speed = 0;


		// Use this for initialization
		void Start ()
		{
				pr_controller = GetComponent<CharacterController> ();
				pr_movementDirection = new Vector3 ();
		}
	
		// Update is called once per frame
		void FixedUpdate ()
		{
				processInput ();
				processMovement ();
		}

		void processInput ()
		{
				//Camera
				if (Input.GetAxis ("Mouse Y") > 0 && Vector3.Angle (transform.up, pr_cameraDirection) > minHeadAngle || Input.GetAxis ("Mouse Y") < 0 && Vector3.Angle (transform.up, pr_cameraDirection) < maxHeadAngle) {
						POV.transform.Rotate (Input.GetAxis ("Mouse Y") * mouseSensitivity * Time.deltaTime * -1, 0, 0);
						pr_cameraDirection = POV.transform.forward;		
				}

				transform.Rotate (0, Input.GetAxis ("Mouse X") * mouseSensitivity * Time.deltaTime, 0);
				
				

				//Player movement
				//Only overwritten if the player is on the floor
				if (Mathf.Abs (pr_controller.velocity.y) < 2) {
						pr_movementDirection.x = Input.GetAxis ("Horizontal");
						pr_movementDirection.z = Input.GetAxis ("Vertical");
						//pr_movementDirection.Normalize ();
						pr_movementDirection *= movementSpeed * Time.deltaTime;
				}
		}

		void processMovement ()
		{
				if (pr_controller.isGrounded) {
						pr_speed = 0;
				} else {
						//Add gravity
						pr_speed += Physics.gravity.y * Time.deltaTime;	
				}
				
				Vector3 t_gravityMovement = new Vector3 (0, pr_speed * Time.deltaTime, 0);

				pr_controller.Move (transform.right * pr_movementDirection.x + transform.forward * pr_movementDirection.z + t_gravityMovement);
		}
}
