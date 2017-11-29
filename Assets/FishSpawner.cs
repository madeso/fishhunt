using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishSpawner : MonoBehaviour {

	// Use this for initialization
	void Start () {
	}

	float d = 0;


	float spawn = 1.0f;
	float offsetx = 10;
	float offsety = 3;

	public FishMove fish_template;
	
	// Update is called once per frame
	void Update () {
		d -= Time.deltaTime;
		if(d < 0 ) {
			SpawnFish();
			d += spawn;
		}
	}

	void SpawnFish()
	{
		var fish = GameObject.Instantiate<FishMove>(fish_template);
		var right = Random.value > 0.5f;
		var dx = (right?1:-1) * offsetx;
		var dy = Random.Range(-offsety, offsety);
		fish.transform.position = this.transform.position + new Vector3(dx, dy);
		fish.SetRight(right);
	}
}
