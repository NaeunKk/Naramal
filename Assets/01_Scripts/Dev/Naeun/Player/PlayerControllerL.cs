using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerL : PlayerController
{
    float dir = -1;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
            Jump(KeyCode.W);
        JumpLimit();
        Move(KeyCode.A, dir);
    }

    private void Start()
    {
        if (GameManager.Instance._stage == 1)
            gameObject.transform.position = new Vector3(-7, 38, 0);
        else if (GameManager.Instance._stage == 2)
            gameObject.transform.position = new Vector3(6, 100, 0);
        else if (GameManager.Instance._stage == 3)
            gameObject.transform.position = new Vector3(100, 100, -100);
    }
}
