using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using DG.Tweening;
using TMPro;
using UnityEngine.Audio;

public class UIManager : MonoBehaviour
{
    #region �����
    [Header("���� ���� Y��ǥ")]
    [SerializeField] private float _endPosY; // ���� ������ Y��ǥ
    private float _crtPosY; // ���� Y��ǥ

    [SerializeField] private Transform _trmL; // L�� ��ġ
    [SerializeField] private Transform _trmR; // R�� ��ġ

    [Header("���� ����� ǥ���� �ؽ�Ʈ")]
    public TextMeshProUGUI crtProgressTxt; // ���� ����� ǥ���� �ؽ�Ʈ
    #endregion

    private void Start()
    {
        crtProgressTxt = GameObject.Find("Manager/Canvas/Progress").GetComponent<TextMeshProUGUI>();
        _trmL = GameObject.FindGameObjectWithTag("PlayerL").GetComponent<Transform>();
        _trmR = GameObject.FindGameObjectWithTag("PlayerR").GetComponent<Transform>();
    }

    private void Update()
    {
        CurrentProgress();
    }

    

    private void CurrentProgress()
    {
        if (_trmL != null && _trmR != null)
        {
            if (_trmL.position.y > _trmR.position.y)
                _crtPosY = _trmL.position.y;
            else
                _crtPosY = _trmR.position.y;

            float crtProgress = Mathf.Floor(Mathf.Lerp(0, 100, _crtPosY / _endPosY));
            crtProgressTxt.text = $"{crtProgress}%";
        }

    }

    public void LRTrm()
    {
        _trmL = GameObject.FindGameObjectWithTag("PlayerL").GetComponent<Transform>();
        _trmR = GameObject.FindGameObjectWithTag("PlayerR").GetComponent<Transform>();
    }
}
