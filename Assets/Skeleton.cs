using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skeleton : MonoBehaviour {
	SpriteRenderer rend;

	bool flipped;

	// Use this for initialization
	void Start () {
		rend = GetComponent<SpriteRenderer>();
		rend.flipX = flipped;
	}

	float speed = 0.5f;
	
	// Update is called once per frame
	void Update () {
		var p = this.transform.position;
		p.y -= Time.deltaTime * speed;
		if(p.y < -6 )
		{
			GameObject.Destroy(this.gameObject);
		}
		this.transform.position = p;
	}

	public void SetOrientation(bool flipx)
	{
		this.flipped = flipx;
	}
}
