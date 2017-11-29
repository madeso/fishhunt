using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishMove : MonoBehaviour {
	// Use this for initialization
	void Start () {
		t = Random.value;
	}

	float y = 0;
	int mul = 1;
	float t = 0;

	float Speed = 1;
	float SinSize = 0.1f;

	
	// Update is called once per frame
	void Update () {
		this.t += Time.deltaTime;
		if(t > 1) t-= 1;

		var p = this.transform.position + new Vector3(1, 0, 0)*this.Speed * Time.deltaTime * this.mul;
		p.y = y + Mathf.Sin(Mathf.PI * 2 * t) * SinSize;
		this.transform.position = p;


		if(this.transform.position.x > 10 && mul == 1) {
			Object.Destroy(this.gameObject);
		}
		if(this.transform.position.x < -10 && mul == -1) {
			Object.Destroy(this.gameObject);
		}
	}

	public void SetRight(bool right)
	{
		var sp = this.GetComponent<SpriteRenderer>();
		sp.flipX = right;
		this.mul = right ? -1 : 1;
		this.y = this.transform.position.y;
	}
}
