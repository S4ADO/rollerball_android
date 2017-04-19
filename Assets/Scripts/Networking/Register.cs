using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Register : MonoBehaviour
{
	private const string registerURL = "www.rollerball.x10.mx/register.php";
	private string email, password, username;
	private Canvas success, fail;

	void Start()
	{
		success = GameObject.Find("RegisterSucceedCanvas").GetComponent<Canvas>();
		fail = GameObject.Find("RegisterFailedCanvas").GetComponent<Canvas>();
		success.enabled = false;
		fail.enabled = false;
	}

	public void correctDetials()
	{
		success.enabled = true;
		StartCoroutine("disableCanvas");
	}

	public void DoRegister()
	{
		email = GameObject.Find("EmailRegInputText").GetComponent<Text>().text;
		password = GameObject.Find("PasswordRegInputText").GetComponent<Text>().text;
		username = GameObject.Find("UsernameRegInputText").GetComponent<Text>().text;
		StartCoroutine("sendRegForm");
	}

	IEnumerator disableCanvas()
	{
		yield return new WaitForSeconds(4);
		success.enabled = false;
	}

	IEnumerator sendRegForm()
	{
		WWWForm registerForm = new WWWForm();
		registerForm.AddField("email", email);
		registerForm.AddField("p", Hash.ShaHash(password));
		registerForm.AddField("username", username);
		WWW doReg = new WWW(registerURL, registerForm);
		yield return doReg;
		correctDetials();
	}
}