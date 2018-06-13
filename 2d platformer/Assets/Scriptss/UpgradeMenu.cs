using UnityEngine;
using UnityEngine.UI;
public class UpgradeMenu : MonoBehaviour {


	[SerializeField]
	private Text healthText;

	public Weapon wp;

	[SerializeField]
	private Text speedText;

	[SerializeField]
	private float healthMultiplier = 12f;

	// [SerializeField]
	private int fRateMultiplier = 10;

	[SerializeField]
	private int upgradeCost = 10;

	[SerializeField]
	public int money = 20;


	public PlayerStats stats;

	void Start(){
		if (stats == null){
			stats = GameObject.FindGameObjectWithTag("GM").GetComponent<PlayerStats>();
		}
	}
	void OnEnable(){
		stats = PlayerStats.instance;
		// fRate = GameObject.FindGameObjectWithTag("Weapon").GetComponent<Weapon>().fireRate;
		UpdateValues();
	}
	void UpdateValues(){
		healthText.text = "Health: " + stats.maxHealth.ToString();
		speedText.text = "Damage: " + stats.damage.ToString();
	}
	public 	void UpgradeHealth(){
		if(money < upgradeCost)
		{
			AudioManager.instance.PlaySound("NoMoney");
			return;
		}
		stats.maxHealth = (int)(stats.maxHealth + healthMultiplier);
		money -= upgradeCost;
		AudioManager.instance.PlaySound("Money");
		UpdateValues();
	}
	public 	void UpgradeSpeed(){
		if(money < upgradeCost)
		{
			AudioManager.instance.PlaySound("NoMoney");
			return;
		}
		stats.damage +=fRateMultiplier;
		money -= upgradeCost;
		AudioManager.instance.PlaySound("Money");
		UpdateValues();
	}
}
