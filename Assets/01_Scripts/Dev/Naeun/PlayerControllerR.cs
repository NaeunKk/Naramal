using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerR : PlayerController
{
    void Start()
    {
        
    }

    void Update()
    {
        Move();
    }

    void Move()
    {
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.position += new Vector3(1, 0, 0) * speed * Time.deltaTime;
        }

    }
}
