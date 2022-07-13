using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using DG.Tweening;
using TMPro;
using UnityEngine.Audio;

public class UIManager : MonoBehaviour
{
    #region option
    [Header("�ɼ�")]
    [SerializeField] private Image _option;
    [SerializeField] private bool _optionCheck = false;
    #endregion

    #region sound
    [Header("����")]
    [SerializeField] AudioSource _audioSource;
    [SerializeField] Slider _sound;
    #endregion

    #region �����
    [Header("���� ���� Y��ǥ")]
    [SerializeField] private float _endPosY; // ���� ������ Y��ǥ
    private float _crtPosY; // ���� Y��ǥ

    private Transform _trmL; // L�� ��ġ
    private Transform _trmR; // R�� ��ġ

    [Header("���� ����� ǥ���� �ؽ�Ʈ")]
    [SerializeField] private TextMeshProUGUI crtProgressTxt; // ���� ����� ǥ���� �ؽ�Ʈ
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
            Debug.Log("a");
            OptionOpen();
            _optionCheck = true;
        }
        else if(Input.GetKeyDown(KeyCode.Escape) && _optionCheck)
        {
            OptionClose();
            _optionCheck = false;
        }

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

    public void GoToIntro()
    {
        SceneManager.LoadScene("Intro");
    }

    public void GoToInGmae()
    {
        SceneManager.LoadScene("InGame");
    }

    private void SetMuisc(float volume)
    {
        _sound.value = volume;
        _audioSource.volume = volume;
    }
    public void MusicSetting()
    {
        SetMuisc(_sound.value);
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
