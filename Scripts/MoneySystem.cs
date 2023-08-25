using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MoneySystem : MonoBehaviour
{
    public int money = 20;
    [SerializeField] private TextMeshProUGUI moneyText;

    private void Awake()
    {
        if (!PlayerPrefs.HasKey("Money"))
        {
            PlayerPrefs.SetInt("Money", 20);
        }
    }
    void Start()
    {
        money = PlayerPrefs.GetInt("Money");
    }

    // Update is called once per frame
    void Update()
    {
        moneyText.text = $"money - {money}";
        PlayerPrefs.SetInt("Money", money);
    }
}
