using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishMove : MonoBehaviour {
	// Use this for initialization
	void Start () {
	}

	float Speed = 1;
	
	// Update is called once per frame
	void Update () {
		this.transform.position = this.transform.position + new Vector3(1, 0, 0)*this.Speed * Time.deltaTime;
	}
}
