using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunControl : MonoBehaviour {

	public PositionAtCursor Aim;
	public RiflePosition Gun;
	public BubbleSpawner Spawner;
	public AmmoCount Ammo;

	float reloadTime = 0.3f;

	// Use this for initialization
	void Start () {
	}

	bool loading = false;
	float t = 0;

	void FireGun() {
		if( Ammo.HasMoreBullets() )
		{
			Ammo.Shoot();
			this.Gun.FireGun();
			var p = this.Aim.transform.position;
			this.Spawner.SpawnBubblesFromShot(p.x, p.y);

			if(!Ammo.HasMoreBullets())
			{
				loading = true;
				t = 0;
				Gun.SetDisable();
			}
		}
	}
	
	// Update is called once per frame
	void Update () {
		if(loading)
		{
			t += Time.deltaTime;
			if(t > reloadTime) {
				t -= reloadTime;

				if(Ammo.IsFull() )
				{
					loading = false;
					// cock gun
					Gun.SetEnable();
				}
				else 
				{
					Ammo.LoadBullet();
				}
			}
		}
		else
		{
			if(Input.GetMouseButtonDown(0)) {
				FireGun();
			}
		}
	}
}
