using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {
	CurtainControl curtains;

	float d = 0;

	// Use this for initialization
	void Start () {
		curtains = GetComponent<CurtainControl>();
	}
	
	// Update is called once per frame
	void Update () {
		d += 0.1f * Time.deltaTime;
		if(d > 1) d = 1;

		curtains.SetPosition(d);
	}
}
