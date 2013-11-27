using UnityEngine;
using System.Collections;

public class CameraRotation : MonoBehaviour {
	
	public GameObject startObject;
	public GameObject endObject;
	public int speed;
	
	private Vector3 movement;
	private Vector3 inverseMovement;
	private Vector3 rotate;

	private Quaternion startRotation;
	private Quaternion endRotation;


	void Start () {
		
		transform.LookAt (startObject.transform.position);
		startRotation = Quaternion.Euler(transform.rotation.x,transform.rotation.y,0);
		startRotation.z = 0;
		
		transform.LookAt (endObject.transform.position);
		endRotation = Quaternion.Euler(transform.rotation.x,transform.rotation.y,0);
		endRotation.z = 0;
		movement = new Vector3(endRotation.x - startRotation.x,endRotation.y - startRotation.y,0);
		movement.z = 0;
		inverseMovement = new Vector3(-movement.x,-movement.y,0);
		inverseMovement.z = 0;
		
		rotate = movement;
		
		Debug.Log ("Start: x:"+startRotation.x+" y:"+startRotation.y+" z:"+startRotation.z);
		Debug.Log ("End: x:"+endRotation.x+" y:"+endRotation.y+" z:"+endRotation.z);
		transform.rotation = startRotation;
	}

	void Update () {
		if(endObject != null){
			ChangePosition(); 
		}
	}
	
	void ChangePosition(){
		Quaternion currentRotation = Quaternion.Euler(transform.rotation.x,transform.rotation.y,transform.rotation.z);
		Debug.Log ("Current: x:"+currentRotation.x+" y:"+currentRotation.y+" z:"+currentRotation.z);
		if (currentRotation == startRotation) {
			Debug.Log ("Moves");
			rotate =  movement;
		}else if(currentRotation == endRotation){
			Debug.Log ("Inverse Move");
			rotate =  inverseMovement;
		}
		rotate.z = 0;
		transform.Rotate (rotate,Time.deltaTime*speed);
	}

}