using UnityEngine;
using System.Collections;

public class Rotator : MonoBehaviour
{
	public bool isActive;
	public bool isOriginal;
	public bool touched = false;

	private Transform playerTransform;

	public void deactivate()
	{
		isActive = false;
	}

	void Start()
	{
		isActive = true;
	}

	void Update()
	{
		transform.Rotate(new Vector3(45, 30, 15) * Time.deltaTime);

		if (!isOriginal)
		{
			playerTransform = GameObject.Find("Player").GetComponent<Transform>();
			if (transform.position.z + PlayerController.destDist < playerTransform.position.z)
			{
				Destroy(this.gameObject);
			}
		}
	}
}
