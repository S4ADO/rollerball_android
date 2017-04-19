using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour
{
	public Rigidbody player;
	private Vector3 offset;
	// Use this for initialization
	void Start ()
	{
		offset = transform.position - player.transform.position; // +new Vector3(0.0f, 0.0f, 0.0f); - transform.position is property of vector3 class
	}
	
	void LateUpdate ()
	{
		transform.position = player.transform.position + offset;
	}
}