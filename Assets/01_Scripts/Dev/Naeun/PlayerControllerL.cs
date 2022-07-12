using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerL : PlayerController
{
    [SerializeField] bool isGround = false;
    [SerializeField] GameObject platform;
    [SerializeField] Vector3 distance;
    [SerializeField] Vector3 platfromPos;

    void Update()
    {
        Move();
        if(Input.GetKeyDown(KeyCode.W))
            Jump();
        IsGrounded();
        Jumplimit();

        if (platform != null)
            if (isGround)
                transform.position = platform.transform.position - distance;
    }

    void Move()
    {
        if (Input.GetKey(KeyCode.A))
        {
            transform.position += new Vector3(-1, 0, 0) * _moveSpeed * Time.deltaTime;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("MovingPlatform"))
        {
            isGround = true;
            platform = collision.gameObject;
            platfromPos = platform.transform.position;
            distance = platfromPos - transform.position;
        }
    }

    protected override void Jump()
    {
        base.Jump();
    }

    
}
