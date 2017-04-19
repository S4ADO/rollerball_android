using UnityEngine;
using System.Collections;

public class LoginDetails : MonoBehaviour {

	public static string email, password, emailHash, username;
    public static int magnet, doubleJump, invincibility, increasedCoinValue, barracade, highScore, money;

	void Awake()
	{
		DontDestroyOnLoad(this);
		Screen.orientation = ScreenOrientation.Landscape;
	}

    public static void setEffects()
    {
        magnet = 2;
        doubleJump = 2;
        invincibility = 2;
        increasedCoinValue = 2;
        barracade = 2;
    }
}