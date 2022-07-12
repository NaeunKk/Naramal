using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    [SerializeField] int _moveFlag = 1;
    [SerializeField] float _moveSpeed = 7;
    [SerializeField] float _movePower = 0.12f;

    private void Start()
    {
        StartCoroutine(PlatformMove());
    }

    private void LateUpdate()
    {
        Move();
    }

    void Move()
    {
        Vector3 moveVelocity = Vector3.zero;

        if (this._moveFlag == 1)
            moveVelocity = new Vector3(_movePower, 0, 0);
        else moveVelocity = new Vector3(-_movePower, 0, 0);

        transform.position += moveVelocity * _moveSpeed * Time.deltaTime;
    }
    IEnumerator PlatformMove()
    {
        while (true)
        {
            if (_moveFlag == 1)
                _moveFlag = 2;
            else _moveFlag = 1;
            yield return new WaitForSeconds(2f);
        }
    }
}
