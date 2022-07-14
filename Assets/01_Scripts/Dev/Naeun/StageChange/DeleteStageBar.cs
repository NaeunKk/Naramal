using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteStageBar : MonoBehaviour
{
    public static DeleteStageBar Instance;
    public static bool _isStage1Bar = false;
    public static bool _isStage2Bar = false;
    public static bool _isStage3Bar = false;


    private void Awake()
    {
        if (Instance == null)
            Instance = this;

        Debug.Log("dd");

    }

    private void Update()
    {

    }

    private void Reset()
    {
        //Do Not
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Clear"))
        {
            _isStage1Bar = true;
        }
        if (collision.gameObject.CompareTag("Clear2"))
        {
            _isStage2Bar = true;
        }
    }
}
