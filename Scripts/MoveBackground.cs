using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBackground : MonoBehaviour
{
    [SerializeField]
    private float speed;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        Move();
    }

    public void Move()
    {
        transform.position += new Vector3(0, speed * Time.deltaTime, 0);
        if(transform.position.y < -24f)
        {
            transform.position = new Vector3(0, 17, 0);
        }
    }
}
