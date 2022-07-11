using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeTransform : MonoBehaviour
{
    [SerializeField] private KeyCode _key; // 이 키를 눌렀을 때 위치가 변합니다.
    [SerializeField] private GameObject _objL; // L 오브젝트
    [SerializeField] private GameObject _objR; // R 오브젝트

    private Vector3 _posL; // L 위치값
    private Vector3 _posR; // R 위치값

    // Start is called before the first frame update
    void Start()
    {
        _posL = _objL.transform.position;
        _posR = _objR.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        TransfromChangingLR();
    }

    private void TransfromChangingLR()
    {
        Vector3 posL = _posL;
        _objL.transform.position = _posR;
        _objR.transform.position = posL;
    }
}
