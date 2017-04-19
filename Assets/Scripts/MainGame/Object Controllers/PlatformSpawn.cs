using UnityEngine;
using System.Collections;

public class PlatformSpawn : MonoBehaviour {

	public GameObject platform;
	private GameObject player;
	private GameObject platformInst;

	void Start()
	{
		player = GameObject.Find("Player");
		StartCoroutine("spawnPlatform");
	}

	IEnumerator spawnPlatform()
	{
		while (player.GetComponent<PlayerController>().alive)
		{
			yield return new WaitForSeconds(Random.Range(4, 8));
			spawnRandPlatform();
		}
	}

	void spawnRandPlatform()
	{
		Vector3 spawnPos = new Vector3(Random.Range(-20, 20), 
			player.transform.position.y < 3.5f ? 3 : spawnNextPlatformY()
			, player.transform.position.z + Random.Range(
				player.transform.position.y < 3.5f ? 55 : 20,
				player.transform.position.y < 3.5f ? 65 : 35
				));
		platformInst = (GameObject)Instantiate(platform, spawnPos, Quaternion.identity);
	}

	float spawnNextPlatformY()
	{
		float nextYPos = player.transform.position.y + Random.Range(0.5f, 3f);
		return nextYPos;
	}
}
