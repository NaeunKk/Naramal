using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestCode : MonoBehaviour
{
    private Animator _pAnimator;
    // Start is called before the first frame update
    void Start()
    {
        _pAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Test();
    }
    private void Test()
    {   
        if(Input.GetKeyDown(KeyCode.N))
            _pAnimator.SetBool("isPressed", true);
        if(Input.GetKeyDown (KeyCode.M))
            _pAnimator.SetBool("isPressed", false);

    }
}
