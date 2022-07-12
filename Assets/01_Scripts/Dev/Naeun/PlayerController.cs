using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    #region Move
    [Header("Move")]
    private Rigidbody2D _rigidJump2D;
    [SerializeField] protected float _moveSpeed = 5;
    [SerializeField] protected float _jumpPower = 2;
    [SerializeField] protected int _jumpCount = 0;
    [SerializeField] protected int _jumpMaxCount = 0;
    #endregion
    #region Animation
    private Animator _pAnimator; // 애니메이터
    private Vector3 _pressedPosition = new Vector3(0, 0.5f, 0); // 누르는 걸 감지하는 위치 ( + transporm.position ) 해야함
    [SerializeField] private string _tagName; // 플레이어 태그 이름  L이면 R태그 R이면 L태그 적어넣어두면 됨
    #endregion
    #region Moving Platform
    [Header("움직이는 발판")]
    [SerializeField] protected bool isGround = false;
    [SerializeField] protected GameObject platform;
    [SerializeField] protected Vector3 distance;
    [SerializeField] protected Vector3 platformPos;
    #endregion

    protected virtual void Awake()
    {
        _rigidJump2D = GetComponent<Rigidbody2D>();
        _pAnimator = GetComponent<Animator>();
    }

    protected void Update()
    {
        PressedOn();
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

    protected void PressedOn()
    {
        Vector3 pressedPosition = _pressedPosition + transform.position; // 감지 위치
        RaycastHit2D raycastHit2D = Physics2D.Raycast(pressedPosition, Vector3.up, 1); //레이캐스트
        Debug.DrawRay(pressedPosition, Vector3.up);
        Debug.Log("a");
        if (raycastHit2D.collider != null && raycastHit2D.transform.CompareTag(_tagName))
        {
            Debug.Log("b");
            _pAnimator.SetBool("isPressed", true);
        }
        else
        {
            _pAnimator.SetBool("isPressed", false);
        }
    }
}
