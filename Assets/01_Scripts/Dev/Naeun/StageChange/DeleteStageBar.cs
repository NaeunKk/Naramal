using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteStageBar : MonoBehaviour
{
    public static DeleteStageBar Instance;
    public bool _isStage1Bar = false;

    private void Awake()
    {
        if(Instance == null)
            Instance = this;
    }

    private void Update()
    {
        Stage1();
    }

    private void Stage1()
    {
        //스테이지 1에서 포탈을 타면 _isStage1Bar를 true로 바꾸게 하기
    }
}
