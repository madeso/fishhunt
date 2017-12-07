using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireScale : MonoBehaviour {
	float lscale = 1;
	float speed = 5;
	float timer = 0;

	// Use this for initialization
	void Start () {
	}

	public void Fire()
	{
		timer += 1f;
	}
	
	// Update is called once per frame
	void Update () {
		if(timer > 0 ) timer -= Time.deltaTime * speed;
		if(timer < 0) timer = 0;

		var scale = 1 + lscale*timer;
		this.transform.localScale = new Vector3(scale, scale,scale);
	}
}
