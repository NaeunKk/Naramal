using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TimeAttackSceneChange : MonoBehaviour
{
    [Header("Ư�� ��ġ")]
    [SerializeField]
    private List<Vector2> _colPos;
    [Header("���� ����")]
    [SerializeField]
    private List<Vector2> _colSize;
    [Header("��ȯ�� �� �̸�")]
    [SerializeField]
    private List<string> scenes;

    // Update is called once per frame
    void Update()
    {
        TimeAttackSenser();
    }
    private void TimeAttackSenser()
    {
        for(int i = 0; i < _colPos.Count; i++)
        {
            Debug.DrawRay(_colPos[i], Vector2.up);
            Collider2D box = Physics2D.OverlapBox(_colPos[i], _colSize[i], 0);

            if(box != null && box.transform.CompareTag("PlayerL") || box != null && box.transform.CompareTag("PlayerR"))
            {
                SceneManager.LoadScene(scenes[i]);
            }
        }
        
    }
}
