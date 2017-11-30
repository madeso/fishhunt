using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunControl : MonoBehaviour {

	public PositionAtCursor Aim;
	public RiflePosition Gun;
	public BubbleSpawner Spawner;
	public AmmoCount Ammo;

	public EnabledSprite[] SpriteStates;

	float reloadTime = 0.3f;

	// Use this for initialization
	void Start ()
	{
		SetEnabled();
	}

	void SetEnabled()
	{
		foreach(var e in SpriteStates)
		{
			e.SetEnable();
		}
	}

	void SetDisable()
	{
		foreach(var e in SpriteStates)
		{
			e.SetDisable();
		}
	}

	void KillFish()
	{
		var p = Aim.transform.position;
		var colliders = Physics2D.OverlapCircleAll(new Vector2(p.x, p.y), 0.3f);
		foreach(var collider in colliders)
		{
			var kill = collider.gameObject.GetComponent<ClickToKill>();
			if(kill == null) continue;
			kill.Kill();
			// todo: support multikill bonuses
		}
	}

	bool loading = false;
	float t = 0;

	void FireGun() {
		if( Ammo.HasMoreBullets() )
		{
			KillFish();
			Ammo.Shoot();
			this.Gun.FireGun();
			var p = this.Aim.transform.position;
			this.Spawner.SpawnBubblesFromShot(p.x, p.y);

			if(!Ammo.HasMoreBullets())
			{
				loading = true;
				t = 0;
				SetDisable();
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
					SetEnabled();
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
