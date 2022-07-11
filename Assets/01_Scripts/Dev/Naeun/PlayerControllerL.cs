using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerL : PlayerController
{
    void Update()
    {
        Move();
        if(Input.GetKeyDown(KeyCode.W))
            Jump();
        IsGrounded();
        Jumplimit();
    }

    void Move()
    {
        if (Input.GetKey(KeyCode.A))
        {
            transform.position += new Vector3(-1, 0, 0) * _moveSpeed * Time.deltaTime;
        }
    }

    protected override void Jump()
    {
        base.Jump();
    }
}
