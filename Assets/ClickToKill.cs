using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickToKill : MonoBehaviour {
	public Skeleton Skeleton;

	SpriteRenderer rend;

	// Use this for initialization
	void Start () {
		rend = GetComponent<SpriteRenderer>();
	}
	
	// Update is called once per frame
	void Update () {
	}

	public void Kill()
	{
		Object.Destroy(this.gameObject);

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
