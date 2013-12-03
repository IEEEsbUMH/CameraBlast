//Code written by Luis Fletcher
using UnityEngine;
using System.Collections;

public class ShootingAnim : MonoBehaviour {
	
	public GameObject cannons;
	public int speedrotation; //ALWAYS set to 1.
	public int accrotation; //ALWAYS set to 10.
	public bool activateshooting;
	public AudioSource shootingsound;
	public AudioSource shootingstart;
	public AudioSource shootingfinish;

	void Start () 
	{

	}
	
	void Update () 
	{
		if (activateshooting) {

			if (speedrotation < 900) {
				speedrotation += accrotation;
				Shooting ();
				if(shootingstart.isPlaying==false){
					shootingstart.Play(30000);
					shootingstart.pitch=0.5f;
				}
			} else {
				Shooting ();
				shootingstart.Stop();
				if(shootingsound.isPlaying==false){
					shootingsound.Play();
				}
			}
		} else {
			shootingsound.Stop();
			if(speedrotation>0){
				speedrotation-=accrotation;
				Shooting();
				if(speedrotation>600 && shootingfinish.isPlaying==false){
					shootingfinish.Play();
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

