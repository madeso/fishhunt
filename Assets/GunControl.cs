using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunControl : MonoBehaviour {

	public PositionAtCursor Aim;
	public RiflePosition Gun;
	public BubbleSpawner Spawner;

	// Use this for initialization
	void Start () {
		
	}

	void FireGun() {
		this.Gun.FireGun();
		var p = this.Aim.transform.position;
		this.Spawner.SpawnBubblesFromShot(p.x, p.y);
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetMouseButtonDown(0)) {
			FireGun();
		}
	}
}
