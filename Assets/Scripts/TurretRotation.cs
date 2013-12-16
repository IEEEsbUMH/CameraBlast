//Coded by Luis Fletcher. Edited by Héctor Barreras and Miguel Catalan.
using UnityEngine;
using System.Collections;

public class TurretRotation : MonoBehaviour
{		
		public GameObject Axis;
		public GameObject cannons;
		public float RotationSpeed;
		public float anglesToChange;

		public bool Test;

		protected GameObject player;
		protected Vector3 pr_falsePlayerPosition;
		protected int pr_maxAngularError; //In degrees
		private Vector3 initialposition;
		private int direction;

		// Use this for initialization
		void Start ()
		{	
				initialposition = transform.forward;
				player = GameObject.FindGameObjectWithTag (Tags.PLAYER);
				pr_maxAngularError = 1;
		}
	
		// FixedUpdate is called once per frame
		void FixedUpdate ()
		{
				
				pr_falsePlayerPosition = player.transform.position;
				pr_falsePlayerPosition.y = transform.position.y;
						
				float t_angleTowardsPlayer = Quaternion.FromToRotation (transform.right * -1, pr_falsePlayerPosition - transform.position).eulerAngles.y;


				if (cannons.GetComponent<ShootingAnim> ().ActivateShooting && t_angleTowardsPlayer > pr_maxAngularError) {
					
						
						
						if ((t_angleTowardsPlayer > 0 && t_angleTowardsPlayer < 180) || t_angleTowardsPlayer < -180) {
								direction = 1;
						} else {
								direction = -1;
						}

						transform.RotateAround (Axis.transform.position, Vector3.up, direction * RotationSpeed * Time.deltaTime);
				} else if (!cannons.GetComponent<ShootingAnim> ().ActivateShooting && transform.forward!=initialposition){
						transform.RotateAround (Axis.transform.position, Vector3.up, -direction * RotationSpeed * Time.deltaTime);
				}
		}
	
}