using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.ParticleSystemJobs;

public class IsPressed : MonoBehaviour
{
    private Animator _pAnimator; // �ִϸ�����
    private Vector3 _pressedPosition = new Vector3(0, 0.5f, 0); // ������ �� �����ϴ� ��ġ ( + transporm.position ) �ؾ���
    [SerializeField] private string _tagName; // �÷��̾� �±� �̸�  L�̸� R�±� R�̸� L�±� ����־�θ� ��

    // Start is called before the first frame update
    void Start()
    {
        _pAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        PressedOn();
        
    }

    private void PressedOn()
    {
        Vector3 pressedPosition = _pressedPosition + transform.position; // ���� ��ġ
        RaycastHit2D raycastHit2D = Physics2D.Raycast(pressedPosition, Vector3.up, 1); //����ĳ��Ʈ
        Debug.DrawRay(pressedPosition, Vector3.up);
        if (raycastHit2D.collider != null && raycastHit2D.transform.CompareTag(_tagName))
        {
            _pAnimator.SetBool("isPressed", true);
        }
        else
        {
            _pAnimator.SetBool("isPressed", false);
        }
    }
}
