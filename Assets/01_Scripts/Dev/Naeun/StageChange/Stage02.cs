using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Stage02 : MonoBehaviour
{
    private bool _playerR = false;
    private bool _playerL = false;
    [SerializeField] GameObject L;
    [SerializeField] GameObject R;

    BoxCollider2D _stage2BoxCollider;

    private void Awake()
    {
        _stage2BoxCollider = GetComponent<BoxCollider2D>();
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

            SceneManager.LoadScene("Stage02");
            L.transform.position = new Vector3(-8, -1, 0);
            R.transform.position = new Vector3(-6, -1, 0);
        }
        DeleteBar();
    }
    private void DeleteBar()
    {
        if (DeleteStageBar._isStage2Bar == true)
        {
            _stage2BoxCollider.enabled = false;
        }
    }
}
