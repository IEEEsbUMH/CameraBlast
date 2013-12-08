using UnityEngine;
using System.Collections;

public class CameraVision : MonoBehaviour {

	private GameObject player;
	private Vector3 forward;
	private Vector3 targetDirection;

	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag ("Player");
	}
	
	// Update is called once per frame
	void Update () {
		targetDirection = player.transform.position - transform.position;
		forward = transform.forward;
		float angle = Vector3.Angle(targetDirection, forward);
		if(angle < 25.0F){
			FollowPlayer.isInRange = true;
			CameraRotation.isInRange = true;
		}
	}
}
