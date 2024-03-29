﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

//TODO: Player prefs for highscores and inventories

public class PlayerController : MonoBehaviour
{
	//private const string scoreURL = "www.rollerball.x10.mx/includes/updateScore.php";
	//private const string effectURL = "www.rollerball.x10.mx/includes/effect.php";

	public Rigidbody sphere;
	private Vector3 movement;
	public static float destDist = 100f;

	public Text logText;
	private int jumpNumber = 0;
	private float leftAxis, rightAxis;
	private float movementVelocity;
	private bool useButtons = true;

	private float moveUp;

	public int score;
	public int coinValue = 1;
	public float timeInGame;
	private Text scoreText;
	private int cubeInactiveCount = 0;
	public Rotator[] pickUps;

	public GameObject prefab;
	private int timeDone = 0;
	private float velocityDone = 0;
	float curTime;
	private Text scoreTimeText, invText, djText, brText, mgText, tcText;

	public bool alive = true;


	float startTouchPosition = 0, endTouchPosition = 0;

	void Awake()
	{
		scoreText = GameObject.Find("Score").GetComponent<Text>();
		sphere = GetComponent<Rigidbody>();
	}

	void Start()
	{
		if (PlayerPrefs.GetInt("movement") == 1)
		{
			useButtons = false;
		}

		if (!useButtons)
		{
			GameObject leftButton = GameObject.Find("LeftButton");
			GameObject rightButton = GameObject.Find("RightButton");
			leftButton.SetActive(false);
			rightButton.SetActive(false);
		}

		scoreTimeText = GameObject.Find("ScoreTime").GetComponent<Text>();
		invText = GameObject.Find("Invincibility").GetComponent<Text>();
		djText = GameObject.Find("DoubleJump").GetComponent<Text>();
		brText = GameObject.Find("Barracades").GetComponent<Text>();
		mgText = GameObject.Find("Magnet").GetComponent<Text>();
		tcText = GameObject.Find("IncreaseValue").GetComponent<Text>();
		timeInGame = 0;
		leftAxis = 0;
		rightAxis = 0;
		movementVelocity = 0.175f;
		score = 0;
		setScore();
		pickUps = GameObject.FindObjectsOfType<Rotator>();
		foreach (Rotator pickUp in pickUps)
		{
			pickUp.isOriginal = true;
		}
	}

	void Update()
	{
		if (GetComponent<increasedCoinValue>() != null)
		{
			coinValue = 3;
		}
		else
		{
			coinValue = 1;
		}
		if ((int)Time.time % 8 == 0 && (int)Time.time != 0 && timeDone != (int)Time.time)
		{
			float randXPos = Random.Range(-18f, 18f);
			foreach (Rotator pickUp in pickUps)
			{
				GameObject inst = (GameObject)Instantiate(prefab, new Vector3(randXPos - pickUp.transform.position.x, 0.5f, pickUp.transform.position.z + (transform.position.z + (5.0f * ((int)Time.time) / 3))), Quaternion.identity);
				inst.GetComponent<Rotator>().isOriginal = false;
			}
			timeDone = (int)Time.time;
		}
		//Falls off the map
		if (transform.position.y < -5 && alive)
		{
			die();
		}

		//jump();
		checkJump();
	}

	void LateUpdate()
	{
		scoreTimeText.text = "Score: " + (int)timeInGame;
		invText.text = "Invincibility: " + PlayerPrefs.GetInt("invincibility", 0);
		djText.text = "Double Jump: " + PlayerPrefs.GetInt("doublejump", 0);
		brText.text = "Barracades: " + PlayerPrefs.GetInt("barracades", 0);
		mgText.text = "Magnets: " + PlayerPrefs.GetInt("magnet", 0);
		tcText.text = "Increased coin value: " + PlayerPrefs.GetInt("increasedcoinvalue", 0);
	}

