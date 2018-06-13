using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class MoneyCounter : MonoBehaviour {
	public UpgradeMenu uM;
	private Text moneyText;

	// void Start()
	// {
	// 	uM = GameObject.FindGameObjectWithTag("uM").GetComponent<UpgradeMenu>();
	// }
	void Awake () {
		moneyText = GetComponent<Text>();

	}

	// Update is called once per frame
	void Update () {
		moneyText.text = "Money: " + uM.money.ToString();

	}
}
