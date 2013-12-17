using UnityEngine;
using System.Collections;

public class Animation_Player_Body : MonoBehaviour
{
		public GameObject Parent;
		public Animator _animPlayer;
		public float _axisZ;
		public float _axisX;
		public bool TimePassAtack;
		public bool JetPack = false;
		public bool Reload = false;
		public bool Poner = false;
		protected bool FirstTime = false;
		void Update ()
		{
				_axisZ = Input.GetAxis ("Vertical");
				_axisX = Input.GetAxis ("Horizontal");
				if (Poner == true) {
						_animPlayer.SetBool ("PonerPorPrimeraVez", true);
						if (JetPack == false) {
								//
								if (_axisZ > 0.1 || _axisZ < -0.1) {
										_animPlayer.SetFloat ("Walk_Z", _axisZ);
										_animPlayer.SetBool ("Jump", false);
								}
								if (_axisZ < 0.1 || _axisZ > -0.1) {
										_animPlayer.SetFloat ("Walk_Z", _axisZ);
										_animPlayer.SetBool ("Jump", false);
								}
								//
								if (_axisX > 0.1 || _axisX < -0.1) {
										_animPlayer.SetFloat ("Walk_X", _axisX);
										_animPlayer.SetBool ("Jump", false);
								}
								if (_axisX > -0.1 || _axisX < 0.1) {
										_animPlayer.SetFloat ("Walk_X", _axisX);
										_animPlayer.SetBool ("Jump", false);
								}
								//
								if (Input.GetAxis (AxesManager.Jump) > 0.01) {
										_animPlayer.SetBool ("Jump", true);
								}
								if (Input.GetAxis (AxesManager.Fire) > 0 && Parent.GetComponent<PlayerShooting> ().CurrentAmmo > 0) {
										_animPlayer.SetBool ("Atack", true);
								} else {
										_animPlayer.SetBool ("Atack", false);
								}
								if (Reload == true) {
										_animPlayer.SetBool ("Reload", true);
								} else {
										_animPlayer.SetBool ("Reload", false);
								}
						}
						if (JetPack == true) {
								FirstTime = true;
								_animPlayer.SetBool ("JetPack", true);
						} else if (FirstTime == true) {
								_animPlayer.SetBool ("JetPack", false);
						}
				}
		}
}