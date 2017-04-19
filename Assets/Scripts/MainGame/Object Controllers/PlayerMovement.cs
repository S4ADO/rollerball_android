using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour
{

	public static bool moveLeft;
	public static bool moveRight;
	public static bool jumpClick;

	public static float timeSinceLastLeftClick = 0, timeSinceLastRightClick = 0;

	public void jumpClicked()
	{
		jumpClick = true;
	}

	public void MoveMeLeft()
	{
		moveLeft = true;
	}

	public void StopMeLeft()
	{
		moveLeft = false;
		timeSinceLastLeftClick = Time.time;
	}

	public void MoveMeRight()
	{
		moveRight = true;
	}
	public void StopMeRight()
	{
		moveRight = false;
		timeSinceLastRightClick = Time.time;
	}
}
