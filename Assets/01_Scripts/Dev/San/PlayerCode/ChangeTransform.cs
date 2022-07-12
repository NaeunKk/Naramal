using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeTransform : MonoBehaviour
{
    [SerializeField] private KeyCode _keyL; // L�� Ű�� ������ �� ��ġ�� ���մϴ�.
    [SerializeField] private KeyCode _keyR; // R�� Ű�� ������ �� ��ġ�� ���մϴ�.
    [SerializeField] private GameObject _objL; // L ������Ʈ
    [SerializeField] private GameObject _objR; // R ������Ʈ
    [SerializeField] private float _skillCoolTime = 0; // ��ġ �ٲٱ� ��ų ��Ÿ��

    private bool _isSkillOn = true; // ��ų ��� ���� ����
    private Vector3 _posL = Vector3.one; // L ��ġ��
    private Vector3 _posR = Vector3.one; // R ��ġ��

    [SerializeField]
    private GameObject _particleSystem;



    // Update is called once per frame
    void Update()
    {
        TransfromChangingLR();
    }

    private void TransfromChangingLR()
    {
        if(Input.GetKeyDown(_keyL) && _isSkillOn || Input.GetKeyDown(_keyR) && _isSkillOn)
        {
            TrmChangingLR();
        }
    }
    // ������ ��ġ �ٲٴ� �޼���
    public void TrmChangingLR()
    {
        // ��ġ �޾ƿ���
        _posL = _objL.transform.position;
        _posR = _objR.transform.position;

        _objL.transform.position = _posR;
        _objR.transform.position = _posL;
        // ��ƼŬ ȿ��
        GameObject particleL = PoolingManager.Instance.Pop(_particleSystem);
        particleL.transform.position = _posL;
        GameObject particleR = PoolingManager.Instance.Pop(_particleSystem);
        particleR.transform.position = _posR;
        StartCoroutine("Delay");
    }
    IEnumerator Delay()
    {
        _isSkillOn = false;
        yield return new WaitForSeconds(_skillCoolTime);
        _isSkillOn = true;
    }
}
