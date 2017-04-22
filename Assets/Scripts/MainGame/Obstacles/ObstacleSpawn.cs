using UnityEngine;
using System.Collections;

public class ObstacleSpawn : MonoBehaviour {

	public GameObject[] obstacles;
	private GameObject obstacleInstance;
	private GameObject player;
	private int obstacleNo;
	private Vector3 obstacleDist;
	private Obstacle[] obstaclesInGame;

	void Start()
	{
		obstacleNo = 0;
		player = GameObject.Find("Player");
		obstacleDist = new Vector3(0, 0, 5);
		StartCoroutine("spawnObstacle");
	}

	IEnumerator spawnObstacle()
	{
		while (player.GetComponent<PlayerController>().alive)
		{
			yield return new WaitForSeconds(0.1f);
			spawnRandObstacle();
		}
	}

	void spawnRandObstacle()
	{
		obstaclesInGame = FindObjectsOfType<Obstacle>();
		if (obstaclesInGame.Length < 50)
		{
			Vector3 instPos = new Vector3(Random.Range(-20, 20), 0,
				obstacleInstance == null ? player.transform.position.z : obstacleInstance.transform.position.z);
			obstacleInstance = (GameObject)Instantiate(obstacles[obstacleNo], instPos + obstacleDist, obstacles[obstacleNo].transform.rotation);
			obstacleNo = Random.Range(0, obstacles.Length);
			obstacleDist = new Vector3(0, 0, Random.Range(18.0f, 40.0f));
		}
	}
}
