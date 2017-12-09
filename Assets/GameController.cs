using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {
	public IntroMove[] intros;
	public GunControl gun;
	public FadeIn fadein;

	public AudioClip Ready;
	public AudioClip Begin;

	public AudioClip Multikill;
	public AudioClip ComboBreaker;

	public AudioClip Three;
	public AudioClip Two;
	public AudioClip One;

	public AudioClip Win;
	public AudioClip Flawless;

	enum State
	{
		Idle, Ready, Game, Game3, Game2, Win, Score
	}

	State state = State.Idle;
	float timer = 0;

	bool fired = false;

	// Use this for initialization
	void Start ()
	{
	}

	int killcount = 0;
	public void NotifyKill()
	{
		killcount += 1;
	}

	int lastkillcount = 0;

	void NewGame()
	{
		lastkillcount = 0;
		killcount = 0;
		fired = false;
		// setup max ammo
	}

	void LateUpdate()
	{
		if( fired )
		{
			if(killcount > 1 )
			{
				Play(Multikill);
			}

			if( lastkillcount > 0 && killcount == 0 )
			{
				Play(ComboBreaker);
			}

			lastkillcount = killcount;
			killcount = 0;
			fired = false;
		}
	}

	void OnGame()
	{
		if(GunControl.IsFireInput())
		{
			if(gun.FireGun())
			{
				fired = true;
			}
		}
	}

	void SetState(State n)
	{
		this.state = n;
		this.timer = 0;
	}

	void SetPositions(float d)
	{
		fadein.SetPosition(d);
		foreach(var intro in intros)
		{
			intro.SetPosition(d);
		}
	}

	void Play(AudioClip clip)
	{
		AudioSource.PlayClipAtPoint(clip, this.transform.position);
	}
	
	// Update is called once per frame
	void Update ()
	{
		if(state != State.Idle)
		{
			this.timer += Time.deltaTime;
		}
		
		switch(state)
		{
		case State.Idle:
			SetPositions(0);
			if(GunControl.IsFireInput())
			{
				SetState(State.Ready);
				Play(Ready);
				NewGame();
			}
			break;
		case State.Ready:
			SetPositions(timer);
			if(timer > 1)
			{
				SetState(State.Game);
				Play(Begin);
			}
			break;
		case State.Game:
			SetPositions(1);
			OnGame();
			if(timer > 15)
			{
				SetState(State.Game3);
				Play(Three);
			}
			break;
		case State.Game3:
			SetPositions(1);
			OnGame();
			if(timer > 1)
			{
				SetState(State.Game2);
				Play(Two);
			}
			break;
		case State.Game2:
			SetPositions(1);
			OnGame();
			if(timer > 1)
			{
				SetState(State.Win);
				Play(One);
			}
			break;
		case State.Win:
			SetPositions(1-timer);
			if(timer > 1)
			{
				SetState(State.Score);
				Play(Win);
			}
			break;
		case State.Score:
			SetPositions(0);
			if(timer > 1)
			{
				SetState(State.Idle);
				Play(Flawless);
			}
			break;
		}
	}
}
