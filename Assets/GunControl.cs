using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunControl : MonoBehaviour {

	public PositionAtCursor Aim;
	public RiflePosition Gun;
	public BubbleSpawner Spawner;
	public AmmoCount Ammo;
	public FireScale FireScale;

	public AudioClip FireSfx;
	public AudioClip ChamberRoundSfx;
	public AudioClip PumpShotgunSfx;

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
			Play(FireSfx);
			KillFish();
			Ammo.Shoot();
			FireScale.Fire();
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
					Play(PumpShotgunSfx);
					SetEnabled();
				}
				else 
				{
					Ammo.LoadBullet();
					Play(ChamberRoundSfx);
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

	void Play(AudioClip clip)
	{
		AudioSource.PlayClipAtPoint(clip, this.transform.position);
	}
}
