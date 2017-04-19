using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

//TODO exceptions for cases which stop app e.g. login without net access

public class Login : MonoBehaviour
{
	private const string loginURL = "www.rollerball.x10.mx/includes/login.php";
	public readonly string secretKey = "1Lnt2ZSTS6Mdc3vrysav";
	private string email, password, emailHash;
	private Canvas failCanvas;

	void Awake()
	{
		DontDestroyOnLoad(this);
	}

	void Start()
	{
		failCanvas = GameObject.Find("LoginFailedCanvas").GetComponent<Canvas>();
		failCanvas.enabled = false;
	}

	public void doLogin()
	{
		email = GameObject.Find("EmailInputText").GetComponent<Text>().text;
		password = GameObject.Find("PasswordInputText").GetComponent<Text>().text;
		StartCoroutine("accountLogin");
	}

    public void skipLogin()
    {
        LoginDetails.email = "None";
        LoginDetails.password = "Saad1000";
        LoginDetails.emailHash = Hash.ShaHash("Saad1000");
        LoginDetails.setEffects();
		LoginDetails.money = 0;
        SceneManager.LoadScene("MainScreen");
    }

	public void incorrectDetials()
	{
		failCanvas.enabled = true;
		StartCoroutine("disableCanvas");
	}

	IEnumerator disableCanvas()
	{
		yield return new WaitForSeconds(4);
		failCanvas.enabled = false;
	}

	IEnumerator accountLogin()
	{
		WWWForm form = new WWWForm();
		form.AddField("Email", email);
		form.AddField("Password", password);

		WWW doLogin = new WWW(loginURL, form);
		yield return doLogin;
		if (doLogin.error != null)
		{
			Debug.LogError("Can't login: " + doLogin.error);
		}
		else
		{
			string doLoginReturn = doLogin.text;
			string[] doLoginSplit = doLoginReturn.Split(':');
			emailHash = Hash.hashString(email);
			if (doLoginSplit[0].Equals(emailHash.ToString()))
			{
				//we've logged in
				LoginDetails.email = this.email;
				LoginDetails.password = this.password;
				LoginDetails.emailHash = this.emailHash;
				LoginDetails.money = int.Parse(doLoginSplit[2]);
				LoginDetails.highScore = int.Parse(doLoginSplit[3]);
				LoginDetails.username = doLoginSplit[4];
				LoginDetails.increasedCoinValue = int.Parse(doLoginSplit[5]);
				LoginDetails.invincibility = int.Parse(doLoginSplit[6]);
				LoginDetails.doubleJump = int.Parse(doLoginSplit[7]);
				LoginDetails.barracade = int.Parse(doLoginSplit[8]);
				LoginDetails.magnet = int.Parse(doLoginSplit[9]);
				SceneManager.LoadScene("MainScreen");
			}
			else if (doLoginSplit[0] == "Login")
			{
				Debug.Log("incorrect details");
				incorrectDetials();
			}
			else
			{
				Debug.Log("form problems");
			}

		}
	}
}
