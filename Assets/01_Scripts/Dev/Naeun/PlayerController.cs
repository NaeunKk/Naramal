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
    [SerializeField] private bool _isJumping = false;
    #endregion
    #region Animation
    private Animator _pAnimator; // 애니메이터
    private Vector3 _pressedPosition = new Vector3(0, 0.5f, 0); // 누르는 걸 감지하는 위치 ( + transporm.position ) 해야함
    [SerializeField] private string _tagName; // 플레이어 태그 이름  L이면 R태그 R이면 L태그 적어넣어두면 됨
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


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            _jumpCount = 0;
        }
    }

    protected virtual void Jump(KeyCode key)
    {
        if (Input.GetKeyDown(key) && _isJumping == true)
        {
            _rigidJump2D.AddForce(Vector2.up * _jumpPower, ForceMode2D.Impulse);
            _jumpCount++;
            _isJumping = false;
        }
    }

    protected void JumpLimit()
    {
        if (_jumpCount < _jumpMaxCount)
        {
            _isJumping = true;
        }
    }
    protected void Move(KeyCode key, float dir)
    {
        if (Input.GetKey(key))
        {
            transform.position += new Vector3(dir, 0, 0) * _moveSpeed * Time.deltaTime;
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