	void FixedUpdate()
	{
		if (alive)
		{
			timeInGame += 0.02f;
		}

		if (useButtons)
		{
			if (PlayerMovement.moveLeft)
			{
				leftAxis = leftAxis <= -1 ? -1 : leftAxis -= 0.02f;
			}
			else
			{
				leftAxis = 0;
			}

			if (PlayerMovement.moveRight)
			{
				rightAxis = rightAxis >= 1 ? 1 : rightAxis += 0.02f;
			}
			else
			{
				rightAxis = 0;
			}
		}
		else
		{
			if (Input.acceleration.x < 0)
			{
				leftAxis = leftAxis <= -1 ? -1 : leftAxis += Input.acceleration.x/5;
			}
			else
			{
				leftAxis = 0;
			}

			if (Input.acceleration.x > 0)
			{
				rightAxis = rightAxis >= 1 ? 1 : rightAxis += Input.acceleration.x/5;
			}
			else
			{
				rightAxis = 0;
			}
		}

		//move automatically with time
		movementVelocity = ((int)timeInGame % 5 == 0 && (int)timeInGame != 0 && velocityDone != (int)timeInGame && movementVelocity < 40) ? movementVelocity + 0.5f : movementVelocity;
		sphere.velocity = new Vector3(
			Mathf.Clamp(sphere.velocity.x + (leftAxis + rightAxis), -17, 17),
			sphere.velocity.y,
			Mathf.Clamp(sphere.velocity.z + Input.GetAxis("Vertical"), -1f, 25) + movementVelocity
		);
		velocityDone = (int)timeInGame;
		movementVelocity += 0.0005f;
		//could be used for obstacles
		//float delay = 1.5f;
		//float velocityDir = Random.Range(0, 360);
		//if (Time.time > curTime + delay)
		//{
		//	gameObject.transform.Rotate(new Vector3(velocityDir, velocityDir, velocityDir));
		//	gameObject.GetComponent<Rigidbody>().AddForce(transform.up * 5000);
		//	curTime = Time.time;
		//}
	}

	//Get array of touches per frame and check if a swipe has occured
	void checkJump()
	{
		for (int i = 0; i < Input.touchCount; i++)
		{
			Touch touch = Input.GetTouch(i);
			if (touch.phase == TouchPhase.Began)
			{
				startTouchPosition = touch.position.y;
			}
			else if (touch.phase == TouchPhase.Ended)
			{
				endTouchPosition = touch.position.y;
				if (endTouchPosition > startTouchPosition + 200)
				{
					jumpSwipeUp();
				}
				else if (endTouchPosition < startTouchPosition + 200)
				{
					if (PlayerMovement.timeSinceLastLeftClick < Time.time  && PlayerMovement.timeSinceLastRightClick < Time.time)
					{
						jumpSwipeDown();
					}
				}
			}
		}
	}

	void OnTriggerEnter(Collider cube)
	{
		if (cube.gameObject.CompareTag("Pick Up"))
		{
			cube.gameObject.SetActive(false);
			score += coinValue;
			setScore();
		}
	}

	void setScore()
	{
		scoreText.text = "Coins: " + score.ToString();
	}

	//Jump With button
	void jump()
	{
		if (Physics.Raycast(transform.position, Vector2.down, 0.5f))
		{
			jumpNumber = 0;
		}
		if ((PlayerMovement.jumpClick && Physics.Raycast(transform.position, Vector2.down, 0.5f)) ||
			(PlayerMovement.jumpClick && GetComponent<DoubleJump>() != null && jumpNumber == 1))
		{
			{
				sphere.AddForce(0, 450, 0);
				jumpNumber++;
				PlayerMovement.jumpClick = false;
				Invoke("fall", 0.5f);
			}
		}
	}

