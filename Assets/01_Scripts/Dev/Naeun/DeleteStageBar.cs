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
        //�������� 1���� ��Ż�� Ÿ�� _isStage1Bar�� true�� �ٲٰ� �ϱ�
    }
}
