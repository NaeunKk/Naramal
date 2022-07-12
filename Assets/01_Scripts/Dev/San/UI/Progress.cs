using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Progress : MonoBehaviour
{
    [Header("최종 지점 Y좌표")]
    [SerializeField] private float _endPosY; // 최종 지점의 Y좌표
    private float _crtPosY; // 현재 Y좌표

    private Transform _trmL; // L의 위치
    private Transform _trmR; // R의 위치

    [Header("현재 진행률 표시할 텍스트")]
    [SerializeField] private TextMeshProUGUI crtProgressTxt; // 현재 진행률 표시할 텍스트

    private void Start()
    {
        _trmL = GameObject.FindGameObjectWithTag("PlayerL").GetComponent<Transform>();
        _trmR = GameObject.FindGameObjectWithTag("PlayerR").GetComponent<Transform>();
    }
    // Update is called once per frame
    void Update()
    {
        CurrentProgress();
    }
    private void CurrentProgress()
    {
        if(_trmL.position.y > _trmR.position.y)
            _crtPosY = _trmL.position.y;
        else
            _crtPosY = _trmR.position.y;

        float crtProgress = Mathf.Floor(Mathf.Lerp(0, 100, _crtPosY / _endPosY));
        crtProgressTxt.text = $"{crtProgress}%";
    }
}
