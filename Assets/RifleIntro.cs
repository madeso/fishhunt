using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RifleIntro : MonoBehaviour {
	float d = 0;

	float y;

	public float height = 10;

	public void SetPosition(float d)
	{
		this.d = d;
	}

	// Use this for initialization
	void Start ()
	{
		y = this.transform.position.y;
		UpdatePosition();
	}

	void UpdatePosition()
	{
		float d1 = 1-d;
		CurtainControl.SetY(this.transform, y - height*d1);
	}
	
	// Update is called once per frame
	void Update () {
		UpdatePosition();	
	}
}
