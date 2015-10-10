using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {
	public LevelGenerator ourGenerator;
	public Vector2 ourPos;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	public void Move()
	{
		Vector3 newPos = this.transform.position;
		Vector2 targetPos = ourGenerator.ourPlayer.ourPos;
		Vector2 v = new Vector2 (targetPos.x - ourPos.x, targetPos.y - ourPos.y); 
		Debug.Log (v);
/*
		if (Mathf.Abs(v.x) < Mathf.Abs(v.y) && v.x != 0  && ourGenerator.TileCheck(new Vector2(ourPos.x + CalculateMoveValue((int)v.x), ourPos.y))) {
			ourPos.x += CalculateMoveValue((int)v.x);
			newPos.x +=  CalculateMoveValue((int)v.x) * ourGenerator.padding;
			this.transform.position = newPos;
		} else if (Mathf.Abs(v.y) < Mathf.Abs(v.x) && v.y != 0 && ourGenerator.TileCheck(new Vector2(ourPos.x, ourPos.y + CalculateMoveValue((int)v.y)))) {
			ourPos.y += CalculateMoveValue((int)v.y);
			newPos.y += CalculateMoveValue((int)v.y) * ourGenerator.padding;
			this.transform.position = newPos;
		} else {
			Debug.Log("WHATG");
		}
		
*/
		//if x == 0 move y

		// if y == 0 move x

		// if x < y but != 0 move x
		// if y < x but != 0 move y

		// else dont move attack

		if ( (v.y == 0 || (Mathf.Abs(v.x) < Mathf.Abs(v.y) && v.x != 0))  && ourGenerator.TileCheck(new Vector2(ourPos.x + CalculateMoveValue((int)v.x), ourPos.y))) {
			ourPos.x += CalculateMoveValue((int)v.x);
			newPos.x +=  CalculateMoveValue((int)v.x) * ourGenerator.padding;
			this.transform.position = newPos;
		} else if ( (v.x == 0 || (Mathf.Abs(v.y) < Mathf.Abs(v.x) && v.y != 0) && ourGenerator.TileCheck(new Vector2(ourPos.x, ourPos.y + CalculateMoveValue((int)v.y))))) {
			ourPos.y += CalculateMoveValue((int)v.y);
			newPos.y += CalculateMoveValue((int)v.y) * ourGenerator.padding;
			this.transform.position = newPos;
		} else {
			FindAvailableMove(v);
		}
	}
	public void FindAvailableMove(Vector2 v)
	{
		Vector3 newPos = this.transform.position;
		Debug.Log ("PANIC");
	if ((Mathf.Abs (v.y) < Mathf.Abs (v.x)) && ourGenerator.TileCheck (new Vector2 (ourPos.x + CalculateMoveValue ((int)v.x), ourPos.y))) {
			ourPos.x += CalculateMoveValue ((int)v.x);
			newPos.x += CalculateMoveValue ((int)v.x) * ourGenerator.padding;
			this.transform.position = newPos;
		} else if ((Mathf.Abs (v.y) < Mathf.Abs (v.x)) && ourGenerator.TileCheck (new Vector2 (ourPos.x, ourPos.y + CalculateMoveValue ((int)v.y)))) {
			ourPos.y += CalculateMoveValue ((int)v.y);
			newPos.y += CalculateMoveValue ((int)v.y) * ourGenerator.padding;
			this.transform.position = newPos;
		} else {
			if(ourGenerator.TileCheck (new Vector2 (ourPos.x - CalculateMoveValue ((int)v.x), ourPos.y)))
			{
				ourPos.x -= CalculateMoveValue ((int)v.x);
				newPos.x -= CalculateMoveValue ((int)v.x) * ourGenerator.padding;
				this.transform.position = newPos;
			}
			else if(ourGenerator.TileCheck (new Vector2 (ourPos.x, ourPos.y - CalculateMoveValue ((int)v.y))))
			{
				ourPos.y -= CalculateMoveValue ((int)v.y);
				newPos.y -= CalculateMoveValue ((int)v.y) * ourGenerator.padding;
				this.transform.position = newPos;
			}
		}

	}

	public int CalculateMoveValue(int input)
	{
		if (input < 0) {
			return -1;
		}
		if (input > 0) {
			return 1;
		} else
			return 0;
	}
}
