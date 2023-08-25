using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ShopSystem : MonoBehaviour
{
    [Header("Health")]

    public int healthCost;
    public int healthValue, healthValueConst;
    [SerializeField] private TextMeshProUGUI healthCurrentValue, healthCostValue, healthValueInShop;

    [Header("Fire Rate")]

    public int fireRateCost;
    [SerializeField] private TextMeshProUGUI fireRateCurrentValue, fireRateCostValue;
    public float fireRateValue;

    [Header("Ammo")]

    public int ammoCost;
    [SerializeField] private TextMeshProUGUI ammoCostCurrentValue, ammoCostValue;
    public int ammoConst;

    [Header("SoundEffects")]
    [SerializeField] private AudioSource buySource;


    MoneySystem moneySystem;

    private void Awake()
    {
        if (!PlayerPrefs.HasKey("Health"))
        {
            PlayerPrefs.SetInt("Health", 100);

        }

        if (!PlayerPrefs.HasKey("HealthCost"))
        {
            PlayerPrefs.SetInt("HealthCost", 20);

        }


        if (!PlayerPrefs.HasKey("FireRate"))
        {
            PlayerPrefs.SetFloat("FireRate", 0.2f);

        }
        if (!PlayerPrefs.HasKey("FireRateCost"))
        {
            PlayerPrefs.SetInt("HealthCost", 15);

        }

        if (!PlayerPrefs.HasKey("Ammo"))
        {
            PlayerPrefs.SetInt("Ammo", 40);

        }
        if (!PlayerPrefs.HasKey("AmmoCost"))
        {
            PlayerPrefs.SetInt("AmmoCost", 5);

        }
    }


    private void Start()
    {
        moneySystem = FindObjectOfType<MoneySystem>();

        if (PlayerPrefs.HasKey("Health"))
        {
            healthValueConst = PlayerPrefs.GetInt("Health");

        }

        if (PlayerPrefs.HasKey("HealthCost"))
        {
            healthCost = PlayerPrefs.GetInt("HealthCost");

        }

        if (PlayerPrefs.HasKey("FireRate"))
        {
            fireRateValue = PlayerPrefs.GetFloat("FireRate");

        }
        if (PlayerPrefs.HasKey("FireRateCost"))
        {
            fireRateCost = PlayerPrefs.GetInt("FireRateCost");

        }

        if (PlayerPrefs.HasKey("Ammo"))
        {
            ammoConst = PlayerPrefs.GetInt("Ammo");

        }
        if (PlayerPrefs.HasKey("AmmoCost"))
        {
            ammoCost = PlayerPrefs.GetInt("AmmoCost");

        }
    }

    private void Update()
    {
        healthValueInShop.text = $"health - {healthValueConst}";
        healthCostValue.text = $"{healthCost}";

        fireRateCurrentValue.text = $"fire rate - {fireRateValue}";
        fireRateCostValue.text = $"{fireRateCost}";

        ammoCostCurrentValue.text = $"ammo - {ammoConst}";
        ammoCostValue.text = $"{ammoCost}";
    }


    public void BuyHealth()
    {
        if(moneySystem.money >= healthCost) 
        {
            moneySystem.money -= healthCost;
            healthCost += Random.Range(10, 20);
            healthValueConst += 5;
            PlayerPrefs.SetInt("Health", healthValueConst);
            PlayerPrefs.SetInt("HealthCost", healthCost);
            buySource.Play();
        }
    }

    public void BuyFireRate()
    {
        if (moneySystem.money >= fireRateCost && fireRateValue > 0.11f)
        {
            moneySystem.money -= fireRateCost;
            fireRateCost += Random.Range(10, 20);
            fireRateValue -= 0.002f;
            PlayerPrefs.SetFloat("FireRate", fireRateValue);
            PlayerPrefs.SetInt("FireRateCost", fireRateCost);
            buySource.Play();
        }
    }

    public void BuyAmmo()
    {
        if (moneySystem.money >= ammoCost)
        {
            moneySystem.money -= fireRateCost;
            ammoCost += Random.Range(10, 20);
            ammoConst += 15;
            PlayerPrefs.SetInt("Ammo", ammoConst);
            PlayerPrefs.SetInt("AmmoCost", ammoCost);
            buySource.Play();
        }
    }

}
