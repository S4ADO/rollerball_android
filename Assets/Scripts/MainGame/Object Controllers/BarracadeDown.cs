using UnityEngine;
using System.Collections;

public class BarracadeDown : MonoBehaviour {

	public GameObject barr1, barr2;
	private PlayerController player;
	private Transform groundTransform;

	void Start()
	{
		player = GameObject.Find("Player").GetComponent<PlayerController>();
		groundTransform = GameObject.Find("Ground").GetComponent<Transform>();
	}
	
	void Update () {
		if (player.GetComponent<Barracades>() == null && (barr1.transform.position.y > -1 || barr2.transform.position.y > -1))
		{
			barr1.transform.Translate(new Vector3(0, -1f, 0) * Time.deltaTime);
			barr2.transform.Translate(new Vector3(0, -1f, 0) * Time.deltaTime);
		}
	}

	void LateUpdate()
	{
		transform.position = new Vector3(transform.position.x, transform.position.y, groundTransform.position.z);
	}
}
