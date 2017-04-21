using UnityEngine;
using System.Collections;

public class LoginDetails : MonoBehaviour {

	public static string email, password, emailHash, username;

	void Awake()
	{
		DontDestroyOnLoad(this);
		Screen.orientation = ScreenOrientation.Landscape;
		if(PlayerPrefs.GetInt("balance", 0) < 10)
			PlayerPrefs.SetInt("balance", 500000);
	}
}