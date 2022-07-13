using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using DG.Tweening;
using UnityEngine.UI;

public class Intro : MonoBehaviour
{
    [SerializeField]
    private GameObject _panel; // 이 모든 것들이 있을 패널
    [SerializeField]
    private List<float> _doTxtSecs = new List<float>(); // 텍스트별 doText 시간
    [SerializeField]
    private List<string> _txts = new List<string>(); // 나오는 텍스트
    [SerializeField]
    private List<Sprite> _sprites = new List<Sprite>(); // 뒤쪽 스프라이트

    [SerializeField]
    private TextMeshProUGUI _mainTxt; // 텍스트를 송출할 텍스트
    [SerializeField]
    private Image _image; // 스프라이트를 출력할 이미지

    int num = 0;
    private void Start()
    {
        _panel.SetActive(true);
    }
    private void Update()
    {
        TextFatch();
    }
    private void TextFatch()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (num >= _txts.Count)
                _panel.SetActive(false);
            else
            {
                DoText(_mainTxt, _txts[num], _doTxtSecs[num]);
                if (_sprites[num] != null)
                {
                    _image.sprite = _sprites[num];
                }
                num++;
            }
        }
    }
    private void DoText(TextMeshProUGUI a_text, string txt, float a_duration)
    {
        a_text.text = txt;
        a_text.maxVisibleCharacters = 0;
        DOTween.To(x => a_text.maxVisibleCharacters = (int)x, 0f, a_text.text.Length + 1, a_duration);
    }
}
