using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateWhenNotEnabled : MonoBehaviour {
	float rspeed = -1.5f;

	float rot = 0;

	EnabledSprite enabled;

	// Use this for initialization
	void Start () {
		enabled = this.GetComponent<EnabledSprite>();
	}
	
	// Update is called once per frame
	void Update ()
	{
		if(this.enabled.SpriteEnabled)
		{
			rot = 0;
		}
		else
		{
			rot += Time.deltaTime*rspeed;
			if(rot > 1) rot -= 1;
		}
		this.transform.localRotation = Quaternion.Euler(0, 0, rot*360);
	}
}
