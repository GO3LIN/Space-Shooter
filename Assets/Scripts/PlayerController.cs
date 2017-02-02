using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Boundary {
	public float xMin, xMax, zMin, zMax;
}

public class PlayerController : MonoBehaviour {

	public float speed;
	public Boundary boundary;
	public float tilt;
	public GameObject shot;
	public Transform shotSpawn;
	public float fireRate = 0.25F;

	private Rigidbody player;
	private AudioSource sound;
	private float nextFire = 0.0F;

	// Use this for initialization
	void Start () {
		player = GetComponent<Rigidbody> ();
		sound = GetComponent<AudioSource> ();
	}
	
	// Update is called once per frame
	void Update(){
		if (Input.GetKey(KeyCode.Space) && Time.time > nextFire 
			|| Input.GetKey(KeyCode.Space) && Input.GetKeyDown (KeyCode.LeftArrow) && Time.time > nextFire){
			nextFire = Time.time + fireRate;	
			Instantiate (shot, shotSpawn.position, shotSpawn.rotation);
			sound.Play ();
		}
	}

	void FixedUpdate () {
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");

		Vector3 movement = new Vector3 (moveHorizontal, 0, moveVertical);
		player.velocity = movement * speed;
		player.position = new Vector3 (
			Mathf.Clamp(player.position.x, boundary.xMin, boundary.xMax),
			0.0f,
			Mathf.Clamp(player.position.z, boundary.zMin, boundary.zMax)
		);
		player.rotation = Quaternion.Euler (0.0f, 0.0f, player.velocity.x * tilt);
		
	}
}