	public void addEffect(string effect)
	{
		if (effect.Equals("doublejump") && PlayerPrefs.GetInt("doublejump", 0) > 0 && GetComponent<DoubleJump>() == null)
		{
			gameObject.AddComponent<DoubleJump>();
			PlayerPrefs.SetInt("doublejump", (PlayerPrefs.GetInt("doublejump") - 1));
			//StartCoroutine("decrementFromTheDatabase", "doubleJump");
		}
		else if (effect.Equals("barracades") && PlayerPrefs.GetInt("barracades", 0) > 0 && GetComponent<Barracades>() == null)
		{
			gameObject.AddComponent<Barracades>();
			PlayerPrefs.SetInt("barracades", (PlayerPrefs.GetInt("barracades") - 1));
			//StartCoroutine("decrementFromTheDatabase", "barracade");
		}
		else if (effect.Equals("magnet") && PlayerPrefs.GetInt("magnet", 0) > 0 && GetComponent<Magnet>() == null)
		{
			gameObject.AddComponent<Magnet>();
			PlayerPrefs.SetInt("magnet", (PlayerPrefs.GetInt("magnet") - 1));
			//StartCoroutine("decrementFromTheDatabase", "magnet");
		}
		else if (effect.Equals("invincibility") && PlayerPrefs.GetInt("invincibility", 0) > 0 && GetComponent<Invincibility>() == null)
		{
			gameObject.AddComponent<Invincibility>();
			PlayerPrefs.SetInt("invincibility", (PlayerPrefs.GetInt("invincibility") - 1));
			//StartCoroutine("decrementFromTheDatabase", "invincibility");
		}
		else if (effect.Equals("increasedcoinvalue") && PlayerPrefs.GetInt("increasedcoinvalue", 0) > 0 && GetComponent<increasedCoinValue>() == null)
		{
			gameObject.AddComponent<increasedCoinValue>();
			PlayerPrefs.SetInt("increasedcoinvalue", (PlayerPrefs.GetInt("increasedcoinvalue") - 1));
			//StartCoroutine("decrementFromTheDatabase", "increasedCoinValue");
		}
	}

	void jumpSwipeUp()
	{
		if (Physics.Raycast(transform.position, Vector2.down, 0.5f))
		{
			jumpNumber = 0;
		}
		if ((Physics.Raycast(transform.position, Vector2.down, 0.5f)) ||
			(GetComponent<DoubleJump>() != null && jumpNumber == 1))
		{
			{
				sphere.AddForce(0, 450, 0);
				jumpNumber++;
			}
		}
	}

	void jumpSwipeDown()
	{
		if (!Physics.Raycast(transform.position, Vector2.down, 0.5f))
		{
			sphere.AddForce(0, -800, 0);
		}
	}

	void fall()
	{
		sphere.AddForce(0, -600, 0);
	}

	public void die()
	{
		alive = false;
		//Play sphere pop animation
		GetComponent<TriangleExplosion>().explode();
		//Save coins and highscore
		PlayerPrefs.SetInt("balance", (PlayerPrefs.GetInt("balance", 0) + score));
		if ((int)timeInGame > PlayerPrefs.GetInt("highscore", 0))
		{
			PlayerPrefs.SetInt("highscore", (int)timeInGame);
		}
		//Send info to server only for pc
		//if (LoginDetails.email != "None")
		//{
		//	StartCoroutine("sendScoreInformation");
		//}
	}

	//Only for pc
	//IEnumerator sendScoreInformation()
	//{
	//	WWWForm scoreForm = new WWWForm();
	//	scoreForm.AddField("verif", LoginDetails.emailHash);
	//	scoreForm.AddField("email", LoginDetails.email);
	//	scoreForm.AddField("coins", score);
	//	scoreForm.AddField("time", timeInGame.ToString());
	//	WWW sendScoreForm = new WWW(scoreURL, scoreForm);
	//	yield return sendScoreForm;
	//	if (sendScoreForm.error != null)
	//	{
	//		Debug.LogError("Can't login: " + sendScoreForm.error);
	//	}
	//}

	//IEnumerator decrementFromTheDatabase(string effect)
	//{
	//	if (LoginDetails.email != "None")
	//	{
	//		WWWForm effectForm = new WWWForm();
	//		effectForm.AddField("effect", effect);
	//		effectForm.AddField("verif", LoginDetails.emailHash);
	//		effectForm.AddField("email", LoginDetails.email);
	//		WWW sendEffectForm = new WWW(effectURL, effectForm);
	//		yield return sendEffectForm;
	//	}
	//}

}