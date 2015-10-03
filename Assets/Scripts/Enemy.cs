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
		Vector2 targetPos = ourGenerator.ourPlayer.ourPos;
		Vector2 v = ourPos - targetPos;
		v /= Mathf.Max(v.x, v.y);
		Debug.Log (v.ToString());

	}
}
