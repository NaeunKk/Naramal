using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerR : PlayerController
{
    float dir = 1;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
            Jump(KeyCode.UpArrow);
        JumpLimit();
        Move(KeyCode.RightArrow, dir);

    }
}
