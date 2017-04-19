using UnityEngine;
using System.Collections;

public class Obstacle : MonoBehaviour {

	protected void Start()
	{
		Invoke("DestroyThis", 75);
	}

	void DestroyThis()
	{
		Destroy(this.gameObject);
	}

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
}
