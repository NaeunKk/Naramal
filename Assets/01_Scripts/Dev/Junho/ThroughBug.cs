using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ThroughBug : MonoBehaviour
{
    [SerializeField] private GameObject _playerR;//¾À¿¡¼­ Ãß°¡ÇÏ±â
    [SerializeField] private GameObject _playerL;//¾À¿¡¼­ Ãß°¡ÇÏ±â
    
    [SerializeField] private float _bugTriggerTimeR = 0f;
    [SerializeField] private float _bugTriggerTimeL = 0f;

    [SerializeField] private bool _isTriggerOnR = false;//½Ã°£ ÃÊ Èå¸£°Ô ÇÏ´Â º¯¼ö
    [SerializeField] private bool _isTriggerOnL = false;//½Ã°£ ÃÊ Èå¸£°Ô ÇÏ´Â º¯¼ö

    [Header("¹ØÀÇ ½Ã°£ ÈÄ ¶¥À» ¶ÕÀ½")]
    [SerializeField] private float ThroughStartDelayR = 3f;
    [SerializeField] private float ThroughStartDelayL = 3f;

    [Header("¹ØÀÇ ¼öÄ¡ ¸¸Å­ ¶³¾îÁü")]
    [SerializeField] private float FallingValue = 10f;

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
        if(collision.gameObject.CompareTag("PlayerR"))
        {
            _isTriggerOnR = true;
        }
        if(collision.gameObject.CompareTag("PlayerL"))
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
        if (_bugTriggerTimeR > ThroughStartDelayR)
        {
            Debug.Log("RRRRR");
            _playerR.transform.position = new Vector3(transform.position.x, transform.position.y-FallingValue, 0);
        }
        if (_bugTriggerTimeL > ThroughStartDelayL)
        {
            Debug.Log("LLLLL");
            _playerL.transform.position = new Vector3(transform.position.x, transform.position.y-FallingValue, 0);
        }
    }
}