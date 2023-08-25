using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class BonusVariable : MonoBehaviour
{
     public bool isFireRateBonus, isDamageBonus;
    [SerializeField] private float bonusDuration = 8;

    
    
    BonusSystem bonusSystem;

    void Start()
    {
        
        bonusSystem = FindObjectOfType<BonusSystem>();
        Destroy(gameObject, 10f);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position -= new Vector3(0, 1 * Time.deltaTime, 0);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (isDamageBonus && !isFireRateBonus)
            {
                bonusSystem.damageTimer += bonusDuration;
                Destroy(gameObject);
            }
            else if (!isDamageBonus && isFireRateBonus)
            {
                bonusSystem.fireRateTimer += bonusDuration;
                Destroy(gameObject);
            }
            else if (!isDamageBonus && !isFireRateBonus)
            {
                bonusSystem.healthTimer += bonusDuration;
                Destroy(gameObject);
            }
        }

    }
}
