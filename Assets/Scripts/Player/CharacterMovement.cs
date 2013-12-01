//Code written by Héctor Barreras Almarcha aka Dechcaudron

using UnityEngine;
using System.Collections;

public class CharacterMovement : MonoBehaviour
{

		public bool controlIsActive;
		public bool jetpackIsAvailable;
		public GameObject POV;
		public int mouseSensitivity;
		public float movementSpeed;
		public float jumpPower;
		public float jetpackPower;
		public int minHeadAngle;
		public int maxHeadAngle;
		protected Vector3 pr_movementDirection;
		protected Vector3 pr_cameraDirection;
		protected float pr_jumpValue;
		protected float pr_jetpackValue;
		protected bool pr_grounded; //Will be true if isGrounded hasn't been false during the last 5 FixedUpdate calls
		protected int h_notGroundedCount;

		protected CharacterController pr_controller;

		protected float pr_speed = 0;


		// Use this for initialization
		void Start ()
		{
				pr_controller = GetComponent<CharacterController> ();
				pr_movementDirection = new Vector3 ();
				pr_jumpValue = 0;
				pr_jetpackValue = 0;
				pr_grounded = false;
				h_notGroundedCount = 0;
		}
	
		// Update is called once per frame
		void FixedUpdate ()
		{
				checkGrounding ();
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
				if (pr_grounded) {
						pr_movementDirection.x = Input.GetAxis ("Horizontal");
						pr_movementDirection.z = Input.GetAxis ("Vertical");
						//pr_movementDirection.Normalize ();
						pr_movementDirection *= movementSpeed * Time.deltaTime;
				}

				pr_jumpValue = Input.GetAxis ("Jump");

				if (jetpackIsAvailable) {
						pr_jetpackValue = Input.GetAxis ("Jetpack");
				}
		}

		void processMovement ()
		{
				if (pr_grounded) {
						pr_speed = pr_jumpValue > 0 ? jumpPower : 0;
				} else {
						//Add gravity
						pr_speed += Physics.gravity.y * Time.deltaTime;	
				}

				//Modifies pr_speed if jetpack is working
				if (pr_jetpackValue > 0) {
						pr_speed += jetpackPower;
				}
				
				Vector3 t_gravityMovement = new Vector3 (0, pr_speed * Time.deltaTime, 0);

				pr_controller.Move (transform.right * pr_movementDirection.x + transform.forward * pr_movementDirection.z + t_gravityMovement);
		}

		void checkGrounding ()
		{
				if (pr_controller.isGrounded) {
						pr_grounded = true;
						h_notGroundedCount = 0;
				} else if (++h_notGroundedCount < 5) {
						pr_grounded = false;
				}
		}
}
