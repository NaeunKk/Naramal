using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using DG.Tweening;
using TMPro;
using UnityEngine.Audio;

public class UIManager : MonoBehaviour
{
    #region option
    [Header("옵션")]
    [SerializeField] private Image _option;
    [SerializeField] private bool _optionCheck = false;
    #endregion

    #region sound
    [Header("사운드")]
    public AudioSource _audioSource;
    [SerializeField] Slider _slider;
    #endregion

    #region 진행률
    [Header("최종 지점 Y좌표")]
    [SerializeField] private float _endPosY; // 최종 지점의 Y좌표
    private float _crtPosY; // 현재 Y좌표

    [SerializeField] private Transform _trmL; // L의 위치
    [SerializeField] private Transform _trmR; // R의 위치

    [Header("현재 진행률 표시할 텍스트")]
    public TextMeshProUGUI crtProgressTxt; // 현재 진행률 표시할 텍스트
    #endregion

    private void Start()
    {
        _option = GameObject.Find("Manager/Canvas/Option").GetComponent<Image>();
        _slider = GameObject.Find("Manager/Canvas/Option/Sound").GetComponent<Slider>();
        crtProgressTxt = GameObject.Find("Manager/Canvas/Progress").GetComponent<TextMeshProUGUI>();
        _trmL = GameObject.FindGameObjectWithTag("PlayerL").GetComponent<Transform>();
        _trmR = GameObject.FindGameObjectWithTag("PlayerR").GetComponent<Transform>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !_optionCheck)
        {
            OptionOpen();
        }
        else if (Input.GetKeyDown(KeyCode.Escape) && _optionCheck)
        {
            OptionClose();
            _optionCheck = false;
        }

        CurrentProgress();
    }

    public void OptionOpen()
    {
        _option.gameObject.SetActive(true);
        _optionCheck = true;
    }
    public void OptionClose()
    {
        _option.gameObject?.SetActive(false);
    }

    public void GoToInGame()
    {
        crtProgressTxt.gameObject.SetActive(true);
        SceneManager.LoadScene("P");
    }

    public void GoToIntro()
    {
        SceneManager.LoadScene("Intro");
    }

    public void GoToMenu()
    {
        SceneManager.LoadScene("Menu");
    }

    public void Volume()
    {
        SetMuisc(_slider.value);
    }

    private void SetMuisc(float volume)
    {
        _audioSource.volume = volume;
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

    public void ExitGameButton()
    {
        Application.Quit();
    }

    public void LRTrm()
    {
        _trmL = GameObject.FindGameObjectWithTag("PlayerL").GetComponent<Transform>();
        _trmR = GameObject.FindGameObjectWithTag("PlayerR").GetComponent<Transform>();
    }
}
