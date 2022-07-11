using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeTransform : MonoBehaviour
{
    [SerializeField] private KeyCode _key; // �� Ű�� ������ �� ��ġ�� ���մϴ�.
    [SerializeField] private GameObject _objL; // L ������Ʈ
    [SerializeField] private GameObject _objR; // R ������Ʈ

    private Vector3 _posL; // L ��ġ��
    private Vector3 _posR; // R ��ġ��

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
