using UnityEngine;
using System.Collections;

public class ObstacleSpawn : MonoBehaviour {

	public GameObject[] obstacles;
	private GameObject obstacleInstance;
	private GameObject player;
	private int obstacleNo;

	private Vector3 obstacleDist;

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
			yield return new WaitForSeconds(Random.Range(2, 5));
			spawnRandObstacle();
		}
	}

	void spawnRandObstacle()
	{
		Vector3 playerPosZ = new Vector3(Random.Range(-20, 20), 0, player.transform.position.z);
		obstacleInstance = (GameObject)Instantiate(obstacles[obstacleNo], playerPosZ + obstacleDist, obstacles[obstacleNo].transform.rotation);
		obstacleNo = Random.Range(0, obstacles.Length);
		obstacleDist = new Vector3(0, 0, Random.Range(18.0f + player.GetComponent<Rigidbody>().velocity.z, 50.0f + player.GetComponent<Rigidbody>().velocity.z));
	}
}
