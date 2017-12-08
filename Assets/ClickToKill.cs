using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickToKill : MonoBehaviour {
	public Skeleton Skeleton;

	SpriteRenderer rend;

	GameController gc;

	// Use this for initialization
	void Start () {
		rend = GetComponent<SpriteRenderer>();

		var gco = GameObject.Find("GameController");
		if(gco == null)
		{
			Debug.Log("Failed to find gc object");
		}
		else
		{
			this.gc = gco.GetComponent<GameController>();
		}

		if(this.gc == null)
		{
			Debug.Log("Failed to find gc");
		}
	}
	
	// Update is called once per frame
	void Update ()
	{
	}

	public void Kill()
	{
		Object.Destroy(this.gameObject);
		if( this.gc != null )
		{
			this.gc.NotifyKill();
		}

		if(this.Skeleton == null)
		{
			Debug.Log(string.Format("No skeleton for {0}", this.name));
		}
		else
		{
			Skeleton sk = GameObject.Instantiate(Skeleton);
			sk.gameObject.transform.position = this.transform.position;
			sk.SetOrientation(rend.flipX);
		}
	}
}
