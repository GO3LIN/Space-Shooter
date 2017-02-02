using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByTime : MonoBehaviour {

	public float timeout;

	// Use this for initialization
	void Start () {
		Destroy (gameObject, timeout);
	}
}
