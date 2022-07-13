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
    [SerializeField] private bool _isJumping = false;
    [SerializeField] private float _ray = 0.6f;
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
        Debug.DrawRay(transform.position, Vector2.down * _ray, Color.red);
        PressedOn();
        Debug.DrawRay(transform.position, Vector2.down * _ray, Color.red);
    }

    protected void Jump(KeyCode key)
    {
        if (Input.GetKeyDown(key) && _isJumping == true)
        {
            _rigidJump2D.AddForce(Vector2.up * _jumpPower, ForceMode2D.Impulse);
            _isJumping = false;
        }
    }

    protected void JumpLimit()
    {
        RaycastHit2D raycastHit2D = Physics2D.Raycast(transform.position, Vector3.down, _ray, LayerMask.GetMask("Ground"));
        if (raycastHit2D.collider != null)
        {
            _isJumping = true;
        }
        else if (raycastHit2D.collider == null)
        {
            //Debug.Log("a");
            _isJumping = false;
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

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("MovingPlatform"))
            gameObject.transform.SetParent(collision.gameObject.transform);
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("MovingPlatform"))
            gameObject.transform.SetParent(null);
    }
}
