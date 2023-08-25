using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] public Transform firePoint;
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private AudioSource audioSource;


    [SerializeField] private float timeToShoot, speed;

    float timer;
    GameManagerSystem gameManagerSystem;
    public bool isMovingRight = true;

    void Start()
    {
        gameManagerSystem = FindObjectOfType<GameManagerSystem>();

        isMovingRight = Random.Range(0, 2) == 0;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        transform.position += new Vector3(0, -speed * Time.deltaTime);

        if(timer >= timeToShoot)
        {
            Shoot();
        }

        if (transform.position.y < -10.9f)
        {
            transform.position = new Vector3(transform.position.x, 2f);
        }

        if (gameManagerSystem.waveValue >= 10)
        {
            HandleMovement();
        }
    }

    public void Shoot()
    {
        var bullet = Instantiate(bulletPrefab, firePoint.position, Quaternion.identity);

        Destroy(bullet, 15f);

        bullet.transform.rotation = Quaternion.Euler(0f, 0f, -90f);

        var bulletAudio = Instantiate(audioSource, transform.position, Quaternion.identity);

        Destroy(bulletAudio, 5f);

        bulletAudio.Play();

        timer = 0;
    }

    private void HandleMovement()
    {
        if (isMovingRight)
        {
            transform.position += new Vector3(0.5f * Time.deltaTime, 0, 0);
            if (transform.position.x > 2.3)
            {
                isMovingRight = false;
            }
        }
        else
        {
            transform.position -= new Vector3(0.5f * Time.deltaTime, 0, 0);
            if (transform.position.x < -2.3)
            {
                isMovingRight = true;
            }
        }
    }

}
