using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class NavigationShop : MonoBehaviour {

	private Text balance, dj, inv, icv, mg, br;
	//private const string effectBuyURL = "www.rollerball.x10.mx/includes/buyEffect.php";
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
		balance.text = "BALANCE: " + PlayerPrefs.GetInt("balance", 0).ToString();
		dj.text = PlayerPrefs.GetInt("doublejump", 0).ToString();
		inv.text = PlayerPrefs.GetInt("invincibility", 0).ToString();
		icv.text = PlayerPrefs.GetInt("increasedcoinvalue", 0).ToString();
		mg.text = PlayerPrefs.GetInt("magnet", 0).ToString();
		br.text = PlayerPrefs.GetInt("barracades", 0).ToString();
	}

	public void buyDoubleJump()
	{
		if (PlayerPrefs.GetInt("balance" , 0) >= djCost)
		{
			PlayerPrefs.SetInt("balance", (PlayerPrefs.GetInt("balance", 0) - djCost));
			PlayerPrefs.SetInt("doublejump", PlayerPrefs.GetInt("doublejump", 0) + 1);
		}
		else
		{
			failCanvas.enabled = true;
		}
	}

	public void buyInvincibility()
	{
		if (PlayerPrefs.GetInt("balance", 0) >= invCost)
		{
			PlayerPrefs.SetInt("balance", (PlayerPrefs.GetInt("balance", 0) - invCost));
			PlayerPrefs.SetInt("invincibility", PlayerPrefs.GetInt("invincibility", 0) + 1);
		}
		else
		{
			failCanvas.enabled = true;
		}
	}

	public void buyICV()
	{
		if (PlayerPrefs.GetInt("balance", 0) >= icvCost)
		{
			PlayerPrefs.SetInt("balance", (PlayerPrefs.GetInt("balance", 0) - icvCost));
			PlayerPrefs.SetInt("increasedcoinvalue", PlayerPrefs.GetInt("increasedcoinvalue", 0) + 1);
		}
		else
		{
			failCanvas.enabled = true;
		}
	}

	public void buyBarracades()
	{
		if (PlayerPrefs.GetInt("balance", 0) >= brCost)
		{
			PlayerPrefs.SetInt("balance", (PlayerPrefs.GetInt("balance", 0) - brCost));
			PlayerPrefs.SetInt("barracades", PlayerPrefs.GetInt("barracades", 0) + 1);
		}
		else
		{
			failCanvas.enabled = true;
		}
	}


	public void buyMagnet()
	{
		if (PlayerPrefs.GetInt("balance", 0) >= mgCost)
		{
			PlayerPrefs.SetInt("balance", (PlayerPrefs.GetInt("balance", 0) - djCost));
			PlayerPrefs.SetInt("magnet", PlayerPrefs.GetInt("magnet", 0) + 1);
		}
		else
		{
			failCanvas.enabled = true;
		}
	}

	//IEnumerator doubleJump()
	//{
	//	WWWForm buy = new WWWForm();
	//	buy.AddField("verif", LoginDetails.emailHash);
	//	buy.AddField("email", LoginDetails.email);
	//	buy.AddField("effect", "doubleJump");
	//	WWW sendBuy = new WWW(effectBuyURL ,buy);
	//	yield return sendBuy;
	//	if (sendBuy.error != null)
	//	{
	//		Debug.LogError("couldn't buy the desired effect");
	//	}
	//	else
	//	{
	//		LoginDetails.money -= djCost;
	//		LoginDetails.doubleJump += 1;
	//	}
	//}

	//IEnumerator invincibility()
	//{
	//	WWWForm buy = new WWWForm();
	//	buy.AddField("verif", LoginDetails.emailHash);
	//	buy.AddField("email", LoginDetails.email);
	//	buy.AddField("effect", "invincibility");
	//	WWW sendBuy = new WWW(effectBuyURL, buy);
	//	yield return sendBuy;
	//	if (sendBuy.error != null)
	//	{
	//		Debug.LogError("couldn't buy the desired effect");
	//	}
	//	else
	//	{
	//		LoginDetails.money -= invCost;
	//		LoginDetails.invincibility += 1;
	//	}
	//}

	//IEnumerator ICV()
	//{
	//	WWWForm buy = new WWWForm();
	//	buy.AddField("verif", LoginDetails.emailHash);
	//	buy.AddField("email", LoginDetails.email);
	//	buy.AddField("effect", "ICV");
	//	WWW sendBuy = new WWW(effectBuyURL, buy);
	//	yield return sendBuy;
	//	if (sendBuy.error != null)
	//	{
	//		Debug.LogError("couldn't buy the desired effect");
	//	}
	//	else
	//	{
	//		LoginDetails.money -= icvCost;
	//		LoginDetails.increasedCoinValue += 1;
	//	}
	//}

	//IEnumerator barracades()
	//{
	//	WWWForm buy = new WWWForm();
	//	buy.AddField("verif", LoginDetails.emailHash);
	//	buy.AddField("email", LoginDetails.email);
	//	buy.AddField("effect", "barracades");
	//	WWW sendBuy = new WWW(effectBuyURL, buy);
	//	yield return sendBuy;
	//	if (sendBuy.error != null)
	//	{
	//		Debug.LogError("couldn't buy the desired effect");
	//	}
	//	else
	//	{
	//		LoginDetails.money -= brCost;
	//		LoginDetails.barracade += 1;
	//	}
	//}

	//IEnumerator magnet()
	//{
	//	WWWForm buy = new WWWForm();
	//	buy.AddField("verif", LoginDetails.emailHash);
	//	buy.AddField("email", LoginDetails.email);
	//	buy.AddField("effect", "magnet");
	//	WWW sendBuy = new WWW(effectBuyURL, buy);
	//	yield return sendBuy;
	//	if (sendBuy.error != null)
	//	{
	//		Debug.LogError("couldn't buy the desired effect");
	//	}
	//	else
	//	{
	//		LoginDetails.money -= mgCost;
	//		LoginDetails.magnet += 1;
	//	}
	//}
}
