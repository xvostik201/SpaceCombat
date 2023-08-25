using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour
{
    [SerializeField] private float rotationSpeed = 5f, rocketSpeed;

    Rigidbody2D rb;
    GameObject target;

    private void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player");
        
    }

    private void Update()
    {
        if (target != null)
        {
            // ��������� ����������� � ����
            Vector3 direction = target.transform.position - transform.position;
            direction.Normalize();

            // ��������� ���� ����� ������������ � ������������ ������ (�� ��� X)
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

            // ������� ������� ���������� �������� �� ��� Z
            Quaternion targetRotation = Quaternion.Euler(new Vector3(0, 0, angle));

            // ������ ������������ ������ � ����
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);

            float currentRotation = transform.eulerAngles.z;
            float movementAngle = currentRotation * Mathf.Deg2Rad;

            Vector3 movementDirection = new Vector3(Mathf.Cos(movementAngle), Mathf.Sin(movementAngle), 0);

            transform.position += movementDirection * rocketSpeed * Time.deltaTime;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        gameObject.SetActive(false);
    }
}
