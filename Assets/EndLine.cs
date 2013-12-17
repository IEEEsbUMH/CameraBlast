using UnityEngine;
using System.Collections;

public class EndLine : MonoBehaviour
{
		public GameObject VictoryGUI;
		public TimeCounter TimeCounterBehaviour;
		void OnTriggerEnter (Collider other)
		{
				if (other.gameObject.tag == Tags.PLAYER) {
						VictoryGUI.SetActive (true);
						TimeCounterBehaviour.pauseTime = true;
				}
		}
}
