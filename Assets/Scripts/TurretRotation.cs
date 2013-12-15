//Coded by Luis Fletcher. Edited by Héctor Barreras
using UnityEngine;
using System.Collections;

public class TurretRotation : MonoBehaviour
{		
		public GameObject Axis;
		public GameObject cannons;
		public float RotationSpeed;

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
				pr_falsePlayerPosition = player.transform.position;
				pr_falsePlayerPosition.y = transform.position.y;

				
				if (cannons.GetComponent<ShootingAnim> ().ActivateShooting && Vector3.Angle (transform.right * -1, pr_falsePlayerPosition - transform.position) > pr_maxAngularError) {
						transform.RotateAround (Axis.transform.position, Vector3.up, RotationSpeed * Time.deltaTime);
				}
		}
}