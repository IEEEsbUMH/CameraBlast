//Coded by Miguel Catalan Bañuls
using UnityEngine;
using System.Collections;

public class CameraVision : MonoBehaviour {

	public int rangeVision;

	private GameObject player;
	private Vector3 forward;
	private Vector3 targetDirection;

	private bool isPlayer;

	// Use this for initialization
	void Start () {
		isPlayer = false;
		player = GameObject.FindGameObjectWithTag ("Player");
	}
	
	// Update is called once per frame
	void Update () {
		targetDirection = player.transform.position - transform.position;
		forward = transform.forward;
		float angle = Vector3.Angle(targetDirection, forward);
		float distance = Vector3.Distance (transform.position, player.transform.position);
		if (angle < 25.0F && distance < rangeVision) {
			CameraRotation.isInRange = true;
			isPlayer = true;
		} else {
			if(isPlayer){
				CameraRotation.isInRange = false;
				isPlayer = false;
			}
		}

	}
}
