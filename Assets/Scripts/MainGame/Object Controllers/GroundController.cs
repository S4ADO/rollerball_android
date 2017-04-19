using UnityEngine;
using System.Collections;

public class GroundController : MonoBehaviour {

    private Transform PlayerTransform;
	// Use this for initialization
	void Start () {
        PlayerTransform = GameObject.Find("Player").GetComponent<Transform>();
	}
	
	// Update is called once per frame
	void LateUpdate () {
        transform.position = new Vector3(transform.position.x, transform.position.y, PlayerTransform.position.z);
	}
}
