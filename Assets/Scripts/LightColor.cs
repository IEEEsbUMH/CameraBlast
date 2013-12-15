//Coded by Luis Fletcher. Edited by Héctor Barreras
using UnityEngine;
using System.Collections;

public class LightColor : MonoBehaviour
{

		public GameObject Cannons;
		public GameObject TurretLight;
		public GameObject FalseLight;

		// Use this for initialization
		void Start ()
		{
				changeColors (Color.green);
		}
	
		// Update is called once per frame
		void Update ()
		{
				if (Cannons.GetComponent<ShootingAnim> ().ActivateShooting && Cannons.GetComponent<ShootingAnim> ().SpeedRotation < 900) {
						changeColors (Color.yellow);
				} else if (Cannons.GetComponent<ShootingAnim> ().SpeedRotation >= 900) {
						changeColors (Color.red);
				} else {
						changeColors (Color.green);
				}

		}

		void changeColors (Color a_color)
		{
				TurretLight.GetComponent<Light> ().color = a_color;
				FalseLight.GetComponent<Light> ().color = a_color;
		}
}
