using UnityEngine;
using System.Collections;

public class Animation_Player_Piernas : MonoBehaviour
{
		public Animator _animPlayer_pies;
		public float _axisZ;
		public float _axisX;
		void Update ()
		{
				_axisZ = Input.GetAxis ("Vertical");
				_axisX = Input.GetAxis ("Horizontal");
				//
				if (_axisZ > 0.1 || _axisZ < -0.1) {
						_animPlayer_pies.SetFloat ("Walk_Z", _axisZ);
						_animPlayer_pies.SetBool ("Jump", false);
				}
				if (_axisZ < 0.1 || _axisZ > -0.1) {
						_animPlayer_pies.SetFloat ("Walk_Z", _axisZ);
						_animPlayer_pies.SetBool ("Jump", false);
				}
				//
				if (_axisX > 0.1 || _axisX < -0.1) {
						_animPlayer_pies.SetFloat ("Walk_X", _axisX);
						_animPlayer_pies.SetBool ("Jump", false);
				}
				if (_axisX > -0.1 || _axisX < 0.1) {
						_animPlayer_pies.SetFloat ("Walk_X", _axisX);
						_animPlayer_pies.SetBool ("Jump", false);
				}
				//
				if (Input.GetButton (AxesManager.Jump)) {
						_animPlayer_pies.SetBool ("Jump", true);
				}
		}
}