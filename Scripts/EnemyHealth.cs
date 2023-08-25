using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] private int health;
    [SerializeField] private ParticleSystem deathParcticle;
    [SerializeField] private AudioSource deathSource;

    Score score;
    BonusSystem bonusSystem;
    MoneySystem money;
    void Start()
    {
        bonusSystem = FindObjectOfType<BonusSystem>();
        money = FindObjectOfType<MoneySystem>();
        score = FindObjectOfType<Score>();
    }

    // Update is called once per frame
    void Update()
    {
        if (health <= 0)
        {
            money.money++;

            score.score++;

            var effect = Instantiate(deathParcticle, transform.position, Quaternion.identity);

            Destroy(effect, 4f);

            var sound = Instantiate(deathSource, transform.position, Quaternion.identity);

            sound.Play();

            bonusSystem.Bonus(transform);

            Destroy(sound, 4f);

            

            Destroy(gameObject);
        }
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
    }


}
