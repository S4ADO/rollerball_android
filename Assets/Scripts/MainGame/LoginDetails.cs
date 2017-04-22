using UnityEngine;
using System.Collections;

public class LoginDetails : MonoBehaviour {

	public static string email, password, emailHash, username;

	void Awake()
	{
		DontDestroyOnLoad(this);
		Screen.orientation = ScreenOrientation.Landscape;
	}
}