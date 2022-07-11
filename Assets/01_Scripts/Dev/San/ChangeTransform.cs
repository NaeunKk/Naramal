using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeTransform : MonoBehaviour
{
    [SerializeField] private KeyCode _keyL; // L이 키를 눌렀을 때 위치가 변합니다.
    [SerializeField] private KeyCode _keyR; // R이 키를 눌렀을 때 위치가 변합니다.
    [SerializeField] private GameObject _objL; // L 오브젝트
    [SerializeField] private GameObject _objR; // R 오브젝트
    [SerializeField] private float _skillCoolTime = 0; // 위치 바꾸기 스킬 쿨타임

    private bool _isSkillOn = true; // 스킬 사용 가능 여부
    private Vector3 _posL = Vector3.one; // L 위치값
    private Vector3 _posR = Vector3.one; // R 위치값



    // Update is called once per frame
    void Update()
    {
        TransfromChangingLR();
    }

    private void TransfromChangingLR()
    {
        if(Input.GetKeyDown(_keyL) && _isSkillOn || Input.GetKeyDown(_keyR) && _isSkillOn)
        {
            // 위치 받아오기
            _posL = _objL.transform.position;
            _posR = _objR.transform.position;
            // 위치 바꾸기
            Vector3 posL = _posL;
            _objL.transform.position = _posR;
            _objR.transform.position = posL;
            StartCoroutine("Delay");
        }
    }
    IEnumerator Delay()
    {
        _isSkillOn = false;
        yield return new WaitForSeconds(_skillCoolTime);
        _isSkillOn = true;
    }
}
