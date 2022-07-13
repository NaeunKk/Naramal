using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerL : PlayerController
{
    float dir = -1;
    protected void Update()
    {
        base.Update();
        if (Input.GetKeyDown(KeyCode.W))
            Jump(KeyCode.W);
        JumpLimit();
        Move(KeyCode.A, dir);
    }
}
