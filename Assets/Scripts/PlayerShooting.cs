﻿//Code edited by Miguel Catalan
using UnityEngine;
using System.Collections;

public class PlayerShooting : MonoBehaviour
{
		public AudioSource shotSound;
		public GameObject POV;
		public GameObject ShotFrom;
		public LineRenderer ShotLine;
		public int ClipSize;
		public int TimeBetweenShots;
		public int TimeShotStaying;
		public GUIText AmmoText;
		public bool ShootingIsAvailable;
		public float CurrentAmmo {
				get {
						return pr_bulletsLeft;
				}
		}

		protected float pr_bulletsLeft;
		protected Vector3 pr_lookDirection;
		protected int pr_currentTime;
		protected float myTimer = 0.3f;

		// Use this for initialization
		void Start ()
		{
				pr_bulletsLeft = ClipSize;
				ShotLine.enabled = false;
				updateAmmoText ();
		}
	
		// Update is called once per frame
		void FixedUpdate ()
		{
				if (ShootingIsAvailable) {
						pr_currentTime++;
						pr_lookDirection = POV.transform.forward;

						if (pr_currentTime == TimeShotStaying) {
								ShotLine.enabled = false;
						}
						if (Input.GetAxis (AxesManager.Fire) > 0) {
								if (myTimer > 0) {
										myTimer -= Time.deltaTime;
								}
								if (myTimer <= 0) {
										shoot ();
								}
					
						} else {
								myTimer = 0.3f;
						}
						if (Input.GetAxis (AxesManager.Reload) > 0) {

								reload ();
						}
				}
		}

		void shoot ()
		{
				if (pr_bulletsLeft > 0 && pr_currentTime >= TimeBetweenShots) {
						pr_bulletsLeft--;
						pr_currentTime = 0;

						ShotLine.enabled = true;
						shotSound.Play ();
						Ray t_ray = new Ray (POV.transform.position, pr_lookDirection);
						RaycastHit t_rayHit;

						if (Physics.Raycast (t_ray, out t_rayHit, 50)) {
								ShotLine.SetPosition (1, t_rayHit.point);

								if (t_rayHit.collider.gameObject.tag == Tags.CAMERA_BODY) {
										t_rayHit.collider.gameObject.GetComponent<TakeDamage> ().Die ();
								}

						} else {
								ShotLine.SetPosition (1, ShotFrom.transform.position + pr_lookDirection * 10);
						}
						ShotLine.SetPosition (0, ShotFrom.transform.position);
				}
				updateAmmoText ();
		}

		void reload ()
		{
				pr_bulletsLeft = ClipSize;
				updateAmmoText ();
		}

		void updateAmmoText ()
		{
				AmmoText.text = pr_bulletsLeft.ToString () + "/" + ClipSize.ToString ();
				AmmoText.color = Color.Lerp (Color.green, Color.red, 1 - (pr_bulletsLeft / ClipSize));
		}
}
