using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {
	public float tileSize;
	public LevelGenerator ourGenerator;
	public Vector2 ourPos;
	// Use this for initialization
	void Start () {
		ourPos = new Vector2 (1, 1);
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 newPos = this.transform.position;
		if (Input.GetKeyDown (KeyCode.W)) {

			if(ourGenerator.TileCheck(new Vector2(ourPos.x, ourPos.y+1)))
			{

			

				newPos.y += tileSize;
				this.transform.position = newPos;
				ourPos.y += 1;
				ourGenerator.CheckForKills(new Vector2(ourPos.x, ourPos.y +1));
				ourGenerator.UpdateEnemies();
			}
		}
		else if (Input.GetKeyDown (KeyCode.S)) {
			if(ourGenerator.TileCheck(new Vector2(ourPos.x, ourPos.y-1)))
			{
				newPos.y -= tileSize;
				this.transform.position = newPos;
				ourPos.y -=1;
				ourGenerator.CheckForKills(new Vector2(ourPos.x, ourPos.y -1));
				ourGenerator.UpdateEnemies();
			}
		}
		else if (Input.GetKeyDown (KeyCode.A)) {

			if(ourGenerator.TileCheck(new Vector2(ourPos.x-1, ourPos.y)))
			{
				ourPos.x -= 1;
				newPos.x -= tileSize;
				this.transform.position = newPos;
				ourGenerator.CheckForKills(new Vector2(ourPos.x -1, ourPos.y));
				ourGenerator.UpdateEnemies();
			}
		}
		else if (Input.GetKeyDown (KeyCode.D)) {
			if(ourGenerator.TileCheck(new Vector2(ourPos.x +1, ourPos.y)))
			{
				ourPos.x += 1;
				newPos.x += tileSize;
				this.transform.position = newPos;
				ourGenerator.CheckForKills(new Vector2(ourPos.x +1, ourPos.y));
				ourGenerator.UpdateEnemies();
			}
		}

			


	}
}
