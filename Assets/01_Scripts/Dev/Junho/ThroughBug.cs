using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ThroughBug : MonoBehaviour
{
    [SerializeField] private GameObject _playerR;//?????? ?߰??ϱ?
    [SerializeField] private GameObject _playerL;//?????? ?߰??ϱ?
    
    [SerializeField] private float _bugTriggerTimeR = 0f;
    [SerializeField] private float _bugTriggerTimeL = 0f;

    [SerializeField] private bool _isTriggerOnR = false;//?ð? ?? ?帣?? ?ϴ? ????
    [SerializeField] private bool _isTriggerOnL = false;//?ð? ?? ?帣?? ?ϴ? ????

    [Header("???? ?ð? ?? ???? ????")]
    [SerializeField] private float ThroughStartDelayR = 3f;
    [SerializeField] private float ThroughStartDelayL = 3f;

    [Header("???? ??ġ ??ŭ ??????")]
    [SerializeField] private float FallingValue = 10f;

    private void Awake()
    { 
        _playerL = GameObject.Find("L").GetComponent<GameObject>();
        _playerR = GameObject.Find("R").GetComponent<GameObject>();
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