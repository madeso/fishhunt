using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bubble : MonoBehaviour {

	// Use this for initialization
	void Start () {
		weight = Random.Range(0.5f, 1.0f);
	}

	float weight = 1;
	
	// Update is called once per frame
	void Update () {
		var p = this.transform.position;
		p.y += Time.deltaTime * weight;
		if(p.y > 6) {
			GameObject.Destroy(this.gameObject);
		}
		this.transform.position = p;
	}
}
