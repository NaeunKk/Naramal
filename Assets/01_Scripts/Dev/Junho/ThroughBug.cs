using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ThroughBug : MonoBehaviour
{
    [SerializeField] private GameObject _playerR = null;
    [SerializeField] private GameObject _playerL = null;
    
    [SerializeField] private float _bugTriggerTimeR = 0f;
    [SerializeField] private float _bugTriggerTimeL = 0f;

    [SerializeField] private bool _isTriggerOnR = false;//시간 초 흐르게 하는 변수
    [SerializeField] private bool _isTriggerOnL = false;//시간 초 흐르게 하는 변수
    [SerializeField] private bool _isBugRunning = false;//버그 실행하게 하는 변수

    private void Awake()
    { 

    }

    private void Update()
    {
        TimeCheck(); 
        ThroughBugRunning();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject == _playerR)
        {
            _isTriggerOnR = true;
        }
        if(collision.gameObject == _playerL)
        {
            _isTriggerOnL = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        _bugTriggerTimeR = 0f;
        _bugTriggerTimeL = 0f;
        _isTriggerOnR = false;
        _isTriggerOnL = false;
    }
    
    private void TimeCheck()
    {
        if(_isTriggerOnR == true)
        {
            _bugTriggerTimeR += Time.deltaTime;
        }
        if(_isTriggerOnL == true)
        {
            _bugTriggerTimeL += Time.deltaTime;
        }
    }

    private void ThroughBugRunning()
    {
        if (_bugTriggerTimeR > 3f)
        {
            _playerR.transform.position -= new Vector3(0, 5, 0);
        }
    }
}
