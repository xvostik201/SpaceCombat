using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneController : MonoBehaviour
{
    [SerializeField] private float constantSpeed;

    [SerializeField] private float torqueSpeed;

    [SerializeField] private Joystick joystick;

    [SerializeField] private bool isAndroidVersion;

    public float tiltSpeed = 5f; // Скорость наклона корабля
    public float maxTiltAngle = 45f; // Максимальный угол наклона

    private float targetTilt = 0f; // Целевой угол наклона
    private float currentTilt = 0f; // Текущий угол наклона

    GameManagerSystem gameManager;

    Rigidbody2D rb;
    void Start()
    {
        gameManager = FindObjectOfType<GameManagerSystem>();

        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (gameManager.gameIsStarted)
        {
            joystick = FindObjectOfType<Joystick>();
            
            Movement();

        }


    }

    private void Movement()
    {
        if (isAndroidVersion)
        {
            float horizontal = joystick.Horizontal;
            float vertical = joystick.Vertical;

            transform.position += new Vector3(horizontal * torqueSpeed * Time.deltaTime, 0);

            if (horizontal != 0)
            {
                targetTilt = horizontal * maxTiltAngle;
            }
            else
            {
                targetTilt = 0f;
            }

            currentTilt = Mathf.Lerp(currentTilt, targetTilt, Time.deltaTime * tiltSpeed);
            transform.rotation = Quaternion.Euler(0, currentTilt, 0);

            if (vertical > 0)
            {
                transform.position += new Vector3(0, vertical * constantSpeed * Time.deltaTime);
            }
            else if (vertical < 0)
            {
                transform.position += new Vector3(0, vertical * constantSpeed * Time.deltaTime);
            }
            else
            {
                rb.velocity = Vector2.zero;
            }

            if (transform.position.y > 2f)
            {
                transform.position = new Vector3(transform.position.x, -7f);
            }
        }
        else
        {
            float horizontal = Input.GetAxis("Horizontal");
            float vertical = Input.GetAxis("Vertical");

            transform.position += new Vector3(horizontal * torqueSpeed * Time.deltaTime, 0);

            if (horizontal != 0)
            {
                targetTilt = horizontal * maxTiltAngle;
            }
            else
            {
                targetTilt = 0f;
            }

            currentTilt = Mathf.Lerp(currentTilt, targetTilt, Time.deltaTime * tiltSpeed);
            transform.rotation = Quaternion.Euler(0, currentTilt, 0);

            if (vertical > 0)
            {
                transform.position += new Vector3(0, vertical * constantSpeed * Time.deltaTime);
            }
            else if (vertical < 0)
            {
                transform.position += new Vector3(0, vertical * constantSpeed * Time.deltaTime);
            }
            else
            {
                rb.velocity = Vector2.zero;
            }

            if (transform.position.y > 2f)
            {
                transform.position = new Vector3(transform.position.x, -7f);
            }
        }

        
    }
}
