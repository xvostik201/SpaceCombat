using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    
    [SerializeField] private ParticleSystem boom;
    [SerializeField] private TextMeshProUGUI text;
    [SerializeField] private AudioSource deathSource;

    ShopSystem shop;
    void Start()
    {
        shop = FindObjectOfType<ShopSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        text.text = $"health - {shop.healthValue}";

        if (shop.healthValue <= 0)
        {
            Instantiate(boom, transform.position, Quaternion.identity);
            gameObject.SetActive(false);

            var sound = Instantiate(deathSource, transform.position, Quaternion.identity);

            sound.Play();

            Destroy(sound, 4f);
        }
    }

    public void TakeDamage(int damage)
    {
        shop.healthValue -= damage;
    }
}
