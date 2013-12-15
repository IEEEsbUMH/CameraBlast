//Coded by Luis Fletcher.
using UnityEngine;
using System.Collections;

public class TurretRotation : MonoBehaviour {

	private GameObject player;
	public GameObject legs;

	// Use this for initialization
	void Start () {
	
		player = GameObject.FindGameObjectWithTag (Tags.PLAYER);

	}
	
	// Update is called once per frame
	void Update () {

		transform.RotateAround(legs.transform.position,Vector3.up,20*Time.deltaTime);
	}
}