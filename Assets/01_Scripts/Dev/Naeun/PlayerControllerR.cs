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
            platformPos = platform.transform.position;
            distance = platformPos - transform.position;
        }
        else if (platform != null && !(Input.GetKey(KeyCode.W)))
        {
            if (isGround)
                transform.position = platform.transform.position - distance;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("MovingPlatform"))
        {
            isGround = true;
            platform = collision.gameObject;
            platformPos = platform.transform.position;
            distance = platformPos - transform.position;
        }

    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("MovingPlatform"))
        {
            isGround = false;
            platform = null;
        }
    }
}
