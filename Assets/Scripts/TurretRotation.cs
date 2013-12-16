//Coded by Luis Fletcher. Edited by Héctor Barreras and Miguel Catalan.
using UnityEngine;
using System.Collections;

public class TurretRotation : MonoBehaviour
{		
		public GameObject Axis;
		public GameObject cannons;
		public float RotationSpeed;
		public float anglesToChange;

		protected GameObject player;
		protected Vector3 pr_falsePlayerPosition;
		protected int pr_maxAngularError; //In degrees

		// Use this for initialization
		void Start ()
		{
				player = GameObject.FindGameObjectWithTag (Tags.PLAYER);
				pr_maxAngularError = 1;
		}
	
		// FixedUpdate is called once per frame
		void FixedUpdate ()
		{
				int direccition;
				
				pr_falsePlayerPosition = player.transform.position;
				pr_falsePlayerPosition.y = transform.position.y;
						
				if (cannons.GetComponent<ShootingAnim> ().ActivateShooting && Vector3.Angle (transform.right * -1, pr_falsePlayerPosition - transform.position) > pr_maxAngularError) {
					
					Quaternion lookAt = Quaternion.LookRotation(player.transform.position - transform.position);
					Debug.Log (lookAt);
					if ((lookAt.y > 0 && lookAt.y < 0.5)||lookAt.y < -0.5) {
						direccition = 1;
					} else {
						direccition = -1;
					}

					transform.RotateAround (Axis.transform.position, Vector3.up, direccition * RotationSpeed * Time.deltaTime);
				}
		}
	
}