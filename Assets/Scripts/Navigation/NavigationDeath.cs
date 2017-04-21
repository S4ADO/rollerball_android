using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class NavigationDeath : MonoBehaviour {
    private PlayerController player;
    private Canvas deathCanvas;
    private Text ScoreText, CoinsText;
	// Use this for initialization
	void Start ()
	{
        player = GameObject.Find("Player").GetComponent<PlayerController>();
        deathCanvas = GetComponent<Canvas>();
        deathCanvas.enabled = false;
        ScoreText = GameObject.Find("YouScoredText").GetComponent<Text>();
        CoinsText = GameObject.Find("CoinsCollectedText").GetComponent<Text>();
    }
	
	// Update is called once per frame
	void Update ()
	{
        if (player.alive == false && deathCanvas.enabled != true)
        {
            Invoke("ShowNav", 1.7f);
            ScoreText.text = "YOU SCORED: " + (int)player.timeInGame;
            CoinsText.text = "COINS COLLECTED: " + player.score;
			//Save prefs
			PlayerPrefs.Save();
		}
	}

    public void goToMainMenu()
    {
        SceneManager.LoadScene("MainScreen");
    }

    void ShowNav()
    {
        deathCanvas.enabled = true;
    }
}
