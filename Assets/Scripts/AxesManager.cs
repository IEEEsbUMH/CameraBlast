using UnityEngine;
using System.Collections;

public class AxesManager : MonoBehaviour
{
		public static string CameraX;
		public static string CameraY;
		public static string Jump;
		public static string Jetpack;
		public static string Fire;
		public static string Reload;
		public static string Restart;

		static public void Init ()
		{
				if (Application.platform == RuntimePlatform.OSXPlayer || Application.platform == RuntimePlatform.OSXEditor) {
						CameraX = "Camera X_MAC";
						CameraY = "Camera Y_MAC";
						Jump = "Jump_MAC";
						Jetpack = "Jetpack_MAC";
						Fire = "Fire_MAC";
						Reload = "Reload_MAC";
						Restart = "Restart_MAC";
				} else {
						CameraX = "Camera X_WIN";
						CameraY = "Camera Y_WIN";
						Jump = "Jump_WIN";
						Jetpack = "Jetpack_WIN";
						Fire = "Fire_WIN";
						Reload = "Reload_WIN";
						Restart = "Restart_WIN";
				}
		}
}
