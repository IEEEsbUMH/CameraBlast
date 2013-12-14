//Coded by Luis Fletcher.
using UnityEngine;
using System.Collections;

public class TurretRotation : MonoBehaviour {

	private GameObject player;
	private Vector3 targetDirection;

	// Use this for initialization
	void Start () {
	
		player = GameObject.FindGameObjectWithTag (Tags.PLAYER);


	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
