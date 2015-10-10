using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class LevelGenerator : MonoBehaviour {

	public int dungeonSize;
	public Tile[,] tiles;
	public GameObject floorPrefab;
	public GameObject wallPrefab;
	public GameObject stairsPrefab;
	public GameObject playerPrefab;
	public GameObject enemyPrefab;
	public float padding;
	public float randomFactor;
	public Player ourPlayer;
	public List<Enemy> enemies = new List<Enemy>();
	public bool spawnedOrc = false;
	// Use this for initialization
	void Start () {
		tiles = new Tile[dungeonSize, dungeonSize];
		GenerateDungeon ();
	}

	void GenerateDungeon()
	{
		for(int y=0; y < dungeonSize; y++)
		{
			for(int x =0; x < dungeonSize; x++)
			{

				//IF WALL
				if(x == dungeonSize -2 && y == dungeonSize -2)
				{
					GameObject newTile = GameObject.Instantiate(stairsPrefab, new Vector3 (x * padding, y * padding, 0), Quaternion.identity) as GameObject;
					tiles[x,y] = newTile.GetComponent<Tile>();
					newTile.transform.parent = this.gameObject.transform;
				}
				else if(x== 0 || y == 0 || y == dungeonSize -1 || x == dungeonSize -1)
				{
					//RANDOM CREAMY MIDDLE
					GameObject newTile = GameObject.Instantiate(wallPrefab, new Vector3 (x * padding, y * padding, 0), Quaternion.identity) as GameObject;
					tiles[x,y] = newTile.GetComponent<Tile>();
					newTile.transform.parent = this.gameObject.transform;
				}
				else if(x == 1 || y == 1 || y == dungeonSize -2 || x == dungeonSize -2)
				{
					GameObject newTile = GameObject.Instantiate(floorPrefab, new Vector3 (x * padding, y * padding, 0), Quaternion.identity) as GameObject;
					tiles[x,y] = newTile.GetComponent<Tile>();
					newTile.transform.parent = this.gameObject.transform;
				}
				else if(Random.Range(0f, 100f) > randomFactor)
				{
					if(Random.Range (0f, 100f) < randomFactor && !spawnedOrc)
					{
						GameObject enemy = GameObject.Instantiate(enemyPrefab, new Vector3 (x * padding, y * padding, 0), Quaternion.identity) as GameObject;
						Enemy e = enemy.GetComponent<Enemy>();
						e.ourGenerator = this;
						enemies.Add(e);
						e.ourPos = new Vector2(x,y);
						spawnedOrc = true;
					}
					GameObject newTile = GameObject.Instantiate(wallPrefab, new Vector3 (x * padding, y * padding, 0), Quaternion.identity) as GameObject;
					tiles[x,y] = newTile.GetComponent<Tile>();
					newTile.transform.parent = this.gameObject.transform;
				}
				else
				{

					GameObject newTile = GameObject.Instantiate(floorPrefab, new Vector3 (x * padding, y * padding, 0), Quaternion.identity) as GameObject;
					tiles[x,y] = newTile.GetComponent<Tile>();
					newTile.transform.parent = this.gameObject.transform;
				}
				//IF WALKWAY

				//RANDOM CREAMY MIDDLE

			}
		}

		Vector3 newPos = tiles [1, 1].transform.position;
		newPos.z = -5;

		GameObject player = GameObject.Instantiate(playerPrefab, newPos, Quaternion.identity) as GameObject;
		ourPlayer = player.GetComponent<Player> ();
		ourPlayer.ourGenerator = this;


	}

	public bool TileCheck(Vector2 desiredPos)
	{
		Debug.Log ("CHECKING " + desiredPos.ToString ());
		if (tiles [(int)desiredPos.x, (int)desiredPos.y].isExit) {
			Debug.Log ("YOUR WINNER");
			Reset();
			return true;
		} else if (tiles [(int)desiredPos.x, (int)desiredPos.y].isWalkable) {

			return true;
		} else {
			return false;
		}
	}

	public void UpdateEnemies()
	{
		foreach (Enemy enemy in enemies) {
			enemy.Move();
		}
	}

	public void CheckForKills(Vector2 pos)
	{
		Enemy toKill = null;

		foreach (Enemy enemy in enemies) {
			if(enemy.ourPos == pos)
			{
				toKill = enemy;
			}
		}
		if (toKill != null) {
			enemies.Remove(toKill);
			Destroy(toKill.gameObject);
		}
	}

	public void Reset()
	{
		foreach (Tile tile in tiles) {
			Destroy(tile.gameObject);
		}
		Destroy (ourPlayer.gameObject);
		GenerateDungeon ();
	}

}
