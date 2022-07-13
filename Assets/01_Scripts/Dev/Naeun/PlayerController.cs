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
    private Animator _pAnimator; // �ִϸ�����
    private Vector3 _pressedPosition = new Vector3(0, 0.5f, 0); // ������ �� �����ϴ� ��ġ ( + transporm.position ) �ؾ���
    [SerializeField] private string _tagName; // �÷��̾� �±� �̸�  L�̸� R�±� R�̸� L�±� ����־�θ� ��
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
        Vector3 pressedPosition = _pressedPosition + transform.position; // ���� ��ġ
        RaycastHit2D raycastHit2D = Physics2D.Raycast(pressedPosition, Vector3.up, 1); //����ĳ��Ʈ
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
