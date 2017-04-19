using UnityEngine;
using System.Collections;

public class Effects : MonoBehaviour {

    protected float timeActive;
    protected PlayerController player;

    protected void Start()
    {
        player = GameObject.Find("Player").GetComponent<PlayerController>();
        Invoke("Dest", timeActive);
    }

    private void Dest()
    {
        Destroy(this);
    }
}
