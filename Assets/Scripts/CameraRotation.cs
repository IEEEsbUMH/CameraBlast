//Code written by Héctor Barreras Almarcha aka Dechcaudron and Miguel Catalan Bañuls
using UnityEngine;
using System.Collections;

public class CameraRotation : MonoBehaviour
{
		public static bool isInRange;
	
		public GameObject startObject;
		public GameObject endObject;
		public int speed;
		public int speedChasingPlayer;
		public float anglesToChange;

		public bool autopilotLeft;
		public bool autopiloRight;	

		private Vector3 movement;
		private Vector3 inverseMovement;
		private Vector3 rotate;

		private Quaternion startRotation;
		private Quaternion endRotation;
		private Quaternion playerRotation;
		private Quaternion targetRotation;
		private Quaternion currentFixedRotation;
		
		private GameObject player;


		void Start ()
		{
				player = GameObject.FindGameObjectWithTag ("Player");
				transform.LookAt (startObject.transform.position);
		
				startRotation = Quaternion.Euler (transform.eulerAngles.x, transform.eulerAngles.y, 0);
				transform.rotation = startRotation;
				
				transform.LookAt (endObject.transform.position);
				
				endRotation = Quaternion.Euler (transform.eulerAngles.x, transform.eulerAngles.y, 0);
				transform.rotation = startRotation;
				targetRotation = endRotation;

				if (autopilotLeft || autopiloRight) {
					transform.rotation = Quaternion.Euler (0, 0, 0);
				}
		}

		void Update ()
		{
			if (!isInRange) {
					if (endObject != null && !autopilotLeft && !autopiloRight) {
							ChangePosition (); 
					} else if (autopilotLeft || autopiloRight) {
							RotateOnY ();
					}
					ChangeLightColor(Color.green);
			} else {
					Quaternion current;
					current = Quaternion.Euler (transform.eulerAngles.x, transform.eulerAngles.y, 0);
					transform.LookAt (player.transform.position);
					playerRotation = Quaternion.Euler (transform.eulerAngles.x, transform.eulerAngles.y, 0);
					transform.rotation = current;
					LookAtPlayer (); 
					ChangeLightColor(Color.red);
					//CheckforWalls();
			}
		}
	
		void ChangePosition ()
		{
				transform.rotation = Quaternion.RotateTowards (transform.rotation, targetRotation, speed * Time.deltaTime);
				currentFixedRotation = Quaternion.Euler (transform.eulerAngles.x, transform.eulerAngles.y, 0);
				transform.rotation = currentFixedRotation;
				
				//Target control
				if (Quaternion.Angle (transform.rotation, targetRotation) <= anglesToChange) {
						targetRotation = targetRotation == startRotation ? endRotation : startRotation;
				}
		}

		void RotateOnY()
		{
			if(autopilotLeft)
			{
				transform.Rotate(Vector3.up * Time.deltaTime * speed);
			}else{
				transform.Rotate(Vector3.down * Time.deltaTime * speed);
			}
		}

		void LookAtPlayer(){
			transform.rotation = Quaternion.RotateTowards (transform.rotation, targetRotation, speedChasingPlayer * Time.deltaTime);
			currentFixedRotation = Quaternion.Euler (transform.eulerAngles.x, transform.eulerAngles.y, 0);
			transform.rotation = currentFixedRotation;
			
			//Target control
			if (Quaternion.Angle (transform.rotation, targetRotation) <= anglesToChange) {
				targetRotation = playerRotation;
			}
		}

		void ChangeLightColor(Color color){
			GetComponentInChildren<Light> ().light.color = color;
			GetComponentInChildren<LensFlare> ().color = color;
		}

		/*void CheckforWalls(){
		RaycastHit hit;
			if (Physics.Raycast (transform.position, player.transform.position-transform.position, out hit)) {
				if(hit.collider.tag == "Walls"){
					isInRange = false;
				}
			}
		}*/

}