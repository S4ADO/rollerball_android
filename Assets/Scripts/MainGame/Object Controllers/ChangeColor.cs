using UnityEngine;
using System.Collections;

public class ChangeColor : MonoBehaviour {

    private Color[] colors;
    int curColor = 0;
    float curTime = 0;

    private Color green1, green2, green3;

    private void Start()
    {
        green1 = new Color(0.9f,1.0f,0.38f);
        green2 = new Color(0.8f,0.9f, 0.25f);
        green3 = new Color(0.75f, 0.9f, 0.38f);
        colors = new Color[3] { green1, green2, green3};

    }

    // Update is called once per frame
    void Update () {
        if ((int)Time.time % 20 == 0 && (int)Time.time != curTime)
        {
            GetComponent<MeshRenderer>().material.color = colors[curColor];
            curColor = curColor >= 2 ? 0 : curColor + 1;
            curTime = (int)Time.time;
        }
	}
}
