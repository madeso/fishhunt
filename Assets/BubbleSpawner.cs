using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubbleSpawner : MonoBehaviour {
	public Bubble[] Bubbles;

	float RandomX()
	{
		return Random.Range(-offsetx, offsetx);
	}

	float RandomY()
	{
		return Random.Range(-offsety, offsety);
	}

	void Start () {
		for(int i=0; i<10; i+=1)
		{
			SpawnAt(RandomX(), RandomY());
		}
	}

	float offsetx = 10;
	float offsety = 4;

	void SpawnAt(float x, float y) {
		var index = Random.Range(0, Bubbles.Length-1);
		var template = Bubbles[index];
		var bubble = GameObject.Instantiate<Bubble>(template);
		bubble.transform.position = new Vector3(x, y, 0);
	}

	void SpawnAtBottom()
	{
		SpawnAt(RandomX(), -offsety);
	}

	float shotx = 0.4f;
	float shoty = 0.4f;
	int shotcount = 5;

	public void SpawnBubblesFromShot(float x, float y)
	{
		for(int i=0; i<shotcount; i += 1) {
			SpawnAt(Random.Range(-shotx, shotx)+x, Random.Range(-shoty, shoty)+y);
		}
	}

	float timer = 0;

	void Update () {
		timer -= Time.deltaTime * 1.5f;
		if(timer < 0 ) {
			timer += 1;
			SpawnAtBottom();
		}
	}
}
