using UnityEngine;
using System.Collections;

public class FollowPlayer : MonoBehaviour {

	private GameObject Player;

	public static bool isInRange;

	// Use this for initialization
	void Start () {
		Player = GameObject.FindGameObjectWithTag ("Player");
	}
	
	// Update is called once per frame
	void Update () {
		if (isInRange) {
			transform.LookAt (Player.transform);
			GetComponentInChildren<Light> ().light.color = Color.red;
		} else {
			GetComponentInChildren<Light> ().light.color = Color.green;
		}
	}
}
