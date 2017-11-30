using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickToKill : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	}

	public void Kill()
	{
		Object.Destroy(this.gameObject);
	}
}
