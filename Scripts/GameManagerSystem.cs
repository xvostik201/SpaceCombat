using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManagerSystem : MonoBehaviour
{
    [SerializeField] private GameObject enemyPrefab;
    [SerializeField] private TextMeshProUGUI waveValueText;

    [SerializeField] private int startSpawnValue = 3;

    [SerializeField] private GameObject[] menuButtons, gameButtons, gameOverButtons;

    public float spawnDelay = 2.0f; 
    public bool gameIsStarted = false;
    [HideInInspector] public float moneyBefore, moneyAfter, moneyEarned;

    private float lastSpawnValue;
    private bool newWave = true;
    
    [HideInInspector] public int waveValue = 1;

    private int newWaveSpawnValue;


    private GameObject[] currentEnemyValue;

    Gun gun;
    ShopSystem shop;
    PlayerHealth playerHealth;
    MoneySystem money;
    BonusSystem bonusSystem;
    BulletSystem bulletSystem;

    private void Start()
    {
        bulletSystem = FindObjectOfType<BulletSystem>();
        bonusSystem = FindObjectOfType<BonusSystem>();
        money = FindObjectOfType<MoneySystem>();
        gun = FindObjectOfType<Gun>();
        shop = FindObjectOfType<ShopSystem>();
        playerHealth = FindObjectOfType<PlayerHealth>();

        newWaveSpawnValue = startSpawnValue;
        StartCoroutine(SpawnEnemiesWithDelay());
        InMenu();
    }

    private void Update()
    {
        waveValueText.text = $"Wave - {waveValue}";

        currentEnemyValue = GameObject.FindGameObjectsWithTag("Enemy");

        if(currentEnemyValue.Length <= 0 && !newWave)
        {
            waveValue++;
            newWaveSpawnValue++;
            newWave = true;
            StartCoroutine(SpawnEnemiesWithDelay());
            money.money += waveValue;
            shop.healthValue = shop.healthValueConst;
            gun.ammo = shop.ammoConst;
        }

        if (shop.healthValue <= 0)
        {
            Invoke("GameIsOver", 1.5f);
        }




    }
    public void InMenu()
    {
        gameIsStarted = false;
        Time.timeScale = 0f;
        MenuGameButtons();
        Save();


    }
    public void GameIsOver()
    {
        moneyAfter = money.money;
        moneyEarned = moneyAfter - moneyBefore;
        Time.timeScale = 0f;
        GameOverGameButtons();
        Save();



    }

    public void StartGame()
    {
        moneyBefore = money.money;
        Time.timeScale = 1f;
        gameIsStarted = true;
        shop.healthValue = shop.healthValueConst;
        StartGameButtons();
        gun.ammo = shop.ammoConst;
        bonusSystem.damageEnemyBefore = bulletSystem.enemyDamage;
        bonusSystem.damagePlayerBefore = bulletSystem.playerDamage;
        bonusSystem.fireRateBefore = shop.fireRateValue;
        Save();


    }

    private IEnumerator SpawnEnemiesWithDelay()
    {
        while (newWave)
        {
            for (int i = 0; i < newWaveSpawnValue; i++)
            {
                float randomValue = Random.Range(-2.4f, 2.4f);
                while (randomValue == lastSpawnValue)
                {
                    randomValue = Random.Range(-2.4f, 2.4f);
                }

                var enemy = Instantiate(enemyPrefab, Vector3.zero, Quaternion.identity);

                enemy.transform.position = new Vector3(randomValue, 2, 0);
                enemy.transform.rotation = Quaternion.Euler(0f, 0f, -180f);
                lastSpawnValue = randomValue;

                yield return new WaitForSeconds(spawnDelay);
            }

            newWave = false;
        }
    }

    void StartGameButtons()
    {
        foreach(GameObject game in menuButtons)
        {
            game.SetActive(false);
        }
        foreach(GameObject game in gameButtons)
        {
            game.SetActive(true);
        }
        foreach(GameObject game in gameOverButtons)
        {
            game.SetActive(false);
        }
    }
    void GameOverGameButtons()
    {
        foreach (GameObject game in menuButtons)
        {
            game.SetActive(false);
        }
        foreach (GameObject game in gameButtons)
        {
            game.SetActive(false);
        }
        foreach (GameObject game in gameOverButtons)
        {
            game.SetActive(true);
        }
    }
    void MenuGameButtons()
    {
        foreach (GameObject game in menuButtons)
        {
            game.SetActive(true);
        }
        foreach (GameObject game in gameButtons)
        {
            game.SetActive(false);
        }
        foreach (GameObject game in gameOverButtons)
        {
            game.SetActive(false);
        }
    }

    private void Save()
    {
        PlayerPrefs.Save();
    }
}
