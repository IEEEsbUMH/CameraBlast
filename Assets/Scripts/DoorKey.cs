//Coded by Miguel Catalan
using UnityEngine;
using System.Collections;

public class DoorKey : MonoBehaviour {

	public GameObject[] Cameras;
	public GameObject LeftDoor;
	public GameObject RightDoor;

	private bool open = false;

	// Update is called once per frame
	void Update () {
		if(!Checker ()&& !open){
			OpenDoor();
		}
	}

	void OpenDoor(){
		LeftDoor.transform.position = new Vector3 (LeftDoor.transform.position.x+0.8f,LeftDoor.transform.position.y,LeftDoor.transform.position.z);
		RightDoor.transform.position = new Vector3 (RightDoor.transform.position.x-0.8f,RightDoor.transform.position.y,RightDoor.transform.position.z);
		open = true;
	}

	private bool Checker () {
		for(int i =0; i<Cameras.Length;i++){
			bool isAlive = Cameras[i].GetComponent<TakeDamage>().Alive;
			if(isAlive){
				return true;
			}
		}
		return false;
	}
}
