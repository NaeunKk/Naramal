using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class RepeatJumpBox : MonoBehaviour
{
    [SerializeField] private bool _isRepeatTrigger = false;//�� �� �� ����� �� �ð��� Ű�� ���� ����
    [SerializeField] private float _RepeatJumpBoxTime = 0f;

    [SerializeField] private SpriteRenderer _RepeatJumpSprite;

    [Header("���� �ð� �� �����")]
    [SerializeField] private float RepeatStartDelay = 3f;


    private BoxCollider2D _RepeatJumpCollider;


    private void Awake()
    {
        _RepeatJumpSprite = GetComponent<SpriteRenderer>();
        _RepeatJumpCollider = GetComponent<BoxCollider2D>();
    }

    private void Update()
    {
        HidingTime();
        HidingBox();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        _isRepeatTrigger = true;
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        _RepeatJumpBoxTime = 0f;
        _isRepeatTrigger= false;
    }

    private void HidingTime()
    {
        if (_isRepeatTrigger == true)
        {
            _RepeatJumpBoxTime += Time.deltaTime;
        }
    }

    private void HidingBox()
    {
        if (_RepeatJumpBoxTime > RepeatStartDelay)
        {
            StartCoroutine(HidingDelay());
        }
    }

    IEnumerator HidingDelay()
    {
        _RepeatJumpBoxTime = 0f;
        _RepeatJumpSprite.DOFade(0, 2f);
        _RepeatJumpCollider.enabled = false;
        _isRepeatTrigger = false;
        yield return new WaitForSeconds(1.5f);
        _RepeatJumpCollider.enabled = true;
        _RepeatJumpSprite.DOFade(2, 2f);

    }
}
