using UnityEngine;
using System.Collections;

public class Restart : MonoBehaviour
{
		// Update is called once per frame
		void FixedUpdate ()
		{
				if (Input.GetAxis (AxesManager.Restart) > 0) {
						//print ("Restarting...");
						Application.LoadLevel ("Level1");
				}
		}
}
