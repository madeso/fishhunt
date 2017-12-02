using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurtainControl : MonoBehaviour {

	public Transform CurtainLeft;
	public Transform CurtainRight;
	public Transform CurtainTop;

	public float CurtainHeight = 0.4f;
	public float CurtainWidth = 2.5f;

	float leftEnd;
	float rightEnd;
	float topEnd;

	float d = 0;

	public void SetPosition(float p)
	{
		d = p;
	}

	// Use this for initialization
	void Start () {
		leftEnd = CurtainLeft.position.x;
		rightEnd = CurtainRight.position.x;
		topEnd = CurtainTop.position.y;

		UpdatePosition();
	}

	void UpdatePosition()
	{
		var d1 = 1-d;
		SetX(CurtainLeft, leftEnd - d1*CurtainWidth);
		SetX(CurtainRight, rightEnd + d1*CurtainWidth);
		SetY(CurtainTop, topEnd + d1*CurtainHeight);
	}

	static void SetX(Transform t, float x)
	{
		var p = t.position;
		p.x = x;
		t.position = p;
	}

	static void SetY(Transform t, float y)
	{
		var p = t.position;
		p.y = y;
		t.position = p;
	}
	
	// Update is called once per frame
	void Update () {
		UpdatePosition();
	}
}
