using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D _rigidJump2D;
    [SerializeField] protected float _moveSpeed = 5;
    [SerializeField] protected float _jumpPower = 2;
    [SerializeField] protected int _jumpCount = 0;
    [SerializeField] protected int _jumpMaxCount = 0;

    protected virtual void Awake()
    {
        _rigidJump2D = GetComponent<Rigidbody2D>();
    }

    protected virtual void Jump()
    {
        //점프 횟수
        if (_jumpCount < _jumpMaxCount)
        {
            _jumpCount++;
            _rigidJump2D.AddForce(Vector2.up * _jumpPower, ForceMode2D.Impulse);
        }

        if (_rigidJump2D.velocity.y == 0)
        {
            _rigidJump2D.AddForce(Vector2.up * _jumpPower, ForceMode2D.Impulse);
        }
    }

    protected void IsGrounded()
    {
        if (_rigidJump2D.velocity.y < 0)
        {
            RaycastHit2D raycastHit2D = Physics2D.Raycast(transform.position, Vector3.down, 1, LayerMask.GetMask("Ground")); //레이캐스트 설정
            if (raycastHit2D.collider != null)
            {
                _jumpCount = 0;
            }
        }
    }
    protected void Jumplimit()
    {
        if (_jumpCount < 0)
        {
            _jumpCount++;
        }
    }
}
