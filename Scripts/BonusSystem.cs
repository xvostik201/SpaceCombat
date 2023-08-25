using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusSystem : MonoBehaviour
{
    [SerializeField] private GameObject[] bonuses;
    public float damageTimer, fireRateTimer, healthTimer;
    public int damageEnemyBefore, damagePlayerBefore, maxRandomValue, randomValue;
    public float fireRateBefore;


    BulletSystem bulletsystem;
    PlayerHealth playerHealth;
    ShopSystem shopSystem;
    GameManagerSystem gameManagerSystem;
    void Start()
    {
        randomValue = maxRandomValue;
        gameManagerSystem = FindObjectOfType<GameManagerSystem>();
        bulletsystem = FindObjectOfType<BulletSystem>();
        playerHealth = FindObjectOfType<PlayerHealth>();
        shopSystem = FindObjectOfType<ShopSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        if (gameManagerSystem.gameIsStarted)
        {
            if (damageTimer > 0)
            {
                bulletsystem.playerDamage = 100;
                damageTimer -= Time.deltaTime;
            }
            else
            {
                bulletsystem.playerDamage = 25;
            }
            if (fireRateTimer > 0)
            {
                shopSystem.fireRateValue = 0.08f;
                fireRateTimer -= Time.deltaTime;
            }
            else
            {
                shopSystem.fireRateValue = fireRateBefore;
            }

            if (healthTimer > 0)
            {
                bulletsystem.enemyDamage = 0;
                healthTimer -= Time.deltaTime;
            }
            else
            {
                bulletsystem.enemyDamage = damageEnemyBefore;
            }
        }
        
    }

    public void Bonus(Transform enemyTransform)
    {

        bool isBonus = Random.Range(1, randomValue) == 1;

        if (isBonus)
        {
            int randomBonus = Random.Range(0, bonuses.Length);

            var bonus = Instantiate(bonuses[randomBonus], enemyTransform.position, enemyTransform.rotation);

            if(randomBonus == 0)
            {
                bonus.GetComponent<BonusVariable>().isDamageBonus = true;
                bonus.GetComponent<BonusVariable>().isFireRateBonus = false; 
            }
            else if (randomBonus == 1)
            {
                bonus.GetComponent<BonusVariable>().isDamageBonus = false;
                bonus.GetComponent<BonusVariable>().isFireRateBonus = true;
            }
            else
            {
                bonus.GetComponent<BonusVariable>().isDamageBonus = false;
                bonus.GetComponent<BonusVariable>().isFireRateBonus = false;
            }
            randomValue = maxRandomValue;
        }
        else
        {
            randomValue--;
        }
        
    }
}
