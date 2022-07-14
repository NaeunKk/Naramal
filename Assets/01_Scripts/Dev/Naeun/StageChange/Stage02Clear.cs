using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Stage02Clear : MonoBehaviour
{
    private bool _playerR = false;
    private bool _playerL = false;
    GameObject _L;
    GameObject _R;

    [SerializeField]UIManager _ui;

    private void Awake()
    {
        _ui = GameObject.Find("Manager/UIManager").GetComponent<UIManager>();
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
            _L.transform.position = new Vector3(6, 98, 0);
            _R.transform.position = new Vector3(8, 98, 0);
            _ui.crtProgressTxt.gameObject.SetActive(true);
            SceneManager.LoadScene("P");
        }
    }


}
