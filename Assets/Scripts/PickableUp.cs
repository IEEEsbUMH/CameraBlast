using UnityEngine;
using System.Collections;

public class PickableUp : MonoBehaviour
{
		public int RotationSpeed;
		public GameObject BodyUp;
		public int PickupID;
		public bool MakeRespawn;
		public GameObject RespawnIn;
	

		// Update is called once per frame
		void FixedUpdate ()
		{
				transform.Rotate (0, RotationSpeed * Time.deltaTime, 0, Space.Self);
		}

		void OnTriggerEnter (Collider a_collider)
		{
				if (a_collider.gameObject.tag == Tags.PLAYER) {
						switch (PickupID) {
						case 1:
								a_collider.gameObject.GetComponent<CharacterMovement> ().jetpackIsAvailable = true;
								BodyUp.GetComponent<Animation_Player_Body> ().JetPack = true;
								break;
						case 0:
								a_collider.gameObject.GetComponent<PlayerShooting> ().ShootingIsAvailable = true;
								BodyUp.GetComponent<Animation_Player_Body> ().Poner = true;
								break;
						}
				}
				if (MakeRespawn)
						a_collider.gameObject.transform.position = RespawnIn.transform.position;
				Destroy (gameObject);
		}
}
