using UnityEngine;
using System.Collections;

public class BarracadeDown : MonoBehaviour {

	public GameObject barr1, barr2;
	private PlayerController player;

	void Start()
	{
		player = GameObject.Find("Player").GetComponent<PlayerController>();
	}
	
	void Update () {
		if (player.GetComponent<Barracades>() == null && (barr1.transform.position.y > -1 || barr2.transform.position.y > -1))
		{
			barr1.transform.Translate(new Vector3(0, -1f, 0) * Time.deltaTime);
			barr2.transform.Translate(new Vector3(0, -1f, 0) * Time.deltaTime);
		}
	}
}
