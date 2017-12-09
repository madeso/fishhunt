using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeIn : MonoBehaviour {
	SpriteRenderer rend;

	// Use this for initialization
	void Start () {
		rend = this.GetComponent<SpriteRenderer>();
	}

	public void SetPosition(float f)
	{
		var c = rend.color;
		c.a = f;
		rend.color = c;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
