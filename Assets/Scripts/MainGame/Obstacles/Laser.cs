using UnityEngine;
using System.Collections;

public class Laser : Obstacle
{
	private bool goingForward;
	private Vector3 initialTransform;

	void Start()
	{
		base.Start();
		transform.position = new Vector3(0, Random.Range(0.0f, 4.0f), transform.position.z);
		initialTransform = transform.position;
		goingForward = (int)Time.time % 2 == 0 ? true : false;
	}

	void FixedUpdate()
	{
		if (goingForward)
		{
			GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 2);
			if (transform.position.z >= initialTransform.z + 5)
			{
				goingForward = false;
			}
		}
		else
		{
			GetComponent<Rigidbody>().velocity = new Vector3(0, 0, -2);
			if (transform.position.z <= initialTransform.z - 5)
			{
				goingForward = true;
			}
		}
	}
}
