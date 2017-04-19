using UnityEngine;
using UnityEngine.UI;

public class ShowHideCanvas : MonoBehaviour
{
	private Canvas loginCanvas, registerCanvas;
	private string curCanvas;

	private void Start ()
	{
		loginCanvas = GameObject.Find("LoginCanvas").GetComponent<Canvas>();
		registerCanvas = GameObject.Find("RegisterCanvas").GetComponent<Canvas>();
		registerCanvas.enabled = false;
		curCanvas = "Login";
	}

	public void changeCanvas()
	{
		if (curCanvas.Equals("Login"))
		{
			loginCanvas.enabled = false;
			registerCanvas.enabled = true;
			curCanvas = "Register";
			GameObject.Find("ButtonNavText").GetComponent<Text>().text = "LOGIN!";
		}
		else if (curCanvas.Equals("Register"))
		{
			loginCanvas.enabled = true;
			registerCanvas.enabled = false;
			curCanvas = "Login";
			GameObject.Find("ButtonNavText").GetComponent<Text>().text = "REGISTER!";
		}
		else
		{
			Debug.LogError("Canvas string curCanvas does not match any given state!");
		}
	}
}
