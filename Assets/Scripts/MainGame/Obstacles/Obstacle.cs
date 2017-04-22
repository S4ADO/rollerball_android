using UnityEngine;
using System.Collections;

public class Obstacle : MonoBehaviour {

	private Transform playerTransform;

	protected void OnTriggerEnter(Collider player)
	{
		if (player.GetComponent<PlayerController>() != null)
		{
			if (player.GetComponent<PlayerController>().alive == true && player.GetComponent<Invincibility>() == null)
			{
				player.GetComponent<PlayerController>().die();
			}
		}
	}

	protected void Update()
	{
		playerTransform = GameObject.Find("Player").GetComponent<Transform>();
		if (transform.position.z + PlayerController.destDist < playerTransform.position.z)
		{
			Destroy(this.gameObject);
		}
	}
}
