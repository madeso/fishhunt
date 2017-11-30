using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnabledSprite : MonoBehaviour {
	public Sprite EnabledGun;
	public Sprite DisabledGun;

	SpriteRenderer rend;

	void Start () {
		rend = this.GetComponent<SpriteRenderer>();
	}
	
	public void SetEnable()
	{
		rend.sprite = EnabledGun;
	}

	public void SetDisable()
	{
		rend.sprite = DisabledGun;
	}
}
