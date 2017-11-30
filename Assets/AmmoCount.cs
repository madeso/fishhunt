using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoCount : MonoBehaviour {
	public SpriteRenderer[] BulletGraphics;
	public Sprite LoadedSprite;
	public Sprite EmptySprite;

	int bullets = 0;

	public bool HasMoreBullets()
	{
		return bullets > 0;
	}

	public void Shoot()
	{
		bullets -= 1;
		UpdateGraphics();
	}

	public void LoadBullet()
	{
		bullets += 1;
		UpdateGraphics();
	}

	public bool IsFull()
	{
		return bullets >= BulletGraphics.Length;
	}

	// Use this for initialization
	void Start ()
	{
		bullets = this.BulletGraphics.Length;
		UpdateGraphics();
	}

	void UpdateGraphics()
	{
		for(int i=0; i<BulletGraphics.Length; i+=1)
		{
			var loaded = i < bullets;
			BulletGraphics[i].sprite = loaded ? LoadedSprite : EmptySprite;
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
