using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Stage03 : MonoBehaviour
{
    private bool _playerR = false;
    private bool _playerL = false;
    [SerializeField] GameObject L;
    [SerializeField] GameObject R;

    BoxCollider2D _stage3BoxCollider;

    private void Awake()
    {
        _stage3BoxCollider = GetComponent<BoxCollider2D>();
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("PlayerR"))
            _playerR = true;
        if (collision.collider.CompareTag("PlayerL"))
            _playerL = true;
    }

    private void Update()
    {
        if (_playerL == true && _playerR == true)
        {
            SceneManager.LoadScene("Stage03");
            L.transform.position = new Vector3(-3, 0, 0);
            R.transform.position = new Vector3(3, 0, 0);
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
