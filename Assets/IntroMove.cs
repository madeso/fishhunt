using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntroMove : MonoBehaviour {
	float d = 0;

	float y;
	float x;

	public float dy = 0;
	public float dx = 0;

	public void SetPosition(float d)
	{
		this.d = d;
	}

	// Use this for initialization
	void Start ()
	{
		x = this.transform.localPosition.x;
		y = this.transform.localPosition.y;

		UpdatePosition();
	}

	void UpdatePosition()
	{
		float d1 = 1-d;
		var p = this.transform.localPosition;
		p.x = x + dx*d1;
		p.y = y + dy*d1;
		this.transform.localPosition = p;
	}
	
	// Update is called once per frame
	void Update () {
		UpdatePosition();
	}
}
