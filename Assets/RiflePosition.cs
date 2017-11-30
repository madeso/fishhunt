using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RiflePosition : MonoBehaviour {
	Vector3 relative;

	float d = 0;

	Vector3 displace = new Vector3(1, -1, 0);

	// Use this for initialization
	void Start () {
		this.relative = this.transform.position;
	}

	float width = 3;
	float height = 2;

	public void FireGun()
	{
		d = 1;
	}
	
	// Update is called once per frame
	void Update () {
		if(d > 0 ) {
			d -= Time.deltaTime;
		}
		else {
			d = 0;
		}

		var p = Input.mousePosition;
		var x = (p.x / Screen.width)*2 - 1;
		var y = (p.y / Screen.height)*2 - 1;

		this.transform.position = this.relative + new Vector3(x*this.width, y*this.height) + displace * d;
	}
}
