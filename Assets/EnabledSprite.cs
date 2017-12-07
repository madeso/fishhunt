using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnabledSprite : MonoBehaviour {
	public Sprite EnabledGun;
	public Sprite DisabledGun;

	SpriteRenderer rend;

	public bool SpriteEnabled {get; set;}

	void Start () {
		rend = this.GetComponent<SpriteRenderer>();
		SetEnable();
	}
	
	public void SetEnable()
	{
		this.SpriteEnabled = true;
		rend.sprite = EnabledGun;
	}

	public void SetDisable()
	{
		this.SpriteEnabled = false;
		rend.sprite = DisabledGun;
	}
}
