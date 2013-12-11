//Code written by Luis Fletcher
using UnityEngine;
using System.Collections;

public class ShootingAnim : MonoBehaviour {
	
	public GameObject cannons;
	public int speedrotation; //ALWAYS set to 1.
	public int accrotation; //ALWAYS set to 10.
	public bool activateshooting;
	public AudioSource turretsound;
	public AudioClip shootingsound;
	public AudioClip shootingstart;
	public AudioClip shootingfinish;

	void Update () 
	{
		if (activateshooting) {

			if (speedrotation < 900) {
				speedrotation += accrotation;
				Shooting ();
				turretsound.clip=shootingstart;
				if(turretsound.isPlaying==false){
					turretsound.pitch=0.4f;
					turretsound.Play(25000);
				}
			} else {
				Shooting ();
				turretsound.clip=shootingsound;
				turretsound.pitch=1;
				turretsound.loop=false;
				if(turretsound.isPlaying==false){
					turretsound.Play();
				}
			}
		} else {
			if(speedrotation>0){
				speedrotation-=accrotation;
				Shooting();
				turretsound.clip=shootingfinish;
				if(speedrotation>600 && turretsound.isPlaying==false){
					turretsound.pitch=0.4f;
					turretsound.Play();
				}
			}else{
				speedrotation=0;
			}
		}
				
	}

	void Shooting ()
	{
		transform.Rotate (0, 0, Time.deltaTime * speedrotation);

	}
}

