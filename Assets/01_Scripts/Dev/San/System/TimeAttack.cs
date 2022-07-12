using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeAttack : MonoBehaviour
{
    [Header("시작 지점 좌표 & 제한 시간")]
    [SerializeField]
    private Vector3 startPos = Vector3.zero;

    [SerializeField]
    private float time = 0;
    private float crtTime = 0;

    [Header("좌표에서 좌우로 이만큼 이동되어 플레이어가 스폰됨")]

    [SerializeField]
    private Vector3 posX;

    private GameObject playerL;
    private GameObject playerR;

    // Update is called once per frame
    void Update()
    {
        PlayTimeAttack();
    }
    private void PlayTimeAttack()
    {
        crtTime += Time.deltaTime;
        if(crtTime >= time)
        {
            crtTime = 0;
            playerL.transform.position = startPos + posX;
            playerR.transform.position = startPos - posX;

        }
    }
}
