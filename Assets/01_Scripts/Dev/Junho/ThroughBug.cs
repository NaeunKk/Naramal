using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ThroughBug : MonoBehaviour
{
    [SerializeField] private GameObject _playerR = null;
    [SerializeField] private GameObject _playerL = null;
    
    [SerializeField] private float _bugTriggerTime = 0f;

    private bool _isTriggerOn = false;

    private void Awake()
    { 
    }

    private void Update()
    {
        if(_isTriggerOn == true)
        {
            TimeCheck(); 
        }
        ThroughBugRunning();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        _isTriggerOn = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        _bugTriggerTime = 0f;
        _isTriggerOn = false;
    }
    
    private void TimeCheck()
    {
        _bugTriggerTime += Time.deltaTime;
    }

    private void ThroughBugRunning()
    {
        if (_bugTriggerTime > 3f)
        {
            
        }
    }
}
