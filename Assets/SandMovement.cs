using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SandMovement : MonoBehaviour {
	public float d = 0;

	float size = 0.1f;
	float speed = 0.3f;

	float s;

	// Use this for initialization
	void Start () {
		s = this.transform.position.y;
	}
	
	// Update is called once per frame
	void Update () {
		d += Time.deltaTime * speed;
		if(d > 1) d-=1;
		var np = this.transform.position;
		np.y = s + size * Mathf.Sin(d * Mathf.PI * 2f);
		this.transform.position = np;
	}
}
