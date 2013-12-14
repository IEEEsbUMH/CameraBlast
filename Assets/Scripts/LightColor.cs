//Coded by Luis Fletcher.
using UnityEngine;
using System.Collections;

public class LightColor : MonoBehaviour {

	public GameObject Cannons;
	public GameObject TurretLight;

	// Use this for initialization
	void Start () {
		TurretLight.GetComponent<Light>().color = Color.green;
	}
	
	// Update is called once per frame
	void Update () {
		if (Cannons.GetComponent<ShootingAnim>().ActivateShooting && Cannons.GetComponent<ShootingAnim>().SpeedRotation < 900) {
			TurretLight.GetComponent<Light>().color = Color.yellow;
		} else if (Cannons.GetComponent<ShootingAnim>().SpeedRotation == 900) {
			TurretLight.GetComponent<Light>().color = Color.red;
		} else{
			TurretLight.GetComponent<Light>().color = Color.green;
		}

	}
}
