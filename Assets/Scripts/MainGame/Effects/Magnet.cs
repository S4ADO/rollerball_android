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
        foreach (Collider coin in hitColliders)
        {
            if (coin.CompareTag("Pick Up"))
            {
                Vector3 magnetField = player.transform.position - coin.transform.position;
                float index = (20 - magnetField.magnitude) / 20;
				if (coin.GetComponent<Rigidbody>() != null)
				{
					coin.GetComponent<Rigidbody>().AddForce(25 * magnetField * index);
				}
            }
        }
    }
}
