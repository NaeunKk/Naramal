using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Stage03 : MonoBehaviour
{
    private bool _playerR = false;
    private bool _playerL = false;
    GameObject L;
    GameObject R;

    UIManager _ui;

    BoxCollider2D _stage3BoxCollider;

    private void Start()
    {
        L = GameManager.Instance._playerL;
        R = GameManager.Instance._playerR;
        _ui = GameObject.Find("Manager/UIManager").GetComponent<UIManager>();
        _stage3BoxCollider = GetComponent<BoxCollider2D>();
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
        _ui.crtProgressTxt.gameObject.SetActive(false);
        SceneManager.LoadScene("Stage03");
        L.transform.position = new Vector3(-3, -4, 0);
        R.transform.position = new Vector3(3, -4, 0);
        }
        deleteBar();

    }

    private void deleteBar()
    {
        if (DeleteStageBar._isStage3Bar == true)
        {
            _stage3BoxCollider.enabled = false;
        }
    }
}
