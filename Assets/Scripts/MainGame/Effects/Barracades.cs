using UnityEngine;
using System.Collections;

public class Barracades : Effects {

    private GameObject barr1, barr2;

    private void Awake()
    {
        timeActive = 20.0f;
    }
	void Start ()
    {
        base.Start();
        barr1 = GameObject.Find("Barracade1");
        barr2 = GameObject.Find("Barracade2");
	}

    private void Update()
    {
        if (barr1.transform.position.y <= 1.25f || barr2.transform.position.y <= 1.25f)
        {
            barr1.transform.Translate(new Vector3(0, 1f, 0) * Time.deltaTime);
            barr2.transform.Translate(new Vector3(0, 1f, 0) * Time.deltaTime);
        }
    }
}
