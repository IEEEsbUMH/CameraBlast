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
			FollowPlayer(true);
			CheckforWalls ();
		} else {
			if(isPlayer){
				FollowPlayer(false);
			}
		}

	}

	public void FollowPlayer(bool isFollowing){
		CameraRotation.isInRange = isFollowing;
		isPlayer = isFollowing;
	}

	void CheckforWalls(){
		RaycastHit hit;
		if (Physics.Raycast (transform.position, player.transform.position-transform.position, out hit)) {
			if(hit.collider.tag == "Walls"){
				FollowPlayer(false);
			}
		}
	}
}
