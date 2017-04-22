using UnityEngine;
using System.Collections;

public class PlatformCoins : MonoBehaviour {

	private Rotator[] pickUps;
	public GameObject prefab;
	private Transform playerTransform;

	void Start ()
	{
		pickUps = GameObject.Find("Player").GetComponent<PlayerController>().pickUps;
		foreach (Rotator pickUp in pickUps)
		{
			GameObject inst = (GameObject)Instantiate(prefab, new Vector3(gameObject.transform.position.x - pickUp.transform.position.x, gameObject.transform.position.y + 0.8f, gameObject.transform.position.z - pickUp.transform.position.z + 9), Quaternion.identity);
			inst.GetComponent<Rotator>().isOriginal = false;
		}
	}

	void Update()
	{
		playerTransform = GameObject.Find("Player").GetComponent<Transform>();
		if (transform.position.z + PlayerController.destDist < playerTransform.position.z)
		{
			Destroy(this.gameObject);
		}
	}
}
