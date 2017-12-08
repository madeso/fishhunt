using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {
	public IntroMove[] intros;

	float d = 0;

	bool fired = false;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		if( fired )
		{
			d += 2.1f * Time.deltaTime;
			if(d > 1) d = 1;
		}
		else
		{
			if(GunControl.IsFireInput())
			{
				fired = true;
			}
		}

		foreach(var intro in intros)
		{
			intro.SetPosition(d);
		}
	}
}
