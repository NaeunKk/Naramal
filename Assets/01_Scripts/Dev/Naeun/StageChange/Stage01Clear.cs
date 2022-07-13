using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Stage01Clear : MonoBehaviour
{
    private bool _playerR = false;
    private bool _playerL = false;
    GameObject _L;
    GameObject _R;

    private void Awake()
    {
        _L = GameObject.Find("L");
        _R = GameObject.Find("R");
    }

    
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("PlayerR"))
            _playerR = true;
        if (collision.gameObject.CompareTag("PlayerL"))
            _playerL = true;
    }

    private void Update()
    {
        if (_playerL == true && _playerR == true)
        {
            DeleteStageBar.Instance._isStage1Bar = true;
            _L.transform.position = new Vector3(-8, 37, 0);
            _R.transform.position = new Vector3(5, 37, 0);
            SceneManager.LoadScene("InGame");
        }
    }
}
