using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeAttack : MonoBehaviour
{
    #region Start Point
    [Header("���� ����")]
    [SerializeField]
    private Vector3 startPos = Vector3.zero;
    #endregion
    #region Time Limit
    [Header("�ð� ����")]
    [SerializeField]
    private float limitTime = 0;
    private float crtTime = 0;
    #endregion
    #region �̵� �Ÿ�
    [Header("�̵� �Ÿ�")]

    [SerializeField]
    private Vector3 posX;

    private GameObject playerL;
    private GameObject playerR;
    #endregion

    private void Start()
    {
        playerL = GameObject.FindGameObjectWithTag("PlayerL");
        playerR = GameObject.FindGameObjectWithTag("PlayerR");

    }
    // Update is called once per frame
    void Update()
    {
        PlayTimeAttack();
    }
    private void PlayTimeAttack()
    {
        crtTime += Time.deltaTime;
        if(crtTime >= limitTime)
        {
            crtTime = 0;
            playerL.transform.position = startPos + posX;
            playerR.transform.position = startPos - posX;
        }
    }
}
