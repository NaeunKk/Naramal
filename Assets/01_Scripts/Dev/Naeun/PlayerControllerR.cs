using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerR : PlayerController
{
    void Update()
    {
        Move();
        if (Input.GetKeyDown(KeyCode.UpArrow))
            Jump();
        IsGrounded();
        Jumplimit();
    }

    void Move()
    {
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.position += new Vector3(1, 0, 0) * _moveSpeed * Time.deltaTime;
        }
    }

    protected override void Jump()
    {
        base.Jump();
    }
}
