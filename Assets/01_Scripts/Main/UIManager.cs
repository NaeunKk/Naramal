using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using DG.Tweening;
using TMPro;

public class UIManager : MonoBehaviour
{
    #region option
    [Header("옵션")]
    [SerializeField] private Image _option;
    [SerializeField] private bool _optionCheck = false;
    #endregion

    #region sound
    [Header("사운드")]
    [SerializeField] private AudioSource _bgm;
    #endregion

    #region particle
    [Header("효과")] 
    [SerializeField] private float _deleteTime;
    private float _crtTime = 0;
    #endregion

    #region 진행률
    [Header("최종 지점 Y좌표")]
    [SerializeField] private float _endPosY; // 최종 지점의 Y좌표
    private float _crtPosY; // 현재 Y좌표

    private Transform _trmL; // L의 위치
    private Transform _trmR; // R의 위치

    [Header("현재 진행률 표시할 텍스트")]
    [SerializeField] private TextMeshProUGUI crtProgressTxt; // 현재 진행률 표시할 텍스트
    #endregion

    private void Awake()
    {
        _trmL = GameObject.FindGameObjectWithTag("PlayerL").GetComponent<Transform>();
        _trmR = GameObject.FindGameObjectWithTag("PlayerR").GetComponent<Transform>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !_optionCheck)
        {
            OptionOpen();
            _optionCheck = true;
        }
        else if(Input.GetKeyDown(KeyCode.Escape) && _optionCheck)
        {
            OptionClose();
            _optionCheck = false;
        }

        OnDelete();
        CurrentProgress();
    }

    void OptionOpen()
    {
        _option.gameObject.SetActive(true);
    }
    void OptionClose()
    {
        _option.gameObject?.SetActive(false);
    }


    public void VolumeControll(float volume)
    {
        _bgm.volume = volume;
    }

    private void OnDelete()
    {
        _crtTime += Time.deltaTime;
        if (_crtTime > _deleteTime)
        {
            _crtTime = 0;
            PoolingManager.Instance.Push(gameObject);
        }
    }

    private void CurrentProgress()
    {
        if (_trmL.position.y > _trmR.position.y)
            _crtPosY = _trmL.position.y;
        else
            _crtPosY = _trmR.position.y;

        float crtProgress = Mathf.Floor(Mathf.Lerp(0, 100, _crtPosY / _endPosY));
        crtProgressTxt.text = $"{crtProgress}%";
    }
}
