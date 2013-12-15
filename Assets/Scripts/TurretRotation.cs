//Coded by Luis Fletcher.
using UnityEngine;
using System.Collections;

public class TurretRotation : MonoBehaviour {

	private GameObject player;
	public GameObject lightAxis;
	public GameObject cannons;

	// Use this for initialization
	void Start () {
	
		player = GameObject.FindGameObjectWithTag (Tags.PLAYER);

	}
	
	// Update is called once per frame
	void Update () {

		if (cannons.GetComponent<ShootingAnim> ().ActivateShooting) {
						transform.RotateAround (lightAxis.transform.position, Vector3.up, 20 * Time.deltaTime);
				}
	}
}