using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Stage01 : MonoBehaviour
{
    private bool _playerR = false;
    private bool _playerL = false;
    [SerializeField] GameObject L;
    [SerializeField] GameObject R;

    BoxCollider2D _stage1BoxCollider;

    private void Awake()
    {
        _stage1BoxCollider = GetComponent<BoxCollider2D>();
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
        if(_playerL == true && _playerR == true)
        {
            SceneManager.LoadScene("Stage01");
            L.transform.position = new Vector3(203, 20, 0);
            R.transform.position = new Vector3(204, 20, 0);
        }
        deleteBar();

    }

    private void deleteBar()
    {
        if (DeleteStageBar.Instance._isStage1Bar == true)
        {
            _stage1BoxCollider.enabled = false;
        }
    }
}
