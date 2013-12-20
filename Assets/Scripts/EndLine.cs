//Coded by MiguelCatalan and edited by Hector
using UnityEngine;
using System.Collections;

public class EndLine : MonoBehaviour
{
		public GameObject VictoryGUI;

		void OnTriggerEnter (Collider other)
		{
				if (other.gameObject.tag == Tags.PLAYER) {
						VictoryGUI.SetActive (true);
						TimeCounter.pauseTime = true;
						Debug.Log("trol");
				}
		}
}
