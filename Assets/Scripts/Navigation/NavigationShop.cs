using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class NavigationShop : MonoBehaviour {

	private Text balance, dj, inv, icv, mg, br;
	private const string effectBuyURL = "www.rollerball.x10.mx/includes/buyEffect.php";
	private static int djCost = 50;
	private static int invCost = 400;
	private static int icvCost = 350;
	private static int mgCost = 200;
	private static int brCost = 250;
	private Canvas failCanvas;

	void Start()
	{
		dj = GameObject.Find("DoubleJumpCount").GetComponent<Text>();
		inv = GameObject.Find("InvinsibilityCount").GetComponent<Text>();
		icv = GameObject.Find("CoinValueCount").GetComponent<Text>();
		mg = GameObject.Find("MagnetCount").GetComponent<Text>();
		br = GameObject.Find("BarracadesCount").GetComponent<Text>();

		failCanvas = GameObject.Find("BuyFailCanvas").GetComponent<Canvas>();
		failCanvas.enabled = false;

		balance = GameObject.Find("YourBalanceText").GetComponent<Text>();
		if (LoginDetails.email == "None")
		{
			SceneManager.LoadScene("MainScreen");
		}
	}

	public void toMain()
	{
		SceneManager.LoadScene("MainScreen");
	}

	public void OK()
	{
		failCanvas.enabled = false;
	}

	void Update ()
	{
		balance.text = "BALANCE: " + LoginDetails.money;
		dj.text = LoginDetails.doubleJump.ToString();
		inv.text = LoginDetails.invincibility.ToString();
		icv.text = LoginDetails.increasedCoinValue.ToString();
		mg.text = LoginDetails.magnet.ToString();
		br.text = LoginDetails.barracade.ToString();
	}

	public void buyDoubleJump()
	{
		if (LoginDetails.money >= djCost)
		{
			StartCoroutine("doubleJump");
		}
		else
		{
			failCanvas.enabled = true;
		}
	}

	public void buyInvincibility()
	{
		if (LoginDetails.money >= invCost)
		{
			StartCoroutine("invincibility");
		}
		else
		{
			failCanvas.enabled = true;
		}
	}

	public void buyICV()
	{
		if (LoginDetails.money >= icvCost)
		{
			StartCoroutine("ICV");
		}
		else
		{
			failCanvas.enabled = true;
		}
	}

	public void buyBarracades()
	{
		if (LoginDetails.money >= brCost)
		{
			StartCoroutine("barracades");
		}
		else
		{
			failCanvas.enabled = true;
		}
	}


	public void buyMagnet()
	{
		if (LoginDetails.money >= mgCost)
		{
			StartCoroutine("magnet");
		}
		else
		{
			failCanvas.enabled = true;
		}
	}

	IEnumerator doubleJump()
	{
		WWWForm buy = new WWWForm();
		buy.AddField("verif", LoginDetails.emailHash);
		buy.AddField("email", LoginDetails.email);
		buy.AddField("effect", "doubleJump");
		WWW sendBuy = new WWW(effectBuyURL ,buy);
		yield return sendBuy;
		if (sendBuy.error != null)
		{
			Debug.LogError("couldn't buy the desired effect");
		}
		else
		{
			LoginDetails.money -= djCost;
			LoginDetails.doubleJump += 1;
		}
	}

	IEnumerator invincibility()
	{
		WWWForm buy = new WWWForm();
		buy.AddField("verif", LoginDetails.emailHash);
		buy.AddField("email", LoginDetails.email);
		buy.AddField("effect", "invincibility");
		WWW sendBuy = new WWW(effectBuyURL, buy);
		yield return sendBuy;
		if (sendBuy.error != null)
		{
			Debug.LogError("couldn't buy the desired effect");
		}
		else
		{
			LoginDetails.money -= invCost;
			LoginDetails.invincibility += 1;
		}
	}

	IEnumerator ICV()
	{
		WWWForm buy = new WWWForm();
		buy.AddField("verif", LoginDetails.emailHash);
		buy.AddField("email", LoginDetails.email);
		buy.AddField("effect", "ICV");
		WWW sendBuy = new WWW(effectBuyURL, buy);
		yield return sendBuy;
		if (sendBuy.error != null)
		{
			Debug.LogError("couldn't buy the desired effect");
		}
		else
		{
			LoginDetails.money -= icvCost;
			LoginDetails.increasedCoinValue += 1;
		}
	}

	IEnumerator barracades()
	{
		WWWForm buy = new WWWForm();
		buy.AddField("verif", LoginDetails.emailHash);
		buy.AddField("email", LoginDetails.email);
		buy.AddField("effect", "barracades");
		WWW sendBuy = new WWW(effectBuyURL, buy);
		yield return sendBuy;
		if (sendBuy.error != null)
		{
			Debug.LogError("couldn't buy the desired effect");
		}
		else
		{
			LoginDetails.money -= brCost;
			LoginDetails.barracade += 1;
		}
	}

	IEnumerator magnet()
	{
		WWWForm buy = new WWWForm();
		buy.AddField("verif", LoginDetails.emailHash);
		buy.AddField("email", LoginDetails.email);
		buy.AddField("effect", "magnet");
		WWW sendBuy = new WWW(effectBuyURL, buy);
		yield return sendBuy;
		if (sendBuy.error != null)
		{
			Debug.LogError("couldn't buy the desired effect");
		}
		else
		{
			LoginDetails.money -= mgCost;
			LoginDetails.magnet += 1;
		}
	}
}
