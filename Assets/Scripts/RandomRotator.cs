using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomRotator : MonoBehaviour {

	public float tumble;

	private Rigidbody asteroid;

	// Use this for initialization
	void Start () {
		asteroid = GetComponent<Rigidbody> ();
		asteroid.angularVelocity = Random.insideUnitSphere * tumble;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
