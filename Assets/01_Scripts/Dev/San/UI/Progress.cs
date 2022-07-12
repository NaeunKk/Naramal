using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Progress : MonoBehaviour
{
    [Header("���� ���� Y��ǥ")]
    [SerializeField] private float _endPosY; // ���� ������ Y��ǥ
    private float _crtPosY; // ���� Y��ǥ

    private Transform _trmL; // L�� ��ġ
    private Transform _trmR; // R�� ��ġ

    [Header("���� ����� ǥ���� �ؽ�Ʈ")]
    [SerializeField] private TextMeshProUGUI crtProgressTxt; // ���� ����� ǥ���� �ؽ�Ʈ

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
