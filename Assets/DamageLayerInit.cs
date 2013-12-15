using UnityEngine;
using System.Collections;

public class DamageLayerInit : MonoBehaviour
{
		void Start ()
		{
				GetComponent<GUITexture> ().pixelInset = new Rect (0, 0, Screen.width, Screen.height);
		}
}
