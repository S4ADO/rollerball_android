using UnityEngine;
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
			if (LoginDetails.email != "None")
			{
				welcome.text = "Welcome " + LoginDetails.username;
				score.text = "Your Highscore: " + LoginDetails.highScore;
				balance.text = "Your Balance: " + LoginDetails.money;
			}
			else
			{
				welcome.text = string.Empty;
				score.text = string.Empty;
				balance.text = string.Empty;
			}
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
