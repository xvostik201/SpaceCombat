using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;

public class Gun : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI ammoText;
    [SerializeField] private float ammoMinus, reloadTimer, timeToReload;
    [SerializeField] private Transform firePoint;
    [SerializeField] private GameObject fireSound;
    [SerializeField] private GameObject bulletPrefab;

    [HideInInspector] public float ammo;

    

    ShopSystem shop;

    private GameObject currentLine;

    bool isClick = false;
    float timer = 0;

    private void Start()
    {
        shop = FindObjectOfType<ShopSystem>();
        ammo = shop.ammoConst;
    }

    private void Update()
    {
        if(ammo > 0)
        {
            ammoText.text = $"ammo - {ammo}";
        }
        else
        {
            Reloading();
            ammoText.text = "RELOADING";
        }

        timer += Time.deltaTime;

        Fire();
    }

    private void Reloading()
    {
        reloadTimer += Time.deltaTime;

        if(reloadTimer >= timeToReload)
        {
            ammo = shop.ammoConst;
            reloadTimer = 0;
        }
    }

    private void Fire()
    {
        if (isClick || Input.GetKey(KeyCode.Space) && ammo > 0 && timer >= shop.fireRateValue)
        {
            var bullet = Instantiate(bulletPrefab, firePoint.position, Quaternion.identity);

            bullet.transform.rotation = Quaternion.Euler(0f, 0f, 90f);

            Destroy(bullet, 5f);

            var bulletSound = Instantiate(fireSound, transform.position, Quaternion.identity);

            bulletSound.GetComponent<AudioSource>().Play();

            Destroy(bulletSound, 2.5f);

            

            ammo -= ammoMinus;

            if (ammo <= 0)
            {
                FireOff();
            }

            timer = 0;
        }
    }

    public void FireOn()
    {
        isClick = true;
    }
    public void FireOff()
    {
        isClick = false;
        timer = 0;
        if (currentLine != null)
        {
            currentLine.SetActive(false);
        }
    }

    

}
