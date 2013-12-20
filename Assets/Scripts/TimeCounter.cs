using UnityEngine;
using System.Collections;

public class TimeCounter : MonoBehaviour
{
		public float counter;
		public static bool pauseTime;
		public GUIText TimeGUIText;
	
		// Update is called once per frame
		void Update ()
		{
				if (!pauseTime) {
						counter += Time.deltaTime;
						TimeGUIText.text = "Tiempo: " + counter.ToString ("0.00") + "s";
				}
		}
}