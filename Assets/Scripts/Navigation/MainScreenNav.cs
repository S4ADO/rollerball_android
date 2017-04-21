﻿using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainScreenNav : MonoBehaviour {

	private Text welcome, score, balance;

	void Start()
	{
		if (SceneManager.GetActiveScene().name == "MainScreen")
		{
			welcome = GameObject.Find("WelcomeUsername").GetComponent<Text>();
			score = GameObject.Find("YourBalance").GetComponent<Text>();
			balance = GameObject.Find("YourTopScore").GetComponent<Text>();
			welcome.text = "Welcome";
			score.text = "Your Highscore: " + PlayerPrefs.GetInt("highscore", 0);
			balance.text = "Your Balance: " + PlayerPrefs.GetInt("balance", 0);
		}
	}

	public void play()
	{
		SceneManager.LoadScene("GameLevelOne");
	}

	public void howTo()
	{
		SceneManager.LoadScene("HowToPlay");
	}

	public void topScores()
	{
		SceneManager.LoadScene("TopScores");
	}

	public void back()
	{
		SceneManager.LoadScene("MainScreen");
	}

    public void shop()
    {
        SceneManager.LoadScene("Shop");
    }

	public void returnToMain()
	{
		SceneManager.LoadScene("MainScreen");
	}

    public void doExitGame()
    {
        Application.Quit();
    }
}
