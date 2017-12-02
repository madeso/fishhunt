using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wiggle : MonoBehaviour {
	float d;
	float r;

	float rot = 5;
	float rspeed = 1.5f;

	// Use this for initialization
	void Start () {
		d = Random.Range(0, 1);
		r = this.transform.rotation.z;
	}
	
	// Update is called once per frame
	void Update () {
		d += Time.deltaTime * rspeed;
		if (d > 1) d -= 1;
		var nr = this.transform.rotation.eulerAngles;
		nr.z = rot*Mathf.Sin(d* Mathf.PI*2);
		this.transform.rotation = Quaternion.Euler(nr);

	}
}
