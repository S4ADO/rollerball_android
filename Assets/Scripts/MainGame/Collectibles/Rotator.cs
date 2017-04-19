using UnityEngine;
using System.Collections;

public class Rotator : MonoBehaviour
{
	public bool isActive;
	public bool isOriginal;

	public void deactivate()
	{
		isActive = false;
	}

	void Start()
	{
		isActive = true;
		Invoke("Destroy", 100.0f);
	}

	void Update()
	{
		transform.Rotate(new Vector3(45, 30, 15) * Time.deltaTime);
	}

	void Destroy()
	{
		if (!isOriginal)
		{
			Destroy(this.gameObject);
		}
	}
}
