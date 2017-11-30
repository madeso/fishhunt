using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositionAtCursor : MonoBehaviour {

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		var p =  Camera.main.ScreenToWorldPoint(Input.mousePosition);
		p.z = 0;
		this.transform.position = p;
	}
}
