using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HighScores : MonoBehaviour {

	private const string hischScoresURL = "www.rollerball.x10.mx/includes/highscores.php";
	private Text user1, user2, user3, user4, user5, score1, score2, score3, score4, score5;
	private Text[] users, scores;
	private int itrNumber = 0;

	void Start ()
	{
		user1 = GameObject.Find("User1").GetComponent<Text>();
		user2 = GameObject.Find("User2").GetComponent<Text>();
		user3 = GameObject.Find("User3").GetComponent<Text>();
		user4 = GameObject.Find("User4").GetComponent<Text>();
		user5 = GameObject.Find("User5").GetComponent<Text>();
		score1 = GameObject.Find("Score1").GetComponent<Text>();
		score2 = GameObject.Find("Score2").GetComponent<Text>();
		score3 = GameObject.Find("Score3").GetComponent<Text>();
		score4 = GameObject.Find("Score4").GetComponent<Text>();
		score5 = GameObject.Find("Score5").GetComponent<Text>();
		users = new Text[5] { user1, user2, user3, user4, user5 };
		scores = new Text[5] { score1, score2, score3, score4, score5 };
		StartCoroutine("Scores");
	}

	IEnumerator Scores()
	{
		WWW highscores = new WWW(hischScoresURL);
		yield return highscores;
		string scoreText = highscores.text;
		string[] scoreSplit = scoreText.Split('#');
		foreach (string userSplit in scoreSplit)
		{
			if (scoreSplit.Length >= 2)
			{
				string[] scoreInfo = userSplit.Split(':');
				if (userSplit.Length >= 2)
				{
					string username = scoreInfo[0];
					int score = int.Parse(scoreInfo[1]);
					users[itrNumber].text = username;
					scores[itrNumber].text = score.ToString();
					itrNumber++;
				}
			}
		}
	}
}
