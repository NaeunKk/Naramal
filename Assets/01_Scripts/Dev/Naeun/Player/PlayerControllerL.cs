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
}
