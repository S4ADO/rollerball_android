using UnityEngine;
using UnityEngine.UI;

public class SettingsNav : MonoBehaviour {

	private Text sound, movement;

	void Start ()
	{
		sound = GameObject.Find("ToggleSoundText").GetComponent<Text>();
		movement = GameObject.Find("ToggleMovementText").GetComponent<Text>();

		sound.text = PlayerPrefs.GetInt("sound", 1) == 1 ? "On" : "Off";
		movement.text = PlayerPrefs.GetInt("movement", 0) == 0 ? "Buttons" : "Tilt";
	}

	public void toggleMovement()
	{
		PlayerPrefs.SetInt("movement", PlayerPrefs.GetInt("movement", 0) == 0 ? 1 : 0);
		movement.text = PlayerPrefs.GetInt("movement", 0) == 0 ? "Buttons" : "Tilt";
	}

	public void toggleSound()
	{
		PlayerPrefs.SetInt("sound", PlayerPrefs.GetInt("sound", 1) == 0 ? 1 : 0);
		sound.text = PlayerPrefs.GetInt("sound", 1) == 1 ? "On" : "Off";
	}
}
