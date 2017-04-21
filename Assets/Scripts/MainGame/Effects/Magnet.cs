using UnityEngine;
using System.Collections;

public class Magnet : Effects {

    private void Awake()
    {
        timeActive = 20.0f;
    }

    // Use this for initialization
    void Start () {
        base.Start();
	}
	
	// Update is called once per frame
	void FixedUpdate ()
    {
        Collider[] hitColliders = Physics.OverlapSphere(player.transform.position, 7f);
		Rotator[] touchedCoins = FindObjectsOfType<Rotator>();
        foreach (Collider coin in hitColliders)
        {
            if (coin.CompareTag("Pick Up"))
            {
                Vector3 magnetField = player.transform.position - coin.transform.position;
				if (coin.GetComponent<Rigidbody>() != null)
				{
					coin.GetComponent<Rigidbody>().velocity = 40 * magnetField.normalized;
				}
				coin.GetComponent<Rotator>().touched = true;
			}
        }
		foreach(Rotator coin in touchedCoins)
		{
			if (coin.touched)
			{
				Vector3 magnetField = player.transform.position - coin.transform.position;
				if (coin.GetComponent<Rigidbody>() != null)
				{
					coin.GetComponent<Rigidbody>().velocity = 40 * magnetField.normalized;
				}
			}
		}
    }
}
